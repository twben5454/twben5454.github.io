using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class DepartMent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FillHosDropDownList();
            //this.SDate.Text = DateTime.Today.AddMonths(-3).ToString("yyyy-MM-dd");
            DB.FillFineUIDropDownList(this.DropDownList1, "Select ClassName ,ClassNo From tblClass Where ClassType ='级别' ", "");
            DB.FillFineUIDropDownList(this.DropDownList2, "Select ClassName ,ClassNo From tblClass Where ClassType ='位置' ", "");
            DB.FillFineUIDropDownList(this.DropDownList3, "Select ClassName ,ClassNo From tblClass Where ClassType ='单位类型' ", "");
            BindGrid();
        }
    }

    


    void BindGrid()
    {
        string sortField = Grid1.SortField;
        string sortDirection = Grid1.SortDirection;
        string strSQL = @"Select 
	                            DepartID,
	                            DepartName,
	                            LinkDepartID,
	                            IsNull(DMLevel,'') as DMLevel ,
	                            b.ClassName as DMLevelName ,
	                            IsNull(DMLocation,'') as DMLocation,
	                            c.ClassName as DMLocationName ,
	                            IsNull(DMType,'') as DMType,
	                            d.ClassName as DMTypeName 
                            From tblDepartMent a
                            Left join tblClass b on a.DMLevel = b.ClassNo and b.ClassType='级别'
                            Left join tblClass c on a.DMLocation = c.ClassNo and c.ClassType='位置'
                            Left join tblClass d on a.DMType = d.ClassNo and d.ClassType='单位类型'
                            Where LinkDepartID =  '0'";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (DepartID Like '%" + this.txtSearch.Text + "%' or DepartName like '%" + this.txtSearch.Text + "%')";
        }
        if (this.DropDownList1.SelectedValue != "")
        {
            strSQL += " and DMLevel = '" + this.DropDownList1.SelectedValue + "'";
        }
        if (this.DropDownList2.SelectedValue != "")
        {
            strSQL += " and DMLocation = '" + this.DropDownList2.SelectedValue + "'";
        }
        if (this.DropDownList3.SelectedValue != "")
        {
            strSQL += " and DMType = '" + this.DropDownList3.SelectedValue + "'";
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
            this.txtID.Text = keys[0].ToString();
            this.txtName.Text = keys[1].ToString();
            this.btnSubmit.Text = "更改";
            this.Window1.Title = "更改";
            DB.FillFineUIDropDownList(this.dpDMLevel, "Select ClassName ,ClassNo From tblClass Where ClassType ='级别' ", keys[3].ToString());
            DB.FillFineUIDropDownList(this.dpDMLocation, "Select ClassName ,ClassNo From tblClass Where ClassType ='位置' ", keys[4].ToString());
            DB.FillFineUIDropDownList(this.dpDMType, "Select ClassName ,ClassNo From tblClass Where ClassType ='单位类型' ", keys[5].ToString());
        }
        if (e.CommandName == "Action2")
        {
            string strSQL = string.Empty;
            strSQL = @"Delete  tblDepartMent Where DepartID = '" + keys[0].ToString() + "'";
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
        this.btnSubmit.Text = "新增";
        ClearFormData();
        DB.FillFineUIDropDownList(this.dpDMLevel, "Select ClassName ,ClassNo From tblClass Where ClassType ='级别' ", "");
        DB.FillFineUIDropDownList(this.dpDMLocation, "Select ClassName ,ClassNo From tblClass Where ClassType ='位置' ", "");
        DB.FillFineUIDropDownList(this.dpDMType, "Select ClassName ,ClassNo From tblClass Where ClassType ='单位类型' ", "");
        this.Window1.Hidden = false;
    }

    protected void ClearFormData()
    {
        this.txtID.Text = "";
        this.txtName.Text = "";
        dpDMLevel.SelectedValue = "";
        dpDMLocation.SelectedValue = "";
        dpDMType.SelectedValue = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        string AlertMsg = "更改成功";
        if (this.Window1.Title == "新增")
        {
            strSQL = @"Insert Into tblDepartMent(  
                        DepartID,DepartName,DMLevel,DMLocation,DMType) 
                        Values ( 
                        '" + txtID.Text + @"',
                        '" + txtName.Text + @"',
                        '" + dpDMLevel.SelectedValue + @"',
                        '" + dpDMLocation.SelectedValue + @"',
                        '" + dpDMType.SelectedValue + @"') ";
            AlertMsg = "新增成功";
        }
        else
        {
            strSQL = @"Update tblDepartMent  Set 
                        DepartID= '" + txtID.Text + @"', 
                        DepartName=  '" + txtName.Text + @"' , 
                        DMLevel = '" + dpDMLevel.SelectedValue  + @"', 
                        DMLocation = '" + dpDMLocation.SelectedValue + @"' , 
                        DMType = '" + dpDMType.SelectedValue + @"'
                       Where DepartID = '" + txtID.Text + @"'";
        }
        if (DB.getObject().Execute(strSQL ,null ,false ).Success == true)
        {
            this.Window1.Hidden = true;
            BindGrid();
            FineUIPro.Alert.Show(AlertMsg);
        }
        //FineUIPro.Alert.Show(strSQL);
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        this.txtSearch.Text = "";
        this.DropDownList1.SelectedValue = "";
        this.DropDownList2.SelectedValue = "";
        this.DropDownList3.SelectedValue = "";
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