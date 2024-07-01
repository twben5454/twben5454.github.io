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
using System.Diagnostics;

public partial class Admin_Page_Member_MemberJoin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.JoinDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DB.FillFineUIDropDownList(this.BankID, "Select BankName,BankID From tblBank", "");
        }
    }

    protected void UpMemberID_TriggerClick(object sender, EventArgs e)
    {
        this.Window1.Hidden = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        string strSQL = @"Select a.* ,b.MemberClassName
                            From tblMember a 
                            Left join tblMemberClass b on a.MemberClassID = b.MemberClassID
                            Where a.MemberClassID <> ''";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (a.MemberID Like '%" + this.txtSearch.Text + "%' or a.MemberName Like '%" + this.txtSearch.Text + "%')";
        }
        //FineUIPro.Alert.Show(strSQL);
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
    }

    protected void Grid1_RowDoubleClick(object sender, FineUIPro.GridRowClickEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        this.UpMemberID.Text = keys[0].ToString();
        this.UpMemberName.Text = keys[1].ToString();
        this.UpMemberClassID.Text = keys[2].ToString();
        this.Window1.Hidden = true;
    }

    //存檔
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (CheckCellPhone(this.CellPhone.Text) == true)
        {
            FineUIPro.Alert.Show("手機號碼己經有申請過");
            this.CellPhone.Focus();
        }
        else
        {
            string NewMemberID = MemberModel.GetNewMemberID();
            MemberModel UpMember = MemberModel.MemberDetail(UpMemberID.Text);
            string strSQL = @"Insert Into tblMember( MemberID,MemberName,CellPhone ,UpMemberID,MemberClassID,Birthday,Address,Zip,JoinDate,Email,lvl,UpGroup,MemberUrl,FB, LineID ,BankID ,BankAccount ,BankAccountName ,Created)
                            Values (@MemberID,@MemberName,@CellPhone ,@UpMemberID,@MemberClassID,@Birthday,@Address,@Zip,@JoinDate,@Email,@lvl,@UpGroup,@MemberUrl,@FB, @LineID ,@BankID ,@BankAccount ,@BankAccountName ,@Created) ";
            ArrayList Params = new ArrayList();
            Params.Add(new SqlParameter("@MemberID", NewMemberID));
            Params.Add(new SqlParameter("@MemberName", MemberName.Text));
            Params.Add(new SqlParameter("@UpMemberID", UpMemberID.Text));
            Params.Add(new SqlParameter("@MemberClassID", "E"));
            Params.Add(new SqlParameter("@Birthday", Birthday.Text));
            Params.Add(new SqlParameter("@Address", Address.Text));
            Params.Add(new SqlParameter("@Zip", Zip.Text));
            Params.Add(new SqlParameter("@JoinDate", JoinDate.Text));
            Params.Add(new SqlParameter("@Email", Email.Text));
            Params.Add(new SqlParameter("@CellPhone", CellPhone.Text));
            string lvl = (Convert.ToInt16(UpMember.lvl) + 1).ToString();
            Params.Add(new SqlParameter("@lvl", lvl));
            Params.Add(new SqlParameter("@UpGroup", UpMember.UpGroup + NewMemberID + ","));
            Params.Add(new SqlParameter("@MemberUrl", MemberUrl.Text));
            Params.Add(new SqlParameter("@FB", FB.Text));
            Params.Add(new SqlParameter("@LineID", LineID.Text));
            Params.Add(new SqlParameter("@BankID", BankID.SelectedValue ));
            Params.Add(new SqlParameter("@BankAccount", BankAccount.Text));
            Params.Add(new SqlParameter("@BankAccountName", BankAccountName.Text));
            Params.Add(new SqlParameter("@Created", HttpContext.Current.Request.Cookies["LoginUserID"].Value + "/" + DB.getObject().GetClientIP(this) + "/" + DB.getObject().GetNowString()));

            if (DB.getObject().Execute(strSQL, Params, false).Success == true)
            {
                FineUIPro.Alert.Show("新增成功");
            }
            else
            {
                FineUIPro.Alert.Show("新增有誤");
            }
        }
    }

    protected bool CheckCellPhone(string CellPhone)
    {
        bool args = false;
        string strSQL = @"Select * From tblMember Where CellPhone = @CellPhone";
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@CellPhone", CellPhone));
        DataTable dt = DB.getObject().GetData(strSQL, Params, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            args = true;
        }
        return args;
    }
    //清空
    protected void btnReInput_Click(object sender, EventArgs e)
    {
        this.MemberName.Text = "";
        this.JoinDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        this.Birthday.Text = "";
        this.Email.Text = "";
        this.CellPhone.Text = "";
        this.Zip.Text = "";
        this.Address.Text = "";
        this.UpMemberClassID.Text = "";
        this.UpMemberName.Text = "";
        this.UpMemberID.Text = "";
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        FineUIPro.PageContext.Redirect("Member.aspx");
    }
}