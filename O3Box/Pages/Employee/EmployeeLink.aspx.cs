using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EmployeeLink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string EmployeeID = Request.QueryString["id"].ToString();
            string strSQL = "Select CheckDName ,CheckDID From tblCheckD Where IsUse ='True'";
            DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               this.CheckDItem.Items.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());            
            }
            for (int i = 0; i < CheckDItem.Items.Count ; i++)
            {
                CheckDItem.Items[i].Selected = GetCheck(EmployeeID, CheckDItem.Items[i].Value);
            }

        }
    }

    protected bool GetCheck(string EmployeeID, string CheckDID)
    {
        bool args = false;
        string strSQL = "Select *  From tblEmployeeLink Where EmployeeID = '" + EmployeeID + "' and CheckDID ='" + CheckDID + "'";
        DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            args = true;
        }
        return args;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string EmployeeID = Request.QueryString["id"].ToString();
        string strSQL = "Delete tblEmployeeLink Where EmployeeID = '" + EmployeeID + "' ";
        string Result = String.Join(", ", CheckDItem.SelectedValueArray);
        string[] sArray = Result.Split(',');
        foreach (string i in sArray)
        {
            strSQL += "Insert Into tblEmployeeLink (EmployeeID ,CheckDID) Values ('" + EmployeeID + "','" + i.Trim() + "') ";
        }
        if (DB.getObject().Execute(strSQL, null, false).Success == true)
        {
            FineUIPro.Alert.Show("异动成功");
            //FineUIPro.PageContext.RegisterStartupScript(FineUIPro.ActiveWindow.GetHidePostBackReference());
            //FineUIPro.PageContext.RegisterStartupScript("F.notify({message:'添加成功！',messageIcon:'information',target:'_top',header:false,displayMilliseconds:3000,positionX:'center',positionY:'top'});" + FineUIPro.ActiveWindow.GetHidePostBackReference());
            FineUIPro.PageContext.RegisterStartupScript(FineUIPro.ActiveWindow.GetHideRefreshReference());
        }
        //FineUIPro.Alert.Show(strSQL);
    }
}