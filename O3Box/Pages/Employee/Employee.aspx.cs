using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class Employee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FillHosDropDownList();
            //this.SDate.Text = DateTime.Today.AddMonths(-3).ToString("yyyy-MM-dd");
            DB.FillFineUIDropDownList(this.DropDownList1, "Select DepartName ,DepartID From tblDepartMent Where LinkDepartID ='0' ", "");
            DB.FillFineUIDropDownList(this.DropDownList2, "Select DepartName ,DepartID From tblDepartMent Where LinkDepartID ='" + this.DropDownList1.SelectedValue + "' ", "");
            DB.FillFineUIDropDownList(this.DropDownList3, "Select ClassName ,ClassNo From tblClass Where ClassType ='检查人员类型' ", "");
            BindGrid();
        }
    }

    


    void BindGrid()
    {
        string sortField = Grid1.SortField;
        string sortDirection = Grid1.SortDirection;
        string strSQL = @"Select a.* ,b.DepartName ,c.DepartName as SubDepartName ,d.ClassName 
                            From tblEmployee a
                            Left join tblDepartMent b on a.DepartMentID = b.DepartID 
                            Left join tblDepartMent c on a.DepartMentID2 = c.DepartID 
							Left join tblClass d on a.EmployeeType = d.ClassNo and d.ClassType ='检查人员类型'
                            Where EmployeeID <> '' ";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (EmployeeID Like '%" + this.txtSearch.Text + "%' or EmployeeName like '%" + this.txtSearch.Text + "%')";
        }
        if (this.DropDownList1.SelectedValue != "")
        {
            strSQL += " and DepartMentID = '" + this.DropDownList1.SelectedValue + "'";
        }
        if (this.DropDownList2.SelectedValue != "")
        {
            strSQL += " and DepartMentID2 = '" + this.DropDownList2.SelectedValue + "'";
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
            this.txtID.Text = keys[0].ToString();
            this.txtEmployeeName.Text = keys[1].ToString();
            this.txtIDNo.Text = keys[2].ToString();
            this.txtEnforceNo.Text = keys[3].ToString();
            this.txtCellPhone.Text = keys[4].ToString();
            DB.FillFineUIDropDownList(this.txtDepartMentID, "Select DepartName ,DepartID From tblDepartMent Where LinkDepartID ='0' ", keys[5].ToString());
            DB.FillFineUIDropDownList(this.txtDepartMentID2, "Select DepartName ,DepartID From tblDepartMent Where LinkDepartID ='" + this.DropDownList1.SelectedValue + "' ", keys[6].ToString());
            DB.FillFineUIDropDownList(this.txtEmployeeType, "Select ClassName ,ClassNo From tblClass Where ClassType ='检查人员类型' ", keys[8].ToString());
            this.btnSubmit.Text = "更改";
            this.Window1.Title = "更改";
        }
        if (e.CommandName == "Action2")
        {
            string strSQL = string.Empty;
            strSQL = @"Delete  tblEmployee Where EmployeeID = '" + keys[0].ToString() + "'";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {   
                BindGrid();
                FineUIPro.Alert.Show("删除成功");
            }

        }
        if (e.CommandName == "Action4")
        {
            this.Window2.Hidden = false;
            this.Window2.Title = keys[1].ToString() + "-负责检查项目";
            this.Window2.IFrameUrl = "EmployeeLink.aspx?id=" + keys[0].ToString();
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

        DB.FillFineUIDropDownList(this.txtDepartMentID, "Select DepartName ,DepartID From tblDepartMent Where LinkDepartID ='0' ", "");
        DB.FillFineUIDropDownList(this.txtDepartMentID2, "Select DepartName ,DepartID From tblDepartMent Where LinkDepartID ='" + this.DropDownList1.SelectedValue + "' ", "");
        DB.FillFineUIDropDownList(this.txtEmployeeType, "Select ClassName ,ClassNo From tblClass Where ClassType ='检查人员类型' ", "");
        this.Window1.Hidden = false;
    }

    protected void ClearFormData()
    {
        this.txtID.Text = "";
        txtEmployeeName.Text = "";
        txtIDNo.Text = "";
        txtEnforceNo.Text = "";
        txtCellPhone.Text = "";

        DB.FillFineUIDropDownList(this.txtDepartMentID, "Select DepartName ,DepartID From tblDepartMent Where LinkDepartID ='0' ", "");
        DB.FillFineUIDropDownList(this.txtDepartMentID2, "Select DepartName ,DepartID From tblDepartMent Where LinkDepartID ='" + this.DropDownList1.SelectedValue + "' ", "");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        string AlertMsg = "更改成功";
        if (this.Window1.Title == "新增")
        {
            strSQL = @"Insert Into tblEmployee(  
                        EmployeeID,EmployeeName,IDNo,EnforceNo,CellPhone,DepartMentID,DepartMentID2 ,EmployeeType) 
                        Values ( 
                        '" + txtID.Text + @"',
                        '" + txtEmployeeName.Text + @"',
                        '" + txtIDNo.Text + @"',
                        '" + txtEnforceNo.Text + @"',
                        '" + txtCellPhone.Text + @"',
                        '" + txtDepartMentID.SelectedValue  + @"',
                        '" + txtDepartMentID2.SelectedValue  + @"',
                        '" + txtEmployeeType.SelectedValue + @"') ";
            AlertMsg = "新增成功";
        }
        else
        {
            strSQL = @"Update tblEmployee  Set 
                        EmployeeName='" +  txtEmployeeName.Text  + @"', 
                        IDNo= '" + txtIDNo.Text + @"', 
                        EnforceNo = '" + txtEnforceNo.Text + @"', 
                        CellPhone = '" + txtCellPhone.Text + @"', 
                        DepartMentID = '" + txtDepartMentID.SelectedValue + @"', 
                        DepartMentID2 = '" + txtDepartMentID2.SelectedValue + @"', 
                        EmployeeType = '" + txtEmployeeType.SelectedValue + @"'
                        Where EmployeeID = '" + txtID.Text + @"' ";
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

    protected void txtDepartMentID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DB.FillFineUIDropDownList(this.txtDepartMentID2, "Select DepartName ,DepartID From tblDepartMent Where LinkDepartID ='" + this.txtDepartMentID.SelectedValue + "' ", "");
    }
}