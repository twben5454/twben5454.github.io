using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DepartMentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FillHosDropDownList();
            //this.SDate.Text = DateTime.Today.AddMonths(-3).ToString("yyyy-MM-dd");
            BindGrid();
        }
    }

    private void FillHosDropDownList()
    {
        string strSQL = "Select HosID ,HosName From tblHospital Group by HosID ,HosName";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        this.DropDownList1.Items.Add("全部", "All");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            this.DropDownList1.Items.Add(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
        }
    }


    void BindGrid()
    {
        string sortField = Grid1.SortField;
        string sortDirection = Grid1.SortDirection;
        string strSQL = @"Select * From tblDepartMent";

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
            //this.Window1.Hidden = false;
            //this.Window1.IFrameUrl = "HtmlPagedDetail.html";
            ////this.TextBox1.Text = keys[2].ToString();
            ////this.TextBox2.Text = keys[1].ToString();
            //this.Window1.Title = keys[1].ToString();
            //string strSQL = @"Use " + this.DropDownList1.SelectedValue + @"
            //                  select *  From [dbo].[检验结果结果表] Where 唯一代号 = '" + keys[0].ToString() + "'";
            
            //DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
            //this.Grid2.DataSource = dt;
            //this.Grid2.DataBind();
            //this.Window1.Hidden = false;
        }
        if (e.CommandName == "actDetail")
        {
            Response.Redirect("SalonDetail.aspx?id=" + keys[0].ToString());
            //this.Window2.Title =  "会员编号-" + keys[0].ToString() ;
            //this.Window2.IFrameUrl = "MemberDetail.aspx?id=" + keys[0].ToString();
            ////this.Window2.GetMaximizeReference();
            //Window2.Hidden = false;

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
}