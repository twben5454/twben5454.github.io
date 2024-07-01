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

public partial class Member : System.Web.UI.Page
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
        string strSQL = @" DECLARE @PageIndex INT = 1, @PageSize INT = 25
                            Select 
	                            a.*  ,(Select Count(*) From tblMember b Where b.UpMemberID = a.MemberID) as DownCount ,'(' + b.MemberClassID + ')' + b.MemberClassName as MemberClassName ,[dbo].[fn_GetSubMemberClassIDCount](a.MemberID) as SubMemberCount ,dbo.fn_GetMemberAmount(MemberID ,'" + DateTime.Now.ToString("yyyyMM") + @"',2) as GroupAmount
                            From tblMember a
                            Left join tblMemberClass b on a.MemberClassID = b.MemberClassID
                            Where a.MemberID <> '' ";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (a.MemberID Like '%" + this.txtSearch.Text + "%' or a.MemberName like '%" + this.txtSearch.Text + "%' or a.CellPhone like '%" + this.txtSearch.Text + "%')";
        }
        strSQL += " Order by " + Grid1.SortField + " " + Grid1.SortDirection ;
        
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        Grid1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count > 0)
        {
            DataView view1 = dt.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
            DataTable table = GetPagedDataTable( dt ,Grid1.PageIndex, Grid1.PageSize);
            Grid1.DataSource = table;
            Grid1.DataBind();
        }
        else
        {
            FineUIPro.Alert.Show("查無資料！！");
        }



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
        if (e.CommandName == "Action1")
        {
            this.Window1.Hidden = false;
            ClearFormData();
            this.Window1.Title = "更改";
            this.MemberID.Text = keys[0].ToString();
            
            string strSQL = @"Select * From tblMember Where MemberID = @MemberID ";
            ArrayList Params = new ArrayList();
            Params.Add(new SqlParameter("@MemberID", keys[0].ToString()));
            DataTable dt = DB.getObject().GetData(strSQL, Params, false).ReturnDataTable;
            if (dt.Rows.Count > 0)
            {
               
                this.MemberName.Text  = dt.Rows[0]["MemberName"].ToString();
                DB.FillFineUIDropDownList(this.MemberClassID, "Select MemberClassName,MemberClassID From tblMemberClass", dt.Rows[0]["MemberClassID"].ToString());
                //this.UpMemberID.Text = dt.Rows[0]["UpMemberID"].ToString();
                this.Birthday.Text = dt.Rows[0]["Birthday"].ToString();
                this.Address.Text = dt.Rows[0]["Address"].ToString();
                this.Zip.Text = dt.Rows[0]["Zip"].ToString();
                this.JoinDate.Text = dt.Rows[0]["JoinDate"].ToString();
                this.Email.Text = dt.Rows[0]["Email"].ToString();
                this.MemberUrl.Text = dt.Rows[0]["MemberUrl"].ToString();
            }
        }
        if (e.CommandName == "Action2")
        {
            string strSQL = string.Empty;
            strSQL = @"Delete tblMember Where MemberID = '" + keys[0].ToString() + "'";

            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {
                BindGrid();
                FineUIPro.Alert.Show("更改成功");
            }
            // FineUIPro.Alert.Show(keys[5].ToString());
        }
        if (e.CommandName == "Action3")
        {
            string NewPassword = DateTime.Now.ToString("ffff");
            string strSQL = string.Empty;
            strSQL = @"Update   tblMember Set MemberPassword = '" + NewPassword + "'  Where MemberID = '" + keys[0].ToString() + "'";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {
                BindGrid();
                FineUIPro.Alert.Show("新密码为：" + NewPassword);
            }

        }
        if (e.CommandName == "Action4")
        {
            //this.Window2.Hidden = false;
            //this.Window2.IFrameUrl = "MemberTree.aspx?id=" + keys[0].ToString();
            //this.Window2.Title = keys[0].ToString()+ "-" + keys[1].ToString() +"組織圖";
            FineUIPro.PageContext.Redirect("MemberDetail.aspx?id=" + keys[0].ToString());
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
        FineUIPro.PageContext.Redirect("MemberJoin.aspx");
    }

    protected void ClearFormData()
    {
        DB.FillFineUIDropDownList(this.MemberClassID, "Select MemberClassName,MemberClassID From tblMemberClass", "");
        this.MemberName.Text = "";
        this.JoinDate.Text = "";
        this.Email.Text = "";
        this.Birthday.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@MemberID", MemberID.Text ));
        Params.Add(new SqlParameter("@MemberName", MemberName.Text));
        Params.Add(new SqlParameter("@Birthday", Birthday.Text));
        Params.Add(new SqlParameter("@Address", Address.Text));
        Params.Add(new SqlParameter("@Zip", Zip.Text));
        Params.Add(new SqlParameter("@Email", Email.Text));
        Params.Add(new SqlParameter("@MemberUrl", MemberUrl.Text));
        if (this.Window1.Title == "新增")
        {
            strSQL = @"Insert Into tblMember( MemberID,MemberName,UpMemberID,MemberClassID,Birthday,Address,Zip,JoinDate,Email, MemberUrl,Created)
                       Values (@MemberID,@MemberName,@UpMemberID,@MemberClassID,@Birthday,@Address,@Zip,@JoinDate,@Email,@MemberUrl,@Created) ";
            Params.Add(new SqlParameter("@MemberClassID", MemberClassID.SelectedValue ));
            Params.Add(new SqlParameter("@UpMemberID", ""));
            Params.Add(new SqlParameter("@JoinDate", DateTime.Today.ToString("yyyy-MM-dd")));
            Params.Add(new SqlParameter("@Created", HttpContext.Current.Request.Cookies["LoginUserID"].Value + "/" + DB.getObject().GetClientIP(this) + "/" + DB.getObject().GetNowString()));
            if (DB.getObject().Execute(strSQL, Params, false).Success == true)
            {
                FineUIPro.Alert.Show("新增成功");
            }

        }
        if (this.Window1.Title == "更改")
        {
            strSQL = @"Update tblMember Set
                        MemberName = @MemberName,
                        Birthday = @Birthday,
                        Address = @Address,
                        Zip = @Zip,
                        Email = @Email,
                        MemberUrl = @MemberUrl,
                        Updated = @Updated
                        Where MemberID = @MemberID ";
            Params.Add(new SqlParameter("@Updated", HttpContext.Current.Request.Cookies["LoginUserID"].Value + "/" + DB.getObject().GetClientIP(this) + "/" + DB.getObject().GetNowString()));
            if (DB.getObject().Execute(strSQL, Params, false).Success == true)
            {
                FineUIPro.Alert.Show("更改成功");
            }
        }
        this.Window1.Hidden = true;
        BindGrid();
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