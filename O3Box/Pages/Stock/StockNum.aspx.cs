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

public partial class Sales : System.Web.UI.Page
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
        string strSQL = @"Select * From tblStock Where StatusCode='Y' ";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (StockID Like '%" + this.txtSearch.Text + "%' or StockName like '%" + this.txtSearch.Text + "%')";
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
            this.StockID.Text = keys[0].ToString();
            this.StockID.Readonly = true;
            this.StockName.Text = keys[1].ToString();
        }
        if (e.CommandName == "Action2")
        {
            string strSQL = string.Empty;
            strSQL = @"Update   tblStock Set StatusCode = 'N'  Where StockID = '" + keys[0].ToString() + "'";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {
                FineUIPro.Alert.Show("刪除成功");
                BindGrid();
            }

        }
    }
    //跳頁
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

        ClearFormData();
        this.StockID.Text = "";
        //this.StockID.Text = "自動編號";
        //this.StockID.Readonly = true;
        this.Window1.Hidden = false;
    }

    protected void ClearFormData()
    {
        this.StockName.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@StockID", StockID.Text ));
        Params.Add(new SqlParameter("@StockName", StockName.Text));
        if (this.Window1.Title == "新增")
        {
            strSQL = @"Insert Into tblStock(  StockID,StockName,CreateTime,CreateUser,EditTime,EditUser,StatusCode) 
                        Values  (@StockID,@StockName,@CreateTime,@CreateUser,@EditTime,@EditUser,@StatusCode) ";
            Params.Add(new SqlParameter("@CreateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            Params.Add(new SqlParameter("@CreateUser", Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress()));
            Params.Add(new SqlParameter("@EditTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            Params.Add(new SqlParameter("@EditUser", Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress()));
            Params.Add(new SqlParameter("@StatusCode", "Y"));
            if (DB.getObject().Execute(strSQL, Params, false).Success == true)
            {
                FineUIPro.Alert.Show("新增成功");
            }
        }
        if (this.Window1.Title == "更改")
        {
            strSQL = @"Update tblStock  Set 
                        StockName=@StockName,
                        EditTime=@EditTime,
                        EditUser=@EditUser
                        Where StockID = @StockID ";
            Params.Add(new SqlParameter("@EditTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            Params.Add(new SqlParameter("@EditUser", Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress()));
            if (DB.getObject().Execute(strSQL, Params, false).Success == true)
            {
                FineUIPro.Alert.Show("更改成功");
            }
        }
        this.Window1.Hidden = true;
        BindGrid();
        //FineUIPro.Alert.Show(strSQL);  執行 
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        this.txtSearch.Text = "";

        BindGrid();
    }

    #region "Excel"

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
                    // 處理CheckBox
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

                    // 處理圖片
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

    /// <summary>
    /// 獲取控制項渲染後的HTML源代碼
    /// </summary>
    /// <param name="ctrl"></param>
    /// <returns></returns>
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