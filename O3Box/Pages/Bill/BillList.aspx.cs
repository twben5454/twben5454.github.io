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
using FineUIPro;

public partial class BillList : System.Web.UI.Page
{
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["typ"] != null)
            {
                string  BillType = Request.QueryString["typ"].ToString();
                if (BillType == "SI")
                {
                    this.Grid1.Title = "進貨明細";
                }
                if (BillType == "IR")
                {
                    this.Grid1.Title = "進貨退回明細";
                }
                if (BillType == "ST")
                {
                    this.Grid1.Title = "調撥明細";
                }
                if (BillType == "AD")
                {
                    this.Grid1.Title = "調整明細";
                }
                if (BillType == "OT")
                {
                    this.Grid1.Title = "其他明細";
                }

            }
            BindGrid();
        }
    }

    #region "Grid 操作"

    void BindGrid()
    {
        string sortField = Grid1.SortField;
        string sortDirection = Grid1.SortDirection;
        string strSQL = @"SELECT * ,'" + this.Grid1.Title.Replace("明細", "")  + "' as BillTypeName  FROM tblBillM where StatusCode = 'Y' ";
        if (Request.QueryString["typ"] != null)
        {
            strSQL += " and BillType='" + Request.QueryString["typ"].ToString() + "'";
        }
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
        ChangeColumn();
    }

    protected void ChangeColumn()
    {
        GridColumn SourceID = Grid1.FindColumn("SourceID");
        GridColumn StockID = Grid1.FindColumn("StockID");
        GridColumn SourceNo = Grid1.FindColumn("SourceNo");
        GridColumn Amount = Grid1.FindColumn("Amount");
        GridColumn HopeDate = Grid1.FindColumn("HopeDate");
        GridColumn CloseDate = Grid1.FindColumn("CloseDate");
        if (Request.QueryString["typ"] != null)
        {
            string  BillType = Request.QueryString["typ"].ToString();
            if (BillType == "SI")
            {
                this.Grid1.Title = "進貨明細";
                SourceID.Hidden = false;
                SourceID.HeaderText = "供應商";
                StockID.Hidden = false;
                StockID.HeaderText = "入庫倉庫";
                //SourceNo.Hidden = true;
                Amount.Hidden = false ;
                HopeDate.Hidden = true;
                CloseDate.Hidden = true;
            }
            if (BillType == "IR")
            {
                this.Grid1.Title = "進貨退回明細";
                //SourceNo.Hidden = true;
            }
            if (BillType == "ST")
            {
                this.Grid1.Title = "調撥明細";
                SourceID.Hidden = false;                
                SourceID.HeaderText = "調撥來源倉庫";
                StockID.Hidden = false;
                StockID.HeaderText = "調撥目標倉庫";
                //SourceNo.Hidden = true;
                Amount.Hidden = true;
                HopeDate.Hidden = true;
                CloseDate.Hidden = true;
            }
            if (BillType == "AD")
            {
                this.Grid1.Title = "調整明細";
                SourceID.Hidden = true ;
                SourceID.HeaderText = "調撥來源倉庫";
                StockID.Hidden = false;
                StockID.HeaderText = "調整倉庫";
                //SourceNo.Hidden = true;
                Amount.Hidden = true;
                HopeDate.Hidden = true;
                CloseDate.Hidden = true;
            }
            if (BillType == "OT")
            {
                this.Grid1.Title = "其他明細";
                SourceID.Hidden = true;
                SourceID.HeaderText = "調撥來源倉庫";
                StockID.Hidden = false;
                StockID.HeaderText = "領用倉庫";
                SourceNo.Hidden = true;
                Amount.Hidden = true;
                HopeDate.Hidden = true;
                CloseDate.Hidden = true;
            }
        }
    }
    //事件
    protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        if (e.CommandName == "Action1")
        {
            this.Window1.Hidden = false;
            this.Window1.IFrameUrl = "VIewBillDetail.aspx?id=" + keys[0].ToString() + "&typ=" + Request.QueryString["typ"].ToString();
            if (Request.QueryString["typ"] != null)
            {
                string BillType = Request.QueryString["typ"].ToString();
                if (BillType == "SI")
                {
                    this.Window1.Title = "進貨明細-" + keys[0].ToString();
                }
                if (BillType == "IR")
                {
                    this.Window1.Title = "進貨退回明細-" + keys[0].ToString();
                }
                if (BillType == "ST")
                {
                    this.Window1.Title = "調撥明細-" + keys[0].ToString();
                }
                if (BillType == "AD")
                {
                    this.Window1.Title = "調整明細-" + keys[0].ToString();
                }
                if (BillType == "OT")
                {
                    this.Window1.Title = "其他明細-" + keys[0].ToString();
                }
            }
        }
        if (e.CommandName == "Action2")
        {
            string strSQL = string.Empty;
            strSQL = @" Update tblBillM Set 
                        StatusCode ='N' ,
                        EditUser='" + Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress()  + @"',
                        EditTime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")  + @"' 
                        Where BillNo = '" + keys[0].ToString() + "'";
            //進貨刪除 , 更改庫存
            string strSQLA = "Select * From tblBillD Where BillNo = '" + keys[0].ToString() + "'";
            DataTable dt = DB.getObject().GetData(strSQLA, null, false).ReturnDataTable;
            if (Request.QueryString["typ"].ToString() == "SI")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strSQL += @" exec spUpdateStockNum 
                        '" + dt.Rows[i]["PID"].ToString() + @"',
                        '" + (Convert.ToInt32(dt.Rows[i]["PNum"].ToString()) * -1 ).ToString() + @"',
                        '" + keys[1].ToString() + @"',
                        'SI'";
                }
            }
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {   
                BindGrid();
                FineUIPro.Alert.Show("删除成功");
            }

        }
    }

    protected void Grid1_RowDoubleClick(object sender, FineUIPro.GridRowClickEventArgs e)
    {
        
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
        this.Window1.Hidden = false;
        this.Window1.Title = "新增";
        //this.btnSubmit.Text = "新增";

        //this.PID.Readonly = false;
        ClearFormData();
        string BillType;
        if (Request.QueryString["typ"] != null)
        {
            BillType = Request.QueryString["typ"].ToString();
            FineUIPro.PageContext.Redirect("BillDetail.aspx?typ=" + Request.QueryString["typ"].ToString());

        }
    }

    protected void ClearFormData()
    {
       
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
    protected string GetColumnText(string SourceText ,string TextType)
    {
        string args = string.Empty;
        string BillType = Request.QueryString["typ"].ToString();
        if (BillType =="SI" & TextType == "SourceID")//供應商
        {
            args = GetVendorName(SourceText);
        }
        if (BillType == "ST" & TextType == "SourceID")//來源倉庫
        {
            args = GetStockName(SourceText);
        }
        if (BillType == "SI" & TextType == "StockID")//供應商
        {
            args = GetStockName(SourceText);
        }
        if (BillType == "ST" & TextType == "StockID")//來源倉庫
        {
            args = GetStockName(SourceText);
        }
        if (BillType == "AD" & TextType == "StockID")//來源倉庫
        {
            args = GetStockName(SourceText);
        }
        if (BillType == "OT" & TextType == "StockID")//來源倉庫
        {
            args = GetStockName(SourceText);
        }
        return args;
    }
    protected string GetStockName(string StockID)
    {
        string args = string.Empty;
        string strSQL = "Select StockName from tblStock  Where StockID='" + StockID + "'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            args = dt.Rows[0]["StockName"].ToString();
        }
        //FineUIPro.Alert.Show(strSQL);
        return args;
    }
    protected string GetVendorName(string VendorID)
    {
        string args = string.Empty;
        string strSQL = "Select VendorName from tblVendor  Where VendorID='" + VendorID + "'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            args = dt.Rows[0]["VendorName"].ToString();
        }
        //FineUIPro.Alert.Show(strSQL);
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