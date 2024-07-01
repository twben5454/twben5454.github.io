using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class QA : System.Web.UI.Page
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
        string strSQL = @"Select * From tblQA   Where QAID <> '' ";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (QAID Like '%" + this.txtSearch.Text + "%' or QAAsk like '%" + this.txtSearch.Text + "%')";
        }
        

        strSQL += " Order by QAID Desc ";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
        Grid1.RecordCount = dt.Rows.Count;

        // 2.获取当前分页数据
        DataTable table =DB.getObject().GetPagedDataTable(dt, Grid1.PageIndex, Grid1.PageSize);

        // 3.绑定到Grid
        Grid1.DataSource = table;
        Grid1.DataBind();

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
            this.QAID.Text = keys[0].ToString();
            this.QAID.Readonly = true;
            this.QAAsk.Text = keys[1].ToString();
            this.QAAnswer.Text = keys[2].ToString();
            DB.FillFineUIDropDownList(this.QAClassID, "Select QAClassName ,QAClassID From tblQAClass Where IsUse='True'", keys[3].ToString());
        }
        if (e.CommandName == "Action2")
        {
            string IsUse = keys[4].ToString();
            if (IsUse == "True") { IsUse = "False"; }
            else { IsUse = "True"; }
            string strSQL = string.Empty;
            strSQL = @"Update   tblQA Set IsUse = '" + IsUse + "',Updated = '" + DB.getObject().GetCreated(this) + "'  Where QAID = '" + keys[0].ToString() + "'";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {   
                BindGrid();
                FineUIPro.Alert.Show("删除成功");
            }
           

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
        DB.FillFineUIDropDownList(this.QAClassID, "Select QAClassName,QAClassID From tblQAClass Where IsUse ='True'", "");
        ClearFormData();
        
        this.QAID.Text = "自动编号";
        this.QAID.Readonly = true;
        this.Window1.Hidden = false;
    }

    protected void ClearFormData()
    {
        
        this.QAAsk.Text = "";
        this.QAAnswer.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        if (this.Window1.Title == "新增")
        {
            strSQL = "Insert Into tblQA (QAClassID ,QAAsk ,QAAnswer,Created) Values ('" + this.QAClassID.SelectedValue  + "','" + this.QAAsk.Text + "','" + this.QAAnswer.Text + "','" + DB.getObject().GetCreated(this) + "')";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {
                FineUIPro.Alert.Show("新增成功");
            }
        }
        if (this.Window1.Title == "更改")
        {
            strSQL = "Update tblQA  Set QAAnswer = '" + this.QAAnswer.Text + "',QAAsk = '" + this.QAAsk.Text + "',QAClassID='" + this.QAClassID.SelectedValue + "',Updated='" + DB.getObject().GetCreated(this) + "' Where QAID ='" + this.QAID.Text + "'";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {
                FineUIPro.Alert.Show("更改成功");
            }
        }
        this.Window1.Hidden = true;
        BindGrid();
        //FineUIPro.Alert.Show(strSQL);
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        this.txtSearch.Text = "";
        
        BindGrid();
    }

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
                    // 处理CheckBox
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

                    // 处理图片
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
    /// 获取控件渲染后的HTML源代码
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
}