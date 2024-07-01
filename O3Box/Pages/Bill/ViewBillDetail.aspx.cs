using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ViewBillDetail : System.Web.UI.Page
{
    DataRow dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            FineUIPro.Alert.Show("資料有錯 ");
            return;
        }
        if (!IsPostBack)
        {
            string strSQL = "Select * From tblBillM Where BillNo ='" + Request.QueryString["id"].ToString() + "'";
            DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
            if (dt.Rows.Count > 0)
            {
                DB.FillFineUIDropDownList(this.SourceID, "select VendorName ,VendorID From tblVendor Where StatusCode='Y' ", dt.Rows[0]["SourceID"].ToString() );
                this.BillDate.Text = Convert.ToDateTime(dt.Rows[0]["BillDate"].ToString()).ToString("yyyy-MM-dd");
                this.BillNo.Text = Request.QueryString["id"].ToString();
                //this.HopeDate.Text = Convert.ToDateTime(dt.Rows[0]["HopeDate"].ToString()).ToString("yyyy-MM-dd");
                if (dt.Rows[0]["CloseDate"].ToString().Length != 0)
                {
                    this.CloseDate.Text = Convert.ToDateTime(dt.Rows[0]["CloseDate"].ToString()).ToString("yyyy-MM-dd");
                }
                this.Amount.Text = dt.Rows[0]["Amount"].ToString();
                this.IsClose.Checked= Convert.ToBoolean(dt.Rows[0]["IsClose"].ToString());
                this.Memo.Text = dt.Rows[0]["Memo"].ToString();
                DataTable dt1 = DB.getObject().GetData("Select * ,(Select PName From tblProduct Where PID= tblBillD.PID) as PName From tblBillD Where StatusCode='Y' and BillNo ='" + Request.QueryString["id"].ToString() + "'").ReturnDataTable;
                this.Grid1.DataSource = dt1;
                this.Grid1.DataBind();

                // 欄位
                string BillType = Request.QueryString["typ"].ToString();
                if (BillType == "SI")
                {
                    
                    this.SourceID.Label = "供應商";
                    this.SourceID.Hidden = false;
                    this.Amount.Hidden = false;
                    this.SimpleForm1.Title = "進貨明細";
                    this.IsClose.Hidden = true;
                    //this.Amount.Text = dt.Rows[0]["Amount"].ToString();
                    DB.FillFineUIDropDownList(this.SourceID, "Select VendorName ,VendorID From tblVendor Where StatusCode='Y'", dt.Rows[0]["SourceID"].ToString());
                    DB.FillFineUIDropDownList(this.StockID, "Select StockName ,StockID From tblStock Where StatusCode='Y'", dt.Rows[0]["StockID"].ToString());
                    this.HopeDate.Hidden = true;
                    this.CloseDate.Hidden = true;
                    this.StockID.Hidden = false; 
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
            }
            
           
            //if (Request.QueryString["id"] == null)
            //{
            //    this.BillNo.Text = "自動編號";
            //    this.StockID.Hidden = true;
            //    this.BillNo.Readonly = true;
            //    this.IsClose.Hidden = true;
            //    this.CloseDate.Hidden = true;
            //}
        }
    }     

    
}
