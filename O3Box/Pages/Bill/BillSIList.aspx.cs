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

public partial class BillSIList : System.Web.UI.Page
{
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    #region "Grid 操作"

    void BindGrid()
    {
        string sortField = Grid1.SortField;
        string sortDirection = Grid1.SortDirection;
        string strSQL = @"SELECT * FROM tblBillM where billno <> ''";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (id Like N'%" + this.txtSearch.Text + "%' or name Like N'%" + this.txtSearch.Text + "%')";
        }


        dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        Grid1.RecordCount = dt.Rows.Count;
        DataView view1 = dt.DefaultView;
        view1.Sort = String.Format("{0} {1}", sortField, sortDirection);

        Grid1.DataSource = view1;
        Grid1.DataBind();
        //FineUIPro.Alert.Show(strSQL);
    }
    //事件
    protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        if (e.CommandName == "Action1")
        {
            this.Window1.Hidden = false;
            ClearFormData();
            string strSQL = "Select * From tblProduct   Where PID ='" + keys[0].ToString() + "'";
            DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
            this.PID.Text = dt.Rows[0]["PID"].ToString();
            this.PName.Text = dt.Rows[0]["PName"].ToString();
            

            this.btnSubmit.Text = "更改";
            this.Window1.Title = "更改";
        }
        if (e.CommandName == "Action2")
        {
            string strSQL = string.Empty;
            strSQL = @"Delete tblProduct Where PID = '" + keys[0].ToString() + "'";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {   
                BindGrid();
                FineUIPro.Alert.Show("删除成功");
            }

        }
    }

    protected void Grid1_RowDoubleClick(object sender, FineUIPro.GridRowClickEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        this.Window1.Hidden = false;
        ClearFormData();
        string strSQL = "Select * From tblProduct   Where PID ='" + keys[0].ToString() + "'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        this.PID.Text = dt.Rows[0]["PID"].ToString();
        this.PID.Readonly = true;
        this.PName.Text = dt.Rows[0]["PName"].ToString();
        this.PriceA.Text = dt.Rows[0]["PriceA"].ToString();
        this.PriceB.Text = dt.Rows[0]["PriceB"].ToString();
        this.PriceC.Text = dt.Rows[0]["PriceC"].ToString();
        this.PriceD.Text = dt.Rows[0]["PriceD"].ToString();
        this.PriceE.Text = dt.Rows[0]["PriceE"].ToString();
        this.Cost.Text = dt.Rows[0]["Cost"].ToString();
        this.Spec.Text = dt.Rows[0]["Spec"].ToString();

        this.btnSubmit.Text  = "更改";
    }
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

    #region"Button"
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //this.Window1.Hidden = false;
        //this.Window1.Title = "新增";
        //this.btnSubmit.Text = "新增";

        //this.PID.Readonly = false;
        //ClearFormData();
        FineUIPro.PageContext.Redirect("BillPODetail.aspx");
    }

    protected void ClearFormData()
    {
        this.PID.Text = "";
        this.PName.Text = "";
        this.PriceA.Text = "";
        this.PriceB.Text = "";
        this.PriceC.Text = "";
        this.PriceD.Text = "";
        this.PriceE.Text = "";
        this.Cost.Text = "";
        this.Spec.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string strSQL = string.Empty;
        string AlertMsg = "更改成功";
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@PID", PID.Text));
        Params.Add(new SqlParameter("@PName", PName.Text));
        Params.Add(new SqlParameter("@PriceA", PriceA.Text));
        Params.Add(new SqlParameter("@PriceB", PriceB.Text));
        Params.Add(new SqlParameter("@PriceC", PriceC.Text));
        Params.Add(new SqlParameter("@PriceD", PriceD.Text));
        Params.Add(new SqlParameter("@PriceE", PriceE.Text));
        Params.Add(new SqlParameter("@Cost", Cost.Text));
        Params.Add(new SqlParameter("@Spec", Spec.Text));
        if (this.Window1.Title == "新增")
        {
            if (CheckGoodsNo(this.PID.Text) == true)
            {
                FineUIPro.Alert.Show("產品編號重覆!!");
            }
            else
            {
                strSQL = @"Insert Into tblProduct( PID,PName,PriceA,PriceB,PriceC,PriceD,PriceE,Cost,Spec,Created)
                            Values (@PID,@PName,@PriceA,@PriceB,@PriceC,@PriceE,@PriceE,@Cost,@Spec,@Created) ";
                Params.Add(new SqlParameter("@Created", ""));
                AlertMsg = "新增成功";
            }
        }
        else
        {
            strSQL = @"Update tblProduct Set
                                PName=@PName,
                                PriceA=@PriceA,
                                PriceB=@PriceB,
                                PriceC=@PriceC,
                                PriceD=@PriceD,
                                PriceE=@PriceE,
                                Cost=@Cost,
                                Spec=@Spec,
                                Updated=@Updated
                                Where PID = @PID ";
            Params.Add(new SqlParameter("@Updated", ""));
            AlertMsg = "更改成功";

        }
        if (DB.getObject().Execute(strSQL, Params, false).Success == true)
        {
            this.Window1.Hidden = true;
            BindGrid();
            FineUIPro.Alert.Show(AlertMsg);
        }
        else
        {
            FineUIPro.Alert.Show(strSQL);
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        this.txtSearch.Text = "";
        BindGrid();
    }
    #endregion

    #region "Check"
    protected bool CheckGoodsNo(string PID)
    {
        bool args = false;
        string strSQL = "Select * from tblProduct  Where PID='" + PID + "'";
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