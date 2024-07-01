using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BillPODetail : System.Web.UI.Page
{
    DataRow dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            DB.FillFineUIDropDownList(this.SourceID , "select VendorName ,VendorID From tblVendor Where StatusCode='Y' ", "");
            DB.FillFineUIDropDownList(this.PID, "select PName ,PID  from tblProduct Where StatusCode='Y' ", "");
            this.BillDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            if (Request.QueryString["id"] == null)
            {
                this.BillNo.Text = "自動編號";
                this.StockID.Hidden = true;
                this.BillNo.Readonly = true;
                this.IsClose.Hidden = true;
                this.CloseDate.Hidden = true;
            }
        }
    }     

    protected void drpProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSQL = @"SELECT Price From tblProduct Where Pid='" + this.PID.SelectedValue + "'";
        DataTable  dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            this.Price.Text = dt.Rows[0]["Price"].ToString();          
            
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        //this.Grid1.Items.Clear();
        //this.Grid1.DataSource = BillLists;
        //this.Grid1.DataBind();
        
    }

    private void createTable()
    {
        if (Session["dt"] == null)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[6] {
            new DataColumn("PID", typeof(string)),
            new DataColumn("PName", typeof(string)),
            new DataColumn("ItemNum", typeof(int)),
            new DataColumn("Price", typeof(double)),
            new DataColumn("Amount", typeof(double)),
            new DataColumn("Memo", typeof(string))});
            Session["dt"] = dt;
        }
    }


    //新增產品
    protected void btnAddSub_Click(object sender, EventArgs e)
    {
        string strError = string.Empty;
        if (this.PID.SelectedValue == "") { strError += "未選擇商品"; }
        if (strError.Length > 0)
        {
            FineUIPro.Alert.Show(strError);
        }
        else
        {
            createTable();
            DataTable dt = (DataTable)Session["dt"];
            DataRow[] rows = dt.Select("PID = '" + this.PID.SelectedValue + "'");
            if (rows.Length > 0)
            {
                rows[0][2] = Convert.ToInt32(rows[0][2].ToString()) + Convert.ToInt32(this.PNum.Text);
                rows[0][4] = Convert.ToInt32(rows[0][2].ToString()) * Convert.ToInt32(rows[0][3].ToString());
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = this.PID.SelectedValue;
                dr[1] = this.PID.SelectedText;
                dr[2] =  this.PNum.Text;
                dr[3] = this.Price.Text;
                dr[4] = (Convert.ToInt32(this.Price.Text) * Convert.ToInt32(this.PNum.Text)).ToString();
                dt.Rows.Add(dr);
            }
            
            Session["dt"] = dt;
            FillGrid();
            ClearSub();
        }
    }
    //取消
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearSub();
    }

    private void ClearSub()
    {

        DB.FillFineUIDropDownList(this.PID, "select PName ,PID  from tblProduct Where StatusCode='Y' ", "");
        this.Price.Text = "";
        this.PNum.Text = "1";
    }



    protected void btnBack_Click(object sender, EventArgs e)
    {
        FineUIPro.PageContext.Redirect("BillPOList.aspx");
    }

    protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        if (e.CommandName == "Action1")
        {

            DataTable dt = (DataTable)Session["dt"];
            DataRow[] rows = dt.Select("PID = '" + keys[0].ToString() + "'");
            for (int i = 0; i < rows.Length; i++)
            {

                rows[i].Delete();
            }
            FillGrid();
        }

    }

    protected void FillGrid()
    {
        DataTable dt = (DataTable)Session["dt"];
        int TotalAmount = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            TotalAmount += Convert.ToInt32(dt.Rows[i]["Amount"].ToString());
        }
        Amount.Text = TotalAmount.ToString("0:N2");
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
       
    }
    //存檔
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["dt"];
        if  (Session["dt"] == null)
        {
            FineUIPro.Alert.Show("尚未選擇商品");
            return;
        }
        if (this.SourceID.SelectedValue  == "")
        {
            FineUIPro.Alert.Show("尚未選擇供應商");
            return;
        }

        string BillNo =Bonus.GetNewBillNo("PO");
        string strSQL = @"Insert Into tblBillM(  BillNo,BillType,BillDate,Amount,HopeDate,SourceID,Memo,CreateUser,CreateTime,EditUser,EditTime,StatusCode) 
                            Values  ('" + BillNo + @"', 
                            'PO', 
                            '" + BillDate.Text + @"', 
                            '" + Amount.Text + @"', 
                            '" + HopeDate.Text + @"', 
                            '" + SourceID.SelectedValue   + @"', 
                            '" + Memo.Text + @"', 
                            '" + Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress() + @"',
                            '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                            '" + Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress() + @"',
                            '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                            'Y') ";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            strSQL += @" Insert Into tblBillD(BillNo, PID, PNum ,Price , Amount,   EditUser, EditTIme)
                        Values('" + BillNo + @"',
                        '" + dt.Rows[i]["PID"].ToString() + @"',
                        '" + dt.Rows[i]["ItemNum"].ToString() + @"',
                        '" + dt.Rows[i]["Price"].ToString() + @"',
                        '" + dt.Rows[i]["Amount"].ToString() + @"',
                        '" + Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress() + @"',
                        '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"')";
        }
        if (DB.getObject().Execute(strSQL, null, false).Success == true)
        {
            FineUIPro.Alert.Show("新增成功");
            Session["dt"] = null;
            FineUIPro.PageContext.Redirect("BillPOList.aspx");
        }
        else
        {
            FineUIPro.Alert.Show(strSQL);
        }
        //FineUIPro.Alert.Show(strSQL );
    }


}
