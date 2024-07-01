using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class Bank : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
           BindGrid();
        }
    }

    


    void BindGrid()
    {
        string sortField = Grid1.SortField;
        string sortDirection = Grid1.SortDirection;
        string strSQL = @"Select * From tblBank   Where BankID <> '' ";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (BankID Like '%" + this.txtSearch.Text + "%' or BankName like '%" + this.txtSearch.Text + "%')";
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
            this.BankID.Text = keys[0].ToString();
            this.BankID.Readonly = true;
            this.BankName.Text = keys[1].ToString();
            
        }
        if (e.CommandName == "Action2")
        {
            
            string strSQL = string.Empty;
            strSQL = @"Delete  tblBank  Where BankID = '" + keys[0].ToString() + "'";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {   
                BindGrid();
                FineUIPro.Alert.Show("删除成功");
            }

        }
    }
    protected void Grid1_PageIndexChange(object sender, FineUIPro.GridPageEventArgs e)
    {
        Grid1.PageIndex = e.NewPageIndex;
        BindGrid();
    }
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
       
        ClearFormData();       
        
        this.Window1.Hidden = false;
    }

    protected void ClearFormData()
    {
        this.BankName.Text = "";
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        if (this.Window1.Title == "新增")
        {
            if (CheckMemberClassID(this.BankID.Text) == true)
            {
                FineUIPro.Alert.Show("ID 重覆");
            }
            else
            { 
                strSQL = "Insert Into tblBank (BankID ,BankName ) Values ('" + this.BankID.Text + "','" + this.BankName.Text + "')";
                if (DB.getObject().Execute(strSQL, null, false).Success == true)
                {
                    FineUIPro.Alert.Show("新增成功");
                    this.Window1.Hidden = true;
                }
                else
                {
                    FineUIPro.Alert.Show(strSQL);
                }
            }
        }
        if (this.Window1.Title == "更改")
        {
            strSQL = "Update tblBank  Set BankName = '" + this.BankName.Text + "' Where BankID ='" + this.BankID.Text + "'";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {
                FineUIPro.Alert.Show("更改成功");
                this.Window1.Hidden = true;
            }
        }
        BindGrid();

        //FineUIPro.Alert.Show(strSQL);
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        this.txtSearch.Text = "";
        
        BindGrid();
    }

    #region "Check"
    protected bool CheckMemberClassID(string MemberClassID)
    {
        bool args = false;
        string strSQL = "Select * from tblMemberClass  Where MemberClassID='" + MemberClassID + "'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            args = true;
        }
        return args;
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
}