using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class Brand : System.Web.UI.Page
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
        string strSQL = @"Select * From tblBrand Where BrandID <> '' ";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (BrandID Like '%" + this.txtSearch.Text + "%' or BrandName like '%" + this.txtSearch.Text + "%')";
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
            FineUIPro.Alert.Show("查无资料！！");
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
            
            this.BrandID.Text = keys[0].ToString();
            this.BrandName.Text = keys[1].ToString();
            this.imgPhoto.ImageUrl = "~/upload/" + keys[2].ToString();
            this.Memo.Text = keys[4].ToString();

        }
        if (e.CommandName == "Action2")
        {
            string IsUse = keys[3].ToString();
            if (IsUse == "True") { IsUse = "False"; }
            else { IsUse = "True"; }
            string strSQL = string.Empty;
            strSQL = @"Update   tblBrand Set IsUse = '" + IsUse + "'  Where BrandID = '" + keys[0].ToString() + "'";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {   
                BindGrid();
                FineUIPro.Alert.Show("禁用成功");
                ///FineUIPro.Alert.Show(IsUse);
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
        this.BrandID.Text = "自动编号";
        this.BrandID.Readonly = true;
        ClearFormData();
        
        
        this.Window1.Hidden = false;
    }

    protected void ClearFormData()
    {
        this.BrandName.Text = "";
        this.imgPhoto.ImageUrl = "~/res/images/blank.png";
        this.Memo.Text =  "";

    }
    protected void filePhoto_FileSelected(object sender, EventArgs e)
    {
        if (filePhoto.HasFile)
        {
            string fileName = filePhoto.ShortFileName;

            if (fileName.Length == 0)
            {
                // 清空文件上传控件
                filePhoto.Reset();

                FineUIPro.Alert.Show("无效的文件类型！");
                return;
            }

            string fileext = System.IO.Path.GetExtension(fileName);
            //fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
            fileName = DateTime.Now.Ticks.ToString() + fileext;

            filePhoto.SaveAs(Server.MapPath("~/upload/" + fileName));

            imgPhoto.ImageUrl = "~/upload/" + fileName;
            imgPhoto.Width = 325;
            imgPhoto.Height = 225;

            // 清空文件上传组件（上传后要记着清空，否则点击提交表单时会再次上传！！）
            filePhoto.Reset();
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        if (this.Window1.Title == "新增")
        {
            strSQL = @"Insert Into tblBrand(  
                        BrandName,BrandImage,Memo,Created) 
                        Values  
                        ('" + BrandName.Text + @"',
                        '" + imgPhoto.ImageUrl.Replace("~/upload/", "") + @"',
                        '" + Memo.Text + @"',
                        '" + DB.getObject().GetCreated(this) + @"' )";
                
                if (DB.getObject().Execute(strSQL, null, false).Success == true)
                {
                    FineUIPro.Alert.Show("新增成功");
                    this.Window1.Hidden = true;
                    BindGrid();
                }
           
        }
        if (this.Window1.Title == "更改")
        {
            strSQL = @"Update tblBrand  Set 
                        BrandName='" + BrandName.Text + @"',
                        BrandImage='" + imgPhoto.ImageUrl.Replace("~/upload/", "") + @"',
                        Memo='" + Memo.Text + @"',
                        Updated='" + DB.getObject().GetCreated(this) + @"'
                        Where BrandID ='" + this.BrandID.Text +  "'";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {
                FineUIPro.Alert.Show("更改成功");
                this.Window1.Hidden = true;
                BindGrid();
            }
        }
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