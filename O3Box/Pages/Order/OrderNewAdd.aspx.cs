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
using System.Collections.Specialized;

public partial class Admin_Page_Order_OrderNewAdd : System.Web.UI.Page
{
    DataTable Cart = new DataTable();
    DataRow dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["ShopingCart"] = null;
            DB.FillFineUIDropDownList(this.PID, "Select PName ,PID From tblProduct", "");
        }
    }

    protected void MemberID_TriggerClick(object sender, EventArgs e)
    {
        this.Window1.Hidden = false;
        string strSQL = @"Select a.* ,b.MemberClassName
                            From tblMember a 
                            Left join tblMemberClass b on a.MemberClassID = b.MemberClassID
                            Where a.MemberClassID = 'E'";        
        //FineUIPro.Alert.Show(strSQL);
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        string strSQL = @"Select a.* ,b.MemberClassName
                            From tblMember a 
                            Left join tblMemberClass b on a.MemberClassID = b.MemberClassID
                            Where a.MemberClassID = 'E'";
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
        this.MemberID.Text = keys[0].ToString();
        this.MemberName.Text = keys[1].ToString();
        this.MemberClassID.Text = keys[2].ToString();
        MemberModel UpMember = MemberModel.MemberDetail(keys[3].ToString());
        this.UpMemberID.Text = keys[3].ToString();
        this.UpMemberName.Text = UpMember.MemberName;
        this.UpMemberClassID.Text = ClassDB.GetMemberClassName(UpMember.MemberClassID);
        this.Window1.Hidden = true;
        ////FineUIPro.Alert.Show("dsafdsf");
        //this.TextBox1.Text = keys[0].ToString();
        //FineUIPro.PageContext.RegisterStartupScript(FineUIPro.ActiveWindow.GetWriteBackValueReference(TextBox1.Text, TextBox1.Text + " - 第二个值") + FineUIPro.ActiveWindow.GetHideReference());
    }
    //存檔 tblOrderM ,tblOrderD
    protected void Button1_Click(object sender, EventArgs e)
    {
        string NewOrderID = GetNewOrderID();
        string strSQL = @"Insert Into tblOrderM( OrderID,OrderDate,MemberID,Amount,IsUse)
                          Values (@OrderID,@OrderDate,@MemberID,@Amount,@IsUse) ";
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@OrderID", NewOrderID));
        Params.Add(new SqlParameter("@OrderDate", DateTime.Today.ToString("yyyy-MM-dd")));
        Params.Add(new SqlParameter("@MemberID", MemberID.Text));
        Params.Add(new SqlParameter("@Amount", this.lblTotal.Text ));
        Params.Add(new SqlParameter("@IsUse", "True"));
        DB.getObject().Execute(strSQL, Params, false);
        Cart = (DataTable)Session["ShoppingCart"];
        for (int i = 0; i < Cart.Rows.Count; i++)
        {
            strSQL = @"Insert Into tblOrderD( OrderID,item,PID,Num,Price)
                            Values (@OrderID,@item,@PID,@Num,@Price) ";
            Params = new ArrayList();
            Params.Add(new SqlParameter("@OrderID", NewOrderID));
            Params.Add(new SqlParameter("@item", i.ToString()));
            Params.Add(new SqlParameter("@PID", Cart.Rows[i]["PID"].ToString()));
            Params.Add(new SqlParameter("@Num", Cart.Rows[i]["Num"].ToString()));
            Params.Add(new SqlParameter("@Price", Cart.Rows[i]["Price"].ToString()));
            DB.getObject().Execute(strSQL, Params, false);
        }
        //晉升
        string TargetMemberClassID = "E";
        if (Convert.ToInt32(this.lblTotal.Text) >= 5600 && Convert.ToInt32(this.lblTotal.Text) < 20000){ TargetMemberClassID = "D"; }
        if (Convert.ToInt32(this.lblTotal.Text) >= 20000 && Convert.ToInt32(this.lblTotal.Text) < 50000) { TargetMemberClassID = "C"; }
        if (Convert.ToInt32(this.lblTotal.Text) >= 50000 && Convert.ToInt32(this.lblTotal.Text) < 100000) { TargetMemberClassID = "B"; }
        if (Convert.ToInt32(this.lblTotal.Text) >= 100000 ) { TargetMemberClassID = "A"; }
        if (TargetMemberClassID != "E")
        {
            strSQL = @"Update tblMember Set MemberClassID ='" + TargetMemberClassID + "' Where MemberID ='" + MemberID.Text + "' ";
            strSQL += @"Insert Into tblMemberPromotion( MemberID,PromotionDate,SourceMemberClassID,TargetMemberClassID,Memo)
                        Values (
                        '" + MemberID.Text + @"' ,
                        getdate() ,
                        'E' ,
                        '" + TargetMemberClassID + @"' ,
                        '加入訂單' 
                        ) ";
            strSQL += "Exec sp_OrderNewAdd '" + NewOrderID + "'";
            DB.getObject().Execute(strSQL, null, false);
            //FineUIPro.Alert.Show(strSQL);
        }

        FineUIPro.Alert.Show("新增成功");
        this.Button1.Enabled = false;

    }
    protected void FillGrid()
    { 
        this.Grid2.DataSource = Cart;
        this.Grid2.DataBind();
        int Amount = 0;
        for (int i = 0; i < Cart.Rows.Count; i++)
        {
            Amount += Convert.ToInt32(Cart.Rows[i]["Price"].ToString()) * Convert.ToInt32(Cart.Rows[i]["Num"].ToString());
        }
        this.lblTotal.Text = Amount.ToString();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Session["ShopingCart"] == null)
        {
            createOrderTable();
        }
        else
        {
            Cart = (DataTable)Session["ShoppingCart"];
        }
        dr = Cart.NewRow();
        dr[0] = this.PID.SelectedValue;
        dr[1] = this.PID.SelectedText;
        dr[2] = this.Price.Text ;
        dr[3] = this.Num.Text;
        //dr[4] = (Convert.ToInt32(this.Price.Text) * Convert.ToInt32(this.Num.Text)).ToString();
        Cart.Rows.Add(dr);
        
        Session["ShopingCart"] = Cart;
        FillGrid();
    }

    protected void PID_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSQL = @"Select PriceE From tblProduct Where PID = @PID ";
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@PID", PID.SelectedValue ));
        DataTable dt = DB.getObject().GetData(strSQL, Params, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            this.Price.Text = dt.Rows[0][0].ToString();
        }
        this.Num.Text = "1";
        this.lblTotal.Text = dt.Rows[0][0].ToString();
    }

    protected void Num_TextChanged(object sender, EventArgs e)
    {
        this.lblTotal.Text = (Convert.ToInt32(this.Num.Text) * Convert.ToInt32(Price.Text)).ToString();
    }

    protected string GetNewOrderID()
    {
        string args = string.Empty;
        string NewOrderID = DateTime.Today.ToString("yyyyMMdd");
        string strSQL = @"Select Top 1 OrderID From tblOrderM Where Left(OrderID ,8 ) ='" + NewOrderID + "' Order by OrderID Desc";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            args =(Convert.ToInt64(dt.Rows[0][0].ToString()) + 1).ToString();
        }
        else
        {
            args = DateTime.Today.ToString("yyyyMMdd") + "0001";
        }
        return args;
    }

    private void createOrderTable()
    {

        Cart.Columns.AddRange
            (new DataColumn[4] 
                {   new DataColumn("PID", typeof(string)),
                    new DataColumn("PName", typeof(string)),
                    new DataColumn("Price", typeof(int)),
                    new DataColumn("Num", typeof(int))
                }
            );
        //Append Data Row
        Session["ShoppingCart"] = Cart;
    }
}