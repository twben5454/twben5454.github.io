using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BillDetail : System.Web.UI.Page
{
    DataRow dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["typ"] != null)
            {
                FillBillType(Request.QueryString["typ"].ToString());
                
            }
            

            if (Request.QueryString["id"] == null)
            {
                this.BillNo.Text = "自動編號";
                this.BillNo.Readonly = true;
                this.IsClose.Hidden = true;
                this.CloseDate.Hidden = true;
            }
        }
    }

    protected void FillBillType(string BillType )
    {
        //string strSQL = @"Select * From tblBillM Where BillNo ='" + Request.QueryString["id"].ToString() + "'";
        //DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
        //this.BillNo.Text = dt.Rows[0]["BillNo"].ToString();
        //DB.FillFineUIDropDownList(this.SourceID, "select VendorName ,VendorID From tblVendor Where StatusCode='Y' ", dt.Rows[0]["SourceID"].ToString());
        DB.FillFineUIDropDownList(this.PID, "select PName ,PID  from tblProduct Where StatusCode='Y' ", "");
        //DB.FillFineUIDropDownList(this.StockID, "select StockName ,StockID From tblStock Where StatusCode='Y' ", dt.Rows[0]["StockID"].ToString());
        //this.BillDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
        //this.BillType.SelectedValue = BillType;
        //this.Memo.Text = dt.Rows[0]["Memo"].ToString();
        if (BillType == "SI")
        {
            this.SourceID.Label = "供應商";
            this.SourceID.Hidden = false;
            this.Amount.Hidden = false;
            this.SimpleForm1.Title = "進貨明細";
            this.IsClose.Hidden = true;
            //this.Amount.Text = dt.Rows[0]["Amount"].ToString();
            DB.FillFineUIDropDownList(this.SourceID, "Select VendorName ,VendorID From tblVendor Where StatusCode='Y'", "");
            DB.FillFineUIDropDownList(this.StockID, "Select StockName ,StockID From tblStock Where StatusCode='Y'", "");
            this.CloseDate.Hidden = true;
        }
        if (BillType == "IR")
        {
            this.SourceID.Label = "供應商";
            this.SourceID.Hidden = false;
            this.Amount.Hidden = false;
            this.SimpleForm1.Title = "進貨退回明細";
        }
        if (BillType == "ST")
        {
            this.SourceID.Label = "來源倉庫";
            this.SourceID.Hidden = false;
            this.Amount.Hidden = true;
            DB.FillFineUIDropDownList(this.SourceID, "Select StockName ,StockID From tblStock Where StatusCode='Y'", "");
            this.SimpleForm1.Title = "調撥明細";
        }
        if (BillType == "AD")
        {
            this.SourceID.Hidden = true;
            this.Amount.Hidden = true;
            this.SimpleForm1.Title = "調整明細";
        }
        if (BillType == "OT")
        {
            this.SourceID.Hidden = true;
            this.Amount.Hidden = true;
            this.SimpleForm1.Title = "其他明細";
        }
        //strSQL = @"Select * From tblBillD Where BillNo ='" + Request.QueryString["id"].ToString() + "'";
        //dt = DB.getObject().GetData(strSQL).ReturnDataTable;
        //this.Grid1.DataSource = dt;
        //this.Grid1.DataBind();
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
                dr["PID"] = this.PID.SelectedValue;
                dr["PName"] = this.PID.SelectedText;
                dr["ItemNum"] =  this.PNum.Text;
                dr["Price"] = this.Price.Text;
                dr["Amount"] = (Convert.ToInt32(this.Price.Text) * Convert.ToInt32(this.PNum.Text)).ToString();
                dr["Memo"] = this.txtMemo.Text;
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
        this.txtMemo.Text = "";
    }



    protected void btnBack_Click(object sender, EventArgs e)
    {
        string BillType;
        if (Request.QueryString["typ"] != null)
        {
            BillType = Request.QueryString["typ"].ToString();
            FineUIPro.PageContext.Redirect("BillList.aspx?typ=" + BillType);

        }
        //FineUIPro.PageContext.Redirect("BillPOList.aspx");
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
        if (this.SourceID.SelectedValue  == "" && this.BillType.SelectedValue == "SI")
        {
            FineUIPro.Alert.Show("尚未選擇供應商");
            return;
        }
        if (this.BillType.SelectedValue == "ST" && this.SourceID.SelectedValue == this.StockID.SelectedValue )
        {
            FineUIPro.Alert.Show("調撥時, 來源及目標倉庫不能一樣");
            return;
        }

        string BillNo =Bonus.GetNewBillNo(this.BillType.SelectedValue );
        string strSQL = @"Insert Into tblBillM(  BillNo,BillType,BillDate,Amount,SourceID, StockID ,Memo,CreateUser,CreateTime,EditUser,EditTime,StatusCode) 
                            Values  ('" + BillNo + @"', 
                            '" + BillType.SelectedValue + @"', 
                            '" + BillDate.Text + @"', 
                            '" + Amount.Text + @"', 
                            '" + SourceID.SelectedValue   + @"', 
                            '" + StockID.SelectedValue + @"', 
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
        //更改庫存
        if (Request.QueryString["typ"].ToString() == "SI")
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strSQL += @" exec spUpdateStockNum 
                        '" + dt.Rows[i]["PID"].ToString() + @"',
                        '" + dt.Rows[i]["ItemNum"].ToString() + @"',
                        '" + StockID.SelectedValue + @"',
                        'SI'";
            }
        }
        if (DB.getObject().Execute(strSQL, null, false).Success == true)
        {
            FineUIPro.Alert.Show("新增成功");
            Session["dt"] = null;
            //FineUIPro.PageContext.Redirect("BillPOList.aspx");
            FineUIPro.PageContext.Redirect("BillList.aspx?typ=" + Request.QueryString["typ"].ToString());

        }
        else
        {
            FineUIPro.Alert.Show(strSQL);
        }
    
    }



    protected void BillType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBillType(this.BillType.SelectedValue);
    }
}
