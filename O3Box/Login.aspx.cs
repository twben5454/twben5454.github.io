using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string strSQL = "Select * From tblUser Where UserID=@UserID and UserPassword = @UserPassword and StatusCode='Y'";
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@UserID", this.tbxUserName.Text));
        Params.Add(new SqlParameter("@UserPassword", this.tbxPassword.Text));
        DataTable dt = DB.getObject().GetData(strSQL, Params, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            //HttpCookie cookie = new HttpCookie("LoginUserID");
            ////設定單值
            //cookie.Value = Server.UrlEncode(this.tbxUserName.Text);
            ////設定過期日
            //cookie.Expires = DateTime.Now.AddDays(20);
            ////寫到用戶端
            //HttpCookie cookieA = new HttpCookie("LoginUserName");
            ////設定單值
            //cookieA.Value = Server.UrlEncode(this.tbxUserName.Text);
            ////設定過期日
            //cookieA.Expires = DateTime.Now.AddDays(20);
            ////寫到用戶端
            //Response.Cookies.Add(cookie);
            //Response.Cookies.Add(cookieA);
            Session["LoginUserID"] = dt.Rows[0]["UserID"].ToString();
            Session["LoginUserName"] = dt.Rows[0]["UserName"].ToString();
            FineUIPro.PageContext.Redirect("Default.aspx");
        }
        else
        {
            FineUIPro.Alert.Show("帳號或密碼錯誤！！！");
        }
    }
    //最高權限登入
    
}