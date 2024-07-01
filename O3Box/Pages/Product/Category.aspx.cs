using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class Category : System.Web.UI.Page
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
        string strSQL = "Select * From tblCategory Where LinkID='0' and IsUse='True'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            FineUIPro.TreeNode NewTreeNode = new FineUIPro.TreeNode();
            NewTreeNode.Text = dt.Rows[i]["CategoryName"].ToString();
            NewTreeNode.NodeID= dt.Rows[i]["CategoryID"].ToString();
            NewTreeNode.Expanded = true;
            NewTreeNode.EnableClickEvent = true;
            FillSubTree(NewTreeNode, dt.Rows[i]["CategoryID"].ToString());
            this.Tree1.Nodes.Add(NewTreeNode);
        }
    }

    protected void FillSubTree(FineUIPro.TreeNode UpTreeNode ,string LinkID)
    {
        string strSQL = "Select * From tblCategory Where LinkID='" + LinkID + "' and IsUse='True'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            FineUIPro.TreeNode NewTreeNode = new FineUIPro.TreeNode();
            NewTreeNode.Text = dt.Rows[i]["CategoryName"].ToString();
            NewTreeNode.NodeID = dt.Rows[i]["CategoryID"].ToString();
            NewTreeNode.Expanded = true;
            NewTreeNode.EnableClickEvent = true;
            FillSubTree(NewTreeNode, dt.Rows[i]["CategoryID"].ToString());
            UpTreeNode.Nodes.Add(NewTreeNode);
        }
    }

    protected static void FillFineUIDropDownList(FineUIPro.DropDownList obj, string strSQL, string DefaultVlue)
    {
        obj.Items.Clear();
        DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
        obj.Items.Add("最上層", "0");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            obj.Items.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
        }
        if (DefaultVlue != "")
        {
            obj.SelectedValue = DefaultVlue;
        }
        else
        {
            obj.SelectedValue = "";
        }
    }
    //新增
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.Window1.Hidden = false;
        FillFineUIDropDownList(this.LinkID, "Select CategoryName ,CategoryID From tblCategory Where IsUse='True' and LinkID='0'", "");
        this.CategoryID.Text = "自動編號";
        this.CategoryID.Readonly = true;
        this.CategoryName.Text = "";
        this.btnSave.Text = "新增";
    }
    //更改
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //FineUIPro.Alert.Show(this.Tree1.SelectedNode.ParentNode.Text + "-" + this.Tree1.SelectedNode.ParentNode.NodeID);
        
        string selectedId = Tree1.SelectedNodeID;
        if (!String.IsNullOrEmpty(selectedId))
        {
            this.Window1.Hidden = false;
            //string LinkID = DB.getObject().GetData("Select LinkID From tblCategory Where CategoryID='" + selectedId + "'", null, false).ReturnDataTable.Rows[0][0].ToString();
            //FillFineUIDropDownList(this.LinkID, "Select CategoryName ,CategoryID From tblCategory Where IsUse='True' and LinkID='0'", LinkID);
            try
            {
                this.LinkID.Items.Clear();
                this.LinkID.Items.Add(this.Tree1.SelectedNode.ParentNode.Text, this.Tree1.SelectedNode.ParentNode.NodeID);
                this.LinkID.SelectedIndex = 0;
            }
            catch {
                this.LinkID.Items.Clear();
                this.LinkID.Items.Add("最上層", "0");
                this.LinkID.SelectedIndex = 0;
            }
            this.CategoryID.Text = selectedId;
            this.CategoryName.Text = Tree1.FindNode(selectedId).Text;
            this.CategoryID.Readonly = true;
            this.btnSave.Text = "更改";
        }
        else
        {
            FineUIPro.Alert.Show("您尚未选择分类");
        }

    }

    //存档
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        if (this.btnSave.Text == "新增")
        {
            strSQL = @"Insert Into tblCategory(LinkID ,CategoryName) Values (
                       '" + this.LinkID.SelectedValue + @"',
                       '" + this.CategoryName.Text + @"')";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {
                FineUIPro.Alert.Show("新增成功");
                this.Window1.Hidden = true;
                BindTree();
            }
            else
            {
                FineUIPro.Alert.Show(strSQL);
            }
        }
        if (this.btnSave.Text == "更改")
        {
            strSQL = "Update tblCategory Set LinkID='" + this.LinkID.SelectedValue + "',CategoryName='" + this.CategoryName.Text + "' Where CategoryID='" + this.CategoryID.Text + "'";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {
                FineUIPro.Alert.Show("更改成功");
                this.Window1.Hidden = true;
                BindTree();
            }
            else
            {
                FineUIPro.Alert.Show(strSQL);
            }
        }
    }



    protected void Tree1_NodeCommand(object sender, FineUIPro.TreeCommandEventArgs e)
    {
        //FineUIPro.Alert.Show(this.Tree1.SelectedNodeID);
        this.btnEdit.Enabled = true;
        this.btnAddSub.Enabled = true;
        this.btnDel.Enabled = true;
    }

    protected void btnAddSub_Click(object sender, EventArgs e)
    {
        this.Window1.Hidden = false;
        this.LinkID.Items.Clear();
        this.LinkID.Items.Add(this.Tree1.SelectedNode.Text ,this.Tree1.SelectedNodeID );
        this.LinkID.SelectedIndex = 0;
        this.CategoryID.Text = "自動編號";
        this.CategoryID.Readonly = true;
        this.CategoryName.Text = "";
        this.btnSave.Text = "新增";
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        //FineUIPro.Alert.Show(this.Tree1.SelectedNodeID);
        string strSQL = "Update tblCategory Set IsUse='False' Where CategoryId='" + this.Tree1.SelectedNodeID + "'";
        DB.getObject().Execute(strSQL, null, false);
        FineUIPro.Alert.Show("刪除成功");
        BindTree();
    }
}