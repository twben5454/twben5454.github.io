using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class Page_System_UserPower : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindTree();
        }
    }

    protected void BindTree()
    {
        this.Tree1.Nodes.Clear();
        string strSQL = "Select * From tblMenu Where LinkID='0' and IsUse='True'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            FineUIPro.TreeNode NewTreeNode = new FineUIPro.TreeNode();
            NewTreeNode.Text = dt.Rows[i]["MenuName"].ToString();
            NewTreeNode.NodeID = dt.Rows[i]["MenuID"].ToString();
            NewTreeNode.Expanded = true;
            FillSubTree(NewTreeNode, dt.Rows[i]["MenuID"].ToString());
            this.Tree1.Nodes.Add(NewTreeNode);
        }
    }

    protected void FillSubTree(FineUIPro.TreeNode UpTreeNode, string LinkID)
    {
        string strSQL = "Select * From tblMenu Where LinkID='" + LinkID + "' and IsUse='True'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            FineUIPro.TreeNode NewTreeNode = new FineUIPro.TreeNode();
            NewTreeNode.Text = dt.Rows[i]["MenuName"].ToString();
            NewTreeNode.NodeID = dt.Rows[i]["MenuID"].ToString();
            UpTreeNode.Nodes.Add(NewTreeNode);
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        FineUIPro.TreeNode[] nodes = Tree1.GetCheckedNodes();
        if (nodes.Length > 0)
        {
            string strSQL = "Delete tblUserPower Where UserID='" + HttpUtility.UrlDecode(Request.Cookies["UserID"].Value) + "'";
            DB.getObject().Execute(strSQL, null, false);
            StringBuilder sb = new StringBuilder();
            foreach (FineUIPro.TreeNode node in nodes)
            {
                InsertUserPower(HttpUtility.UrlDecode(Request.Cookies["UserID"].Value), node.NodeID);
            }
            FineUIPro.Alert.Show("设置成功");
        }
        else
        {
            FineUIPro.Alert.Show("没有被选中");
        }
    }

    protected void InsertUserPower(string UserID, string MenuID)
    {
        string strSQL = "Insert Into tblUserPower (UserID,MenuID) Vlaues ('" + UserID + "','" + MenuID + "')";
        DB.getObject().Execute(strSQL, null, false);
    }
}