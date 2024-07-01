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

public partial class Admin_Page_Test_MemberSelect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string param1 = Request.QueryString["param1"];

            if (!String.IsNullOrEmpty(param1))
            {
                TextBox1.Text = param1;
            }

            
        }
    }

    protected void Grid1_RowDoubleClick(object sender, FineUIPro.GridRowClickEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        //FineUIPro.Alert.Show("dsafdsf");
        this.TextBox1.Text = keys[0].ToString();
        FineUIPro.PageContext.RegisterStartupScript(FineUIPro.ActiveWindow.GetWriteBackValueReference(TextBox1.Text, TextBox1.Text + " - 第二个值") + FineUIPro.ActiveWindow.GetHideReference());
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strSQL = @"Select a.* ,b.MemberClassName
                            From tblMember a 
                            Left join tblMemberClass b on a.MemberClassID = b.MmeberClassID
                            Where a.MemberID <> ''";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (a.MemberID Like '%" + this.txtSearch.Text + "%' or a.MemberName Like '%" + this.txtSearch.Text + "%')";
        }
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
    }
    protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        if (e.CommandName == "Action1")
        {
            
        }
    }

    protected void BindTree()
    { 

    }

    protected void Tree1_NodeCommand(object sender, FineUIPro.TreeCommandEventArgs e)
    {

    }
}