using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;
using System.Data.SqlClient;

public partial class UserGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginUserID"] == null)
        {
            FineUIPro.Alert.Show("請先登入 !!");
            Response.Write("<script type='text/javascript'>locaton.reload()</script>");
            return;
        }
        if (!IsPostBack)
        {
            
           BindGrid();
        }
    }

    


    void BindGrid()
    {
        string sortField = Grid1.SortField;
        string sortDirection = Grid1.SortDirection;
        string strSQL = @"Select * From tblUserGroup Where  StatusCode ='Y' ";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (UserGroupID Like '%" + this.txtSearch.Text + "%' or UserGroupName like '%" + this.txtSearch.Text + "%')";
        }
        

        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            DataView view1 = dt.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);

            Grid1.DataSource = view1;
            Grid1.DataBind();
        }
        else
        {
            FineUIPro.Alert.Show("查無資料！！");
        }
        //FineUIPro.Alert.Show(strSQL);
    }

    #region "Grid 操作"
    //事件
    protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        if (e.CommandName == "Action1")
        {
            this.Window1.Hidden = false;
            ClearFormData();
           
            this.Window1.Title = "更改";
            this.UserGroupID.Text = keys[0].ToString();
            this.UserGroupID.Readonly = true;
            this.UserGroupName.Text = keys[1].ToString();

        }
        if (e.CommandName == "Action2")
        {

            string strSQL = @"Delete  tblUserGroup Where UserGroupID = @UserGroupID";
            ArrayList Params = new ArrayList();
            Params.Add(new SqlParameter("@UserGroupID", keys[0].ToString()));
            if (DB.getObject().Execute(strSQL, Params, false).Success == true)
            {   
                FineUIPro.Alert.Show("刪除成功");
                BindGrid();
                ///FineUIPro.Alert.Show(IsUse);
            }

        }

        if (e.CommandName == "Action4")
        {
            this.Window2.Hidden = false;
            this.Window2.Title = keys[1].ToString() + "權限設定";
            Session["UserGroupID"] = keys[0].ToString();
            BindTree();
        }
    }
    //跳页
    protected void Grid1_PageIndexChange(object sender, FineUIPro.GridPageEventArgs e)
    {
        Grid1.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    //排序
    protected void Grid1_Sort(object sender, FineUIPro.GridSortEventArgs e)
    {
        BindGrid();
    }


    #endregion

    protected void btnSelectItem6_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.Window1.Title = "新增";
        this.UserGroupID.Text = "自動編號";
        this.UserGroupID.Readonly = true;
        ClearFormData();
        
        
        this.Window1.Hidden = false;
    }

    protected void ClearFormData()
    {
        this.UserGroupName.Text = "";

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
            ArrayList Params = new ArrayList();
            Params.Add(new SqlParameter("@UserGroupName", UserGroupName.Text));
        if (this.Window1.Title == "新增")
        {
            strSQL = @"Insert Into tblUserGroup(  UserGroupName,CreateTime,CreateUser,EditTime,EditUser,StatusCode) 
            Values  (@UserGroupName,@CreateTime,@CreateUser,@EditTime,@EditUser,@StatusCode) ";
            Params.Add(new SqlParameter("@CreateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ));
            Params.Add(new SqlParameter("@CreateUser", Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress()));
            Params.Add(new SqlParameter("@EditTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ));
            Params.Add(new SqlParameter("@EditUser", Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress()));
            Params.Add(new SqlParameter("@StatusCode", "Y"));
            if (DB.getObject().Execute(strSQL, Params, false).Success == true)
            {
                FineUIPro.Alert.Show("新增成功");
                this.Window1.Hidden = true;
                BindGrid();
            }
            else
            {
                FineUIPro.Alert.Show(strSQL );
            }
        }
        if (this.Window1.Title == "更改")
        {
            strSQL = @"Update tblUserGroup  Set 
                        UserGroupName=@UserGroupName,
                        EditTime=@EditTime,
                        EditUser=@EditUser
                        Where UserGroupID = @UserGroupID ";
            Params.Add(new SqlParameter("@UserGroupID", UserGroupID.Text ));
            Params.Add(new SqlParameter("@EditTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ));
            Params.Add(new SqlParameter("@EditUser", Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress()));
            if (DB.getObject().Execute(strSQL, Params, false).Success == true)
            {
                FineUIPro.Alert.Show("更改成功");
                this.Window1.Hidden = true;
                BindGrid();
            }
            else
            {
                FineUIPro.Alert.Show(strSQL);
            }
        }
        //FineUIPro.Alert.Show(strSQL);
    }

    

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        this.txtSearch.Text = "";
        
        BindGrid();
    }


    #region "Data"
    protected void BindTree()
    {
        this.Tree1.Nodes.Clear();
        string strSQL = "Select * From tblMenu Where LinkID='0' and StatusCode='Y' Order by OrderNum";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            FineUIPro.TreeNode NewTreeNode = new FineUIPro.TreeNode();
            NewTreeNode.Text = dt.Rows[i]["MenuName"].ToString();
            NewTreeNode.NodeID = dt.Rows[i]["MenuID"].ToString();
            NewTreeNode.Expanded = true;
            NewTreeNode.Selectable = false;
            NewTreeNode.EnableClickEvent = true;
            FillSubTree(NewTreeNode, dt.Rows[i]["MenuID"].ToString());
            this.Tree1.Nodes.Add(NewTreeNode);
        }
    }

    protected void FillSubTree(FineUIPro.TreeNode UpTreeNode, string LinkID)
    {
        string strSQL = "Select * From tblMenu Where LinkID='" + LinkID + "' and StatusCode='Y' Order by OrderNum";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            FineUIPro.TreeNode NewTreeNode = new FineUIPro.TreeNode();
            NewTreeNode.Text = dt.Rows[i]["MenuName"].ToString();
            NewTreeNode.NodeID = dt.Rows[i]["MenuID"].ToString();
            NewTreeNode.Expanded = true;
            NewTreeNode.Checked = CheckMenu(Session["UserGroupID"].ToString(), dt.Rows[i]["MenuID"].ToString()) ;
            NewTreeNode.EnableClickEvent = true;
            FillSubTree(NewTreeNode, dt.Rows[i]["MenuID"].ToString());
            UpTreeNode.Nodes.Add(NewTreeNode);
        }
    }
    #endregion
    #region "Export To Excel"
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + this.Grid1.Title + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        Response.ContentType = "application/vnd.ms-excel";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.Write(GetGridTableHtml(Grid1));
        Response.End();
    }

    private string GetGridTableHtml(FineUIPro.Grid grid)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("<meta http-equiv=\"Content-Type\" content=\"application/vnd.ms-excel;charset=utf-8\"/>");


        sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");

        sb.Append("<tr>");
        foreach (FineUIPro.GridColumn column in grid.Columns)
        {
            sb.AppendFormat("<td>{0}</td>", column.HeaderText);
        }
        sb.Append("</tr>");


        foreach (FineUIPro.GridRow row in grid.Rows)
        {
            sb.Append("<tr>");
            foreach (object value in row.Values)
            {
                string html = value.ToString();
                if (html.StartsWith(FineUIPro.Grid.TEMPLATE_PLACEHOLDER_PREFIX))
                {
                    // 模板列
                    string templateID = html.Substring(FineUIPro.Grid.TEMPLATE_PLACEHOLDER_PREFIX.Length);
                    Control templateCtrl = row.FindControl(templateID);
                    html = GetRenderedHtmlSource(templateCtrl);
                }
                else
                {
                    // CheckBox
                    if (html.Contains("f-grid-static-checkbox"))
                    {
                        if (!html.Contains("f-checked"))
                        {
                            html = "×";
                        }
                        else
                        {
                            html = "√";
                        }
                    }

                    if (html.Contains("<img"))
                    {
                        string prefix = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
                        html = html.Replace("src=\"", "src=\"" + prefix);
                    }
                }

                sb.AppendFormat("<td>{0}</td>", html);
            }
            sb.Append("</tr>");
        }

        sb.Append("</table>");

        return sb.ToString();
    }

    private string GetRenderedHtmlSource(Control ctrl)
    {
        if (ctrl != null)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    ctrl.RenderControl(htw);

                    return sw.ToString();
                }
            }
        }
        return String.Empty;
    }
    #endregion

    protected void btnSaveTree_Click(object sender, EventArgs e)
    {
       FineUIPro.TreeNode[] nodes = Tree1.GetCheckedNodes();
        string strSQL = string.Empty;
        strSQL = "Delete tblUserGroupMenu Where UserGroupID ='" + Session["UserGroupID"].ToString() + "' ";
        if (nodes.Length > 0)
        {
            
            foreach (FineUIPro.TreeNode node in nodes)
            {
                strSQL += "Insert Into tblUserGroupMenu (UserGroupID ,MenuID) Values ('" + Session["UserGroupID"].ToString() + "','" + node.NodeID + "') ";
                //sb.AppendFormat("{0} ", node.NodeID);
            }
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {
                FineUIPro.Alert.Show("存檔成功 !!");
                this.Window2.Hidden = true;
            }
            else
            {
                FineUIPro.Alert.Show(strSQL);
            }
        }
        else
        {
            FineUIPro.Alert.Show("您尚未選擇性!");
        }
    }

    protected bool CheckMenu(string UserGroupID, string MenuID)
    {
        bool args = false;
        string strSQL = "Select * From tblUserGroupMenu Where UserGroupID='" + UserGroupID + "' and MenuID='" + MenuID + "' ";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            args = true;
        }
        return args;
    }
}