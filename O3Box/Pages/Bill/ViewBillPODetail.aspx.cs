using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ViewBillPODetail : System.Web.UI.Page
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
                this.HopeDate.Text = Convert.ToDateTime(dt.Rows[0]["HopeDate"].ToString()).ToString("yyyy-MM-dd");
                if (dt.Rows[0]["CloseDate"].ToString().Length != 0)
                {
                    this.CloseDate.Text = Convert.ToDateTime(dt.Rows[0]["CloseDate"].ToString()).ToString("yyyy-MM-dd");
                }
                this.Amount.Text = dt.Rows[0]["Amount"].ToString();
                this.IsClose.Checked= Convert.ToBoolean(dt.Rows[0]["IsClose"].ToString());
                this.Memo.Text = dt.Rows[0]["Memo"].ToString();
                DataTable dt1 = DB.getObject().GetData("Select * From tblBillD Where BillNo ='" + Request.QueryString["id"].ToString() + "'").ReturnDataTable;
                this.Grid1.DataSource = dt1;
                this.Grid1.DataBind();
            }
            
           
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

    
}
