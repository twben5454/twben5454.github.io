using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Test_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string args = string.Empty;
            string NewBillNo = DateTime.Today.ToString("yyyyMMdd");
            string strSQL = @"Select Top 1 BillNo From tblBillM Where BillType ='PO' and SUBSTRING(BillNo,3,8) = '" + DateTime.Today.ToString("yyyyMMdd") + "'  Order by BillNo Desc";
            DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
            if (dt.Rows.Count > 0)
            {
                args = (Convert.ToInt64(dt.Rows[0][0].ToString().Substring(2,11)) + 1).ToString();
                args = "PO" + args;
            }
            else
            {
                args = "PO" + DateTime.Today.ToString("yyyyMMdd") + "001";
            }

            this.lbl.Text = args;// "PO20210426001".Substring(2,11) ;// dt.Rows[0][0].ToString();
        }
    }
    protected void ShowNotify()
    { 
            FineUIPro.Notify notify = new FineUIPro.Notify();
            notify.Message = "資料處理完畢...";
            notify.DisplayMilliseconds = 2000;
            notify.ShowLoading = true;
            notify.PositionX = FineUIPro.Position.Center;
            notify.PositionY = FineUIPro.Position.Center;

            notify.Show();
    }
}