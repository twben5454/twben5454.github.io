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

public partial class Vendor : System.Web.UI.Page
{
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginUserID"] == null)
        {
            FineUIPro.Alert.Show("請先登入 !!");
            //Response.Write("<script>parent.window.href='Login.aspx';</script>");
            return;
        }
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
        string strSQL = @"Select * From tblVendor Where StatusCode ='Y' ";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (CustomerID Like N'%" + this.txtSearch.Text + "%' or CustomerName Like N'%" + this.txtSearch.Text + "%') ";
        }
        strSQL += " Order by " + Grid1.SortField + " " + Grid1.SortDirection; 

        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        Grid1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count > 0)
        {
            DataView view1 = dt.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
            DataTable table = GetPagedDataTable(dt, Grid1.PageIndex, Grid1.PageSize);
            Grid1.DataSource = table;
            Grid1.DataBind();
        }
        else
        {
            FineUIPro.Alert.Show("查無資料！！");
        }
        //FineUIPro.Alert.Show(strSQL);
    }

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
    //事件
    protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        if (e.CommandName == "Action1")
        {
            this.btnDel.Hidden = false;
            this.Window1.Hidden = false;
            ClearFormData();
            string strSQL = "Select * From tblVendor   Where SID ='" + keys[0].ToString() + "'";
            DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
            if (dt.Rows.Count > 0)
            {
                SID.Text  = dt.Rows[0]["SID"].ToString();
                CustomerID.Text = dt.Rows[0]["VendorID"].ToString();
                CustomerName.Text = dt.Rows[0]["VendorName"].ToString();
                TaxAddress.Text = dt.Rows[0]["TaxAddress"].ToString();
                Address.Text = dt.Rows[0]["Address"].ToString();
                Tel.Text = dt.Rows[0]["Tel"].ToString();
                Fax.Text = dt.Rows[0]["Fax"].ToString();
                CellPhone.Text = dt.Rows[0]["CellPhone"].ToString();
                WebSite.Text = dt.Rows[0]["WebSite"].ToString();
                InvoiceTitle.Text = dt.Rows[0]["InvoiceTitle"].ToString();
                InvoiceNo.Text = dt.Rows[0]["InvoiceNo"].ToString();
                ContractName.Text = dt.Rows[0]["ContractName"].ToString();
                ContractTel.Text = dt.Rows[0]["ContractTel"].ToString();
                ContractCellPhone.Text = dt.Rows[0]["ContractCellPhone"].ToString();
                Memo.Text = dt.Rows[0]["Memo"].ToString();
            }


            this.btnSubmit.Text = "更改";
            this.Window1.Title = "更改";
        }
        if (e.CommandName == "Action2")
        {
            string strSQL = @"Update  tblVendor Set StatusCode ='N' Where SID = @SID";
            ArrayList Params = new ArrayList();
            Params.Add(new SqlParameter("@SID", keys[0].ToString()));
            DB.getObject().Execute(strSQL, Params, false);
            //FineUIPro.Alert.Show("刪除成功");
            FineUIPro.Notify notify = new FineUIPro.Notify();
            notify.Message = "刪除成功...";
            notify.DisplayMilliseconds = 2000;
            notify.ShowLoading = true;
            notify.PositionX = FineUIPro.Position.Center;
            notify.PositionY = FineUIPro.Position.Center;

            notify.Show();
            BindGrid();
        }

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
        this.btnSubmit.Text = "新增";
        this.SID.Text = "自動編號";
        btnDel.Hidden = true;
        ClearFormData();
    }

    protected void ClearFormData()
    {

        this.SID.Readonly = true;
       
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["LoginUserID"] == null)
        {
            FineUIPro.Alert.Show("請先登入 !!");
            //Response.Write("<script>parent.window.href='Login.aspx';</script>");
            return;
        }
        string strSQL = string.Empty;
        string AlertMsg = "更改成功";
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@VendorID", CustomerID.Text));
        Params.Add(new SqlParameter("@VendorName", CustomerName.Text));
        Params.Add(new SqlParameter("@TaxAddress", TaxAddress.Text));
        Params.Add(new SqlParameter("@Address", Address.Text));
        Params.Add(new SqlParameter("@Tel", Tel.Text));
        Params.Add(new SqlParameter("@Fax", Fax.Text));
        Params.Add(new SqlParameter("@CellPhone", CellPhone.Text));
        Params.Add(new SqlParameter("@WebSite", WebSite.Text));
        Params.Add(new SqlParameter("@InvoiceTitle", InvoiceTitle.Text));
        Params.Add(new SqlParameter("@InvoiceNo", InvoiceNo.Text));
        Params.Add(new SqlParameter("@ContractName", ContractName.Text));
        Params.Add(new SqlParameter("@ContractTel", ContractTel.Text));
        Params.Add(new SqlParameter("@ContractCellPhone", ContractCellPhone.Text));
        Params.Add(new SqlParameter("@Memo", Memo.Text));
        //FineUIPro.Alert.Show(Session["LoginUserID"].ToString());
        if (this.Window1.Title == "新增")
        {
             strSQL = @"Insert Into tblVendor(  VendorID,VendorName,TaxAddress,Address,Tel,Fax,CellPhone,WebSite,InvoiceTitle,InvoiceNo,ContractName,ContractTel,ContractCellPhone,Memo,CreateTime,CreateUser,EditTime,EditUser,StatusCode) 
                    Values  (@VendorID,@VendorName,@TaxAddress,@Address,@Tel,@Fax,@CellPhone,@WebSite,@InvoiceTitle,@InvoiceNo,@ContractName,@ContractTel,@ContractCellPhone,@Memo,@CreateTime,@CreateUser,@EditTime,@EditUser,@StatusCode) ";
            
            
            Params.Add(new SqlParameter("@CreateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            Params.Add(new SqlParameter("@CreateUser", Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress()));
            Params.Add(new SqlParameter("@EditTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            Params.Add(new SqlParameter("@EditUser", Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress()));
            Params.Add(new SqlParameter("@StatusCode", "Y"));
            AlertMsg = "新增成功";
        }
        else
        {
            strSQL = @"Update tblVendor  Set 
                        VendorID=@VendorID,
                        VendorName=@VendorName,
                        TaxAddress=@TaxAddress,
                        Address=@Address,
                        Tel=@Tel,
                        Fax=@Fax,
                        CellPhone=@CellPhone,
                        WebSite=@WebSite,
                        InvoiceTitle=@InvoiceTitle,
                        InvoiceNo=@InvoiceNo,
                        ContractName=@ContractName,
                        ContractTel=@ContractTel,
                        ContractCellPhone=@ContractCellPhone,
                        Memo=@Memo,
                        EditTime=@EditTime,
                        EditUser=@EditUser
                        Where SID = @SID ";

            Params.Add(new SqlParameter("@SID", SID.Text));
            Params.Add(new SqlParameter("@EditTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            Params.Add(new SqlParameter("@EditUser", Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress()));
            AlertMsg = "更改成功";

        }
        if (DB.getObject().Execute(strSQL, Params, false).Success == true)
        {
            this.Window1.Hidden = true;
            //FineUIPro.Alert.Show(AlertMsg);
            FineUIPro.Notify notify = new FineUIPro.Notify();
            notify.Message = AlertMsg;
            notify.DisplayMilliseconds = 2000;
            notify.ShowLoading = true;
            notify.PositionX = FineUIPro.Position.Center;
            notify.PositionY = FineUIPro.Position.Center;
            BindGrid();
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










    protected void btnDel_Click(object sender, EventArgs e)
    {
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@SID", SID.Text));
        string strSQL = @"Update tblVendor  Set 
                        StatusCode='N' 
                        Where SID = @SID ";
        string AlertMsg = "刪除成功";
        if (DB.getObject().Execute(strSQL, Params, false).Success == true)
        {
            this.Window1.Hidden = true;
            BindGrid();
            FineUIPro.Alert.Show(AlertMsg);
        }
    }
}