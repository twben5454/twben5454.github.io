using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

public partial class ContractUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        string strError = string.Empty;
        if (this.txtName.Text.Length == 0)
        {
            strError += "姓名未填 !!";
        }
        if (this.txtEmail.Text.Length == 0)
        {
            strError += "Email 未填 !!";
        }
        if (this.txtMessage.Text.Length == 0)
        {
            strError += "留言未填 !!";
        }
        if (strError.Length > 0)
        {
            txtError.Text  = strError;
        }
        else
        {
            string strSQL = @"Insert Into tblContract( IP,ContractName,ContractEmail,CellPhone,Message)
                                Values (@IP,@ContractName,@ContractEmail,@CellPhone,@Message) ";
            ArrayList Params = new ArrayList();
            Params.Add(new SqlParameter("@IP", DB.GetIPAddress()));
            Params.Add(new SqlParameter("@ContractName", txtName.Text ));
            Params.Add(new SqlParameter("@ContractEmail", txtEmail.Text ));
            Params.Add(new SqlParameter("@CellPhone", txtCellPhone.Text ));
            Params.Add(new SqlParameter("@Message", txtMessage.Text));
            DB.getObject().Execute(strSQL, Params, false);
            string message = "留言己送出, 我們會儘速與您連絡";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("');location.href = 'Default.aspx';};");
            //sb.Append("location.href = 'Default.aspx';");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            //Response.Redirect("Default.aspx");
        }
    }
}