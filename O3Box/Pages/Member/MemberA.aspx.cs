using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class MemberA : System.Web.UI.Page
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
        string strSQL = @"Select a.* ,b.MemberClassName 
From tblMember a
Left join tblMemberClass b on a.MemberClassID = b.MemberClassID 
Where a.IsUse ='True' ";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (a.MemberName Like '%" + this.txtSearch.Text + "%' )";
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
            this.MemberID.Text = keys[0].ToString();
            this.MemberID.Readonly = true;
            this.MemberName.Text = keys[1].ToString();
            this.Birthday.Text = keys[3].ToString();
            this.Sex.SelectedValue = keys[4].ToString();
            this.JoinDate.Text = keys[5].ToString();
            this.Tel.Text = keys[6].ToString();
            this.Email.Text = keys[7].ToString();
            this.IsHaveCar.SelectedValue = keys[8].ToString();
            this.Address.Text = keys[10].ToString();
            DB.FillFineUIDropDownList(this.MemberClassID, "Select MemberClassName,MemberClassID From tblMemberClass Where IsUse='True'", keys[11].ToString());
            //FineUIPro.Alert.Show(keys[11].ToString());
            this.Married.SelectedValue = keys[14].ToString();
            this.UserState.SelectedValue = keys[17].ToString();
            this.CarType.Text = keys[20].ToString();
            this.Model.Text = keys[21].ToString();
            this.FirstUseDate.Text = keys[22].ToString();
            this.CarClass.SelectedValue = keys[23].ToString();
            this.LimitDate.Text = keys[24].ToString();
            this.CarNo.Text = keys[25].ToString();
        }
        if (e.CommandName == "Action2")
        {
            string strSQL = string.Empty;
            strSQL = @"Update   tblMember Set IsUse = 'False'  Where MemberID = '" + keys[0].ToString() + "'";
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
       
        ClearFormData();
        
        this.MemberID.Text = "自动编号";
        this.MemberID.Readonly = true;
        this.Window1.Hidden = false;
        
    }

    protected void ClearFormData()
    {
        this.MemberName.Text = "";
        this.Birthday.Text = "";
        //this.Sex.SelectedValue = "";
        this.JoinDate.Text = "";
        this.Tel.Text = "";
        this.Email.Text = "";
        this.IsHaveCar.SelectedValue = "";
        this.Address.Text = "";
        DB.FillFineUIDropDownList(this.MemberClassID, "Select MemberClassName,MemberClassID From tblMemberClass Where IsUse='True'", "");
        //this.Married.SelectedValue = "";
        //this.UserState.SelectedValue = "";
        this.CarType.Text = "";
        this.Model.Text = "";
        this.FirstUseDate.Text = "";
        //this.CarClass.SelectedValue = "";
        this.LimitDate.Text = "";
        this.CarNo.Text = "";

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        if (this.Window1.Title == "新增")
        {
            strSQL = @"Insert Into tblMember(  
                        MemberName,Birthday,Sex,JoinDate,Tel,Email,IsHaveCar,Address,MemberClassID,Married,UserState,CarType,Model,FirstUseDate,CarClass,LimitDate,CarNo) 
                        Values  
                        ('" + MemberName.Text + "','"+ Birthday.Text + "','" + Sex.SelectedValue + "','" + JoinDate.Text + "','" + Tel.Text + "','" + Email.Text + "','" + IsHaveCar.SelectedValue + "','" + Address.Text + "','" + MemberClassID.SelectedValue + "','" + Married.SelectedValue + "','" + UserState.SelectedValue + "','" + CarType.Text + "','" + Model.Text + "','" + FirstUseDate.Text + "','" + CarClass.SelectedValue + "','" + LimitDate.Text + "','" + CarNo.Text + "') ";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {
                FineUIPro.Alert.Show("新增成功");
            }
        }
        if (this.Window1.Title == "更改")
        {
            strSQL = "Update tblMember  Set MemberName = '" + this.MemberName.Text + "', Sex='" + this.Sex.SelectedValue + "', JoinDate='" + this.JoinDate.Text + "', Tel='" + this.Tel.Text + "', Email='" + this.Email.Text + "', IsHaveCar='" + this.IsHaveCar.SelectedValue + "', Address='" + this.Address.Text + "', MemberClassID='" + this.MemberClassID.SelectedValue + "', Married='" + this.Married.SelectedValue + "', UserState='" + this.UserState.SelectedValue + "', CarType='" + this.CarType.Text + "', Model='" + this.Model.Text + "', FirstUseDate='" + this.FirstUseDate.Text + "', CarClass='" + this.CarClass.SelectedValue + "', LimitDate='" + this.LimitDate.Text + "', CarNo='" + this.CarNo.Text + "' Where MemberID ='" + this.MemberID.Text + "'";
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

    protected void IsHaveCar_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.IsHaveCar.SelectedValue == "True")
        {
            this.FormRow10.Hidden = false;
            this.FormRow11.Hidden = false;
            this.FormRow12.Hidden = false;
            this.FormRow13.Hidden = false;
            this.FormRow14.Hidden = false;
            this.FormRow15.Hidden = false;
            this.FormRow16.Hidden = false;
        }
        else
        {
            this.FormRow10.Hidden = true;
            this.FormRow11.Hidden = true;
            this.FormRow12.Hidden = true;
            this.FormRow13.Hidden = true;
            this.FormRow14.Hidden = true;
            this.FormRow15.Hidden = true;
            this.FormRow16.Hidden = true;
        }
    }
}