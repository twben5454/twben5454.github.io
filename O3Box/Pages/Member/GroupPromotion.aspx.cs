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

public partial class GroupPromotion : System.Web.UI.Page
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
        string strSQL = @"select 
	                        a.lvl , a.MemberName ,b.*
                        From tblMember a
                        Left join tblMemberPromotion b on a.MemberID =b.MemberID 
                        Left join tblMemberClass c on b.SourceMemberClassID = c.MemberClassID
                        Left join tblMemberClass d on b.TargetMemberClassID = d.MemberClassID
                        Where a.UpGroup like '%' +'" + Request.QueryString["id"].ToString() +  "' + '%'";
        
        
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

    /// <summary>
    /// 模拟数据库分页（实际项目中请直接使用SQL语句返回分页数据！）
    /// </summary>
    /// <returns></returns>
    private DataTable GetPagedDataTable(DataTable dt, int pageIndex, int pageSize)
    {


        DataTable paged = dt.Clone();

        int rowbegin = pageIndex * pageSize;
        int rowend = (pageIndex + 1) * pageSize;
        if (rowend > dt.Rows.Count)
        {
            rowend = dt.Rows.Count;
        }

        for (int i = rowbegin; i < rowend; i++)
        {
            paged.ImportRow(dt.Rows[i]);
        }

        return paged;
    }

    #region "Grid 操作"
    //事件
    protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        
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
        FineUIPro.PageContext.Redirect("MemberJoin.aspx");
    }

    

   

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        

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