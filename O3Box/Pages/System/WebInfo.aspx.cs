using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Page_System_WebInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
    }

    protected void FillData()
    {
        string strSQL = "Select * From tblWebInfo";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        this.WebName.Text = dt.Rows[0]["WebName"].ToString();
        this.WebUrl.Text = dt.Rows[0]["WebUrl"].ToString();
        this.WXID.Text = dt.Rows[0]["WXID"].ToString();
        this.WXName.Text = dt.Rows[0]["WXName"].ToString();
        this.Address.Text = dt.Rows[0]["Address"].ToString();
        this.Tel.Text = dt.Rows[0]["Tel"].ToString();
        this.Fax.Text = dt.Rows[0]["Fax"].ToString();
        this.Email.Text = dt.Rows[0]["Email"].ToString();
        this.MetaKeyWords.Text = dt.Rows[0]["MetaKeyWords"].ToString();
        this.SDate.Text = dt.Rows[0]["SDate"].ToString();
        this.EDate.Text = dt.Rows[0]["EDate"].ToString();
        this.Created.Text = dt.Rows[0]["Created"].ToString();
        this.Updated.Text = dt.Rows[0]["Updated"].ToString();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        string strSQL = @"Update tblWebInfo  Set 
                            WXID='" + WXID.Text + @"',
                            WXName='" + WXName.Text + @"',
                            Address='" + Address.Text + @"',
                            Tel='" + Tel.Text + @"',
                            Fax='" + Fax.Text + @"',
                            Email='" + Email.Text + @"',
                            MetaKeyWords='" + MetaKeyWords.Text + @"',
                            Updated='" + DB.getObject().GetCreated(this) + @"'";
        if (DB.getObject().Execute(strSQL, null, false).Success == true)
        {
            FineUIPro.Alert.Show("更改成功");
        }
    }
}