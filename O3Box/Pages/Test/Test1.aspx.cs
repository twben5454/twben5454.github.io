using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Collections;

public partial class Admin_Page_Test_Test1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }

    

    protected void UpMemberID_TriggerClick(object sender, EventArgs e)
    {
        this.Window1.Hidden = false;
    }

   

    protected void Grid1_RowDoubleClick(object sender, FineUIPro.GridRowClickEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        this.UpMemberID.Text = keys[0].ToString();
        this.UpMemberName.Text = keys[1].ToString();
        this.UpMemberClassID.Text = keys[2].ToString();
        this.Window1.Hidden = true;
        ////FineUIPro.Alert.Show("dsafdsf");
        //this.TextBox1.Text = keys[0].ToString();
        //FineUIPro.PageContext.RegisterStartupScript(FineUIPro.ActiveWindow.GetWriteBackValueReference(TextBox1.Text, TextBox1.Text + " - 第二个值") + FineUIPro.ActiveWindow.GetHideReference());
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        string strSQL = @"Select a.* ,b.MemberClassName
                            From tblMember a 
                            Left join tblMemberClass b on a.MemberClassID = b.MemberClassID
                            Where a.MemberID <> ''";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (a.MemberID Like '%" + this.txtSearch.Text + "%' or a.MemberName Like '%" + this.txtSearch.Text + "%')";
        }
        //FineUIPro.Alert.Show(strSQL);
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (CheckMemberID(this.MemberID.Text) == true)
        {
            FineUIPro.Alert.Show(this.MemberID.Text + "己經註冊過了");
        }
        else
        {
            MemberModel UpMember = MemberModel.MemberDetail(UpMemberID.Text);
            string MemberClassID = string.Empty;
            string strSQL = @"Insert Into tblMember( MemberID,MemberName,UpMemberID,MemberClassID,JoinDate,lvl,UpGroup,Created)
                                Values (@MemberID,@MemberName,@UpMemberID,@MemberClassID,@JoinDate,@lvl,@UpGroup,@Created) ";
            ArrayList Params = new ArrayList();
            Params.Add(new SqlParameter("@MemberID", MemberID.Text));
            Params.Add(new SqlParameter("@MemberName", MemberName.Text));
            Params.Add(new SqlParameter("@UpMemberID", UpMemberID.Text));
            Params.Add(new SqlParameter("@MemberClassID", MemberClassID));
            Params.Add(new SqlParameter("@JoinDate", JoinDate.Text ));
            string lvl = (Convert.ToInt16(UpMember.lvl) + 1).ToString();
            Params.Add(new SqlParameter("@lvl", lvl));
            Params.Add(new SqlParameter("@UpGroup", UpMember.UpGroup + this.MemberID.Text + ","));
            Params.Add(new SqlParameter("@Created", HttpContext.Current.Request.Cookies["LoginUserID"].Value + "/" + DB.getObject().GetClientIP(this) + "/" + DB.getObject().GetNowString()));
            if (DB.getObject().Execute(strSQL, Params, false).Success == true)
            {
                InsertOrder();
                //update MemberClassID
                strSQL = @"Update tblMember Set MemberClassID ='" + MemberModel.GetMemberClassIDByAmount(this.MemberID.Text ) + "' Where MemberID = '" + this.MemberID.Text + "' ";
                DB.getObject().Execute(strSQL, null, false);
                //this.Memo.Text += strSQL;
                this.Memo.Text += this.MemberID.Text + "新增成功";
            }
            else
            { }
        }
    }

    //增加訂單
    protected void InsertOrder() 
    {
        string strSQL = @"Insert Into tblOrderM( OrderID,OrderDate,MemberID,Amount)
                            Values (@OrderID,@OrderDate,@MemberID,@Amount) ";
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@OrderID", OrderID.Text ));
        Params.Add(new SqlParameter("@OrderDate", JoinDate.Text ));
        Params.Add(new SqlParameter("@MemberID", MemberID.Text ));
        Params.Add(new SqlParameter("@Amount", Amount.Text ));
        DB.getObject().Execute(strSQL, Params, false);
    }


    //算獎金
    protected void ComputerBonusB(string OrderID)
    {
        //10% , 5%
        OrderMModel OrderM = OrderMModel.OrderMDetail(OrderID);
        //this.Memo.Text += OrderM.MemberID + "第一代" + "\n";
        this.Memo.Text += MemberModel.GetUpMemberID(OrderM.MemberID) + "上線第一代10%" + (Convert.ToInt32(this.Amount.Text)*0.1).ToString() +  "\n";
        this.Memo.Text += MemberModel.GetUpMemberID(MemberModel.GetUpMemberID(OrderM.MemberID)) + "上線第二代5%" + (Convert.ToInt32(this.Amount.Text) * 0.1).ToString() + "\n";
    }
    //算推薦獎金 ,首次才有
    protected void ComputerBonusA(string OrderID)
    {
        OrderMModel OrderM = OrderMModel.OrderMDetail(OrderID);
        string MemberID = OrderM.MemberID;
        MemberModel Member = MemberModel.MemberDetail(MemberID);
        this.Memo.Text += "上線" + Member.UpMemberID + "\n";
        this.Memo.Text += "上線等級" + MemberModel.MemberDetail(Member.UpMemberID).MemberClassID + "\n";
        this.Memo.Text += "第一代人數:" + MemberModel.GetMemberLvlCount(MemberID ,Member.UpMemberID) + "\n";
        int Amount = MemberModel.GetBonusAByMemberClassID
                        (
                        Member.MemberClassID,
                        MemberModel.MemberDetail(Member.UpMemberID).MemberClassID,
                        MemberModel.GetMemberLvlCount(MemberID, Member.UpMemberID)
                        );
        this.Memo.Text += "上線可領推薦獎金:" + Amount.ToString() + "\n";
        //this.Memo.Text +=ClassDB.GetMemberClassName(Member.MemberClassID) + "\n";
        string strSQL = @"Insert Into tblMemberBonus( MemberID,OrderID,BonusClassID,Amount)
                            Values (@MemberID,@OrderID,@BonusClassID,@Amount) ";
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@MemberID", Member.UpMemberID));
        Params.Add(new SqlParameter("@OrderID", OrderID));
        Params.Add(new SqlParameter("@BonusClassID", "A"));
        Params.Add(new SqlParameter("@Amount", Amount.ToString()));
        DB.getObject().Execute(strSQL, Params, false);
    }
    protected bool CheckMemberID(string MemberID)
    {
        bool args = false;
        string strSQL = "Select * from tblMember  Where MemberID='" + MemberID + "'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            args = true;
        }
        return args;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //10% , 5%
        ComputerBonusA(this.OrderID.Text);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Memo.Text = "";
    }
}