using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

public partial class BillSIDetailA : System.Web.UI.Page
{
    DataRow dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["dt"] = null;
            DB.FillFineUIDropDownList(this.SourceID , "select VendorName ,VendorID From tblVendor Where StatusCode='Y' ", "");
            DB.FillFineUIDropDownList(this.SourceNo, "select BillNo ,BillNo as BillNoValue From tblBillM  Where StatusCode='Y' and BillType ='PO' and IsClose ='False' ", "");
            DB.FillFineUIDropDownList(this.StockID, "select StockName ,StockID From tblStock Where StatusCode='Y' ", "");
            DB.FillFineUIDropDownList(this.PID, "select PName ,PID  from tblProduct Where StatusCode='Y' ", "");
            this.BillDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            if (Request.QueryString["id"] == null)
            {
                this.BillNo.Text = "自動編號";
                this.BillNo.Readonly = true;
                this.IsClose.Hidden = true;
                this.CloseDate.Hidden = true;
            }
        }
    }

    

    

    protected void drpProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSQL = @"SELECT Price From tblProduct Where Pid='" + this.PID.SelectedValue + "'";
        DataTable  dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            this.Price.Text = dt.Rows[0]["Price"].ToString();          
            
        }
    }


    

    private void createTable()
    {
        if (Session["dt"] == null)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[8] {
            new DataColumn("PID", typeof(string)),
            new DataColumn("PName", typeof(string)),
            new DataColumn("PNum", typeof(int)),
            new DataColumn("Price", typeof(double)),
            new DataColumn("Amount", typeof(double)),
            new DataColumn("Memo", typeof(string)),
            new DataColumn("PONum", typeof(string)),
            new DataColumn("POPrice", typeof(string))});
            Session["dt"] = dt;
        }
    }


    //新增產品
    protected void btnAddSub_Click(object sender, EventArgs e)
    {
        string strError = string.Empty;
        if (this.PID.SelectedValue == "") { strError += "未選擇商品"; }
        if (strError.Length > 0)
        {
            FineUIPro.Alert.Show(strError);
        }
        else
        {
            createTable();
            DataTable dt = (DataTable)Session["dt"];
            DataRow[] rows = dt.Select("PID = '" + this.PID.SelectedValue + "'");
            if (rows.Length > 0)
            {
                rows[0][2] = Convert.ToInt32(rows[0][2].ToString()) + Convert.ToInt32(this.PNum.Text);
                rows[0][4] = Convert.ToInt32(rows[0][2].ToString()) * Convert.ToInt32(rows[0][3].ToString());
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = this.PID.SelectedValue;
                dr[1] = this.PID.SelectedText;
                dr[2] =  this.PNum.Text;
                dr[3] = this.Price.Text;
                dr[4] = (Convert.ToInt32(this.Price.Text) * Convert.ToInt32(this.PNum.Text)).ToString();
                dt.Rows.Add(dr);
            }
            
            Session["dt"] = dt;
            FillGrid();
            ClearSub();
        }
    }
    //取消
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearSub();
    }

    private void ClearSub()
    {

        DB.FillFineUIDropDownList(this.PID, "select PName ,PID  from tblProduct Where StatusCode='Y' ", "");
        this.Price.Text = "";
        this.PNum.Text = "1";
    }



    protected void btnBack_Click(object sender, EventArgs e)
    {
        //FineUIPro.Alert.Show(GetNewNo("SI"));
        FineUIPro.PageContext.Redirect("BillSIList.aspx");
    }

    protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        if (e.CommandName == "Action1")
        {

            DataTable dt = (DataTable)Session["dt"];
            DataRow[] rows = dt.Select("PID = '" + keys[0].ToString() + "'");
            for (int i = 0; i < rows.Length; i++)
            {

                rows[i].Delete();
            }
            FillGrid();
        }
        if (e.CommandName == "Action2")
        {
            this.Window1.Hidden = false;
            this.PPID.Text = keys[0].ToString();
            this.PPName.Text = keys[1].ToString();
            this.PONum.Text = keys[2].ToString();
            this.POPrice.Text = keys[3].ToString();
            //FineUIPro.Alert.Show(keys[2].ToString());
        }

    }

    protected void FillGrid()
    {
        DataTable dt = (DataTable)Session["dt"];
        int TotalAmount = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            TotalAmount += Convert.ToInt32(dt.Rows[i]["Amount"].ToString());
        }
        Amount.Text = TotalAmount.ToString("0:N2");
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
       
    }
    //存檔
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Session["dt"] == null)
        {
            FineUIPro.Alert.Show("明細沒有項目");
            return;
        }
        string BillNo = GetNewNo("SI");

        //tblBillM , tblBillD
        string strSQL = @"Insert Into tblBillM(  BillNo,BillType,BillDate,Amount,SourceNo,SourceID,StockID,Memo,CreateTime,CreateUser,EditUser,EditTime,StatusCode) 
                            Values  ('" + BillNo + @"', 
                            '" + "SI" + @"', 
                            '" + BillDate.Text + @"', 
                            '" + Amount.Text + @"', 
                            '" + SourceNo.SelectedValue + @"', 
                            '" + SourceID.SelectedValue + @"', 
                            '" + StockID.SelectedValue + @"', 
                            '" + Memo.Text + @"', 
                            '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"', 
                            '" + Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress() + @"', 
                            '" + Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress() + @"', 
                            '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"', 
                            '" + "Y') ";

        DataTable dt = (DataTable)Session["dt"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            strSQL += @" Insert Into tblBillD(  BillNo,PID,PNum,Amount,CreateUser,CreateTime,EditUser,EditTIme,StatusCode) 
                        Values  ('" + BillNo + @"', 
                        '" + dt.Rows[i]["PID"].ToString() + @"', 
                        '" + dt.Rows[i]["PNum"].ToString() + @"', 
                        '" + dt.Rows[i]["Amount"].ToString() + @"', 
                            '" + Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress() + @"', 
                        '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"', 
                            '" + Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress() + @"', 
                        '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"', 
                            '" + "Y') ";
            if (DB.getObject().Execute(strSQL, null, false).Success == true)
            {
                FineUIPro.Alert.Show("新增成功");
                ClearSub();
            }
            //else
            //{
            //    FineUIPro.Alert.Show(strSQL);
            //}
        }
    }

    protected string GetNewNo(string BillType)
    {
        //FineUIPro.Alert.Show("SI20210426001".Substring(2, 11));
        string args = string.Empty;
        string strSQL = @"SELECT top 1 BillNo From tblBillM Where BillType ='" + BillType + "' and StatusCode ='Y' order by BillNo Desc";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            double  NewNo = Convert.ToDouble(dt.Rows[0][0].ToString().Substring(2,11)) + 1;
            args = BillType + NewNo.ToString();
        }
        else
        {
            args = BillType + DateTime.Now.ToString("yyyyMMdd") + "001";
        }
        return args;
    }

    protected void SourceNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.SourceNo.SelectedValue.Length == 0)
        {
            //this.Grid1.Items.Clear();
            Session["dt"] = null ;
            createTable();
            DataTable dt = (DataTable)Session["dt"];
            this.Grid1.DataSource = dt;
            this.Grid1.DataBind();
            this.Toolbar2.Hidden = false;
            FineUIPro.GridColumn SIColumn = Grid1.FindColumn("lbfAction2");
            SIColumn.Hidden = true;
            FineUIPro.GridColumn DelColumn = Grid1.FindColumn("lbfAction1");
            DelColumn.Hidden = false;
            FineUIPro.GridColumn SINum = Grid1.FindColumn("lbfSINum");
            SINum.Hidden = true ;
            DB.FillFineUIDropDownList(this.SourceID, "select VendorName ,VendorID From tblVendor Where StatusCode='Y' ", "");
        }
        else
        {
            Session["dt"] = null;
            createTable();
            DataTable dt = (DataTable)Session["dt"];
            string strSQL = "Select * ,dbo.GetPName(PID) as PName  From tblBillD Where BillNo ='" + this.SourceNo.SelectedValue + "'";
            DataTable Sourcedt = DB.getObject().GetData(strSQL).ReturnDataTable;
            for (int i = 0; i < Sourcedt.Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr["PID"] = Sourcedt.Rows[i]["PID"].ToString();
                dr["PName"] = Sourcedt.Rows[i]["PName"].ToString();
                dr["PONum"] = Sourcedt.Rows[i]["PNum"].ToString();
                dr["POPrice"] = Sourcedt.Rows[i]["Price"].ToString();
                dr[4] = (Convert.ToInt32(Sourcedt.Rows[i]["Price"].ToString()) * Convert.ToInt32(Sourcedt.Rows[i]["PNum"].ToString())).ToString();
                dt.Rows.Add(dr);
            }
            Session["dt"] = dt;
            FillGrid();
            this.Toolbar2.Hidden = true;
            FineUIPro.GridColumn SIColumn = Grid1.FindColumn("lbfAction2");
            SIColumn.Hidden = false ;
            FineUIPro.GridColumn DelColumn = Grid1.FindColumn("lbfAction1");
            DelColumn.Hidden = true;
            FineUIPro.GridColumn SINum = Grid1.FindColumn("lbfSINum");
            SINum.Hidden = false ;
            strSQL = "Select SourceID   From tblBillM Where BillNo ='" + this.SourceNo.SelectedValue + "'";
            dt = DB.getObject().GetData(strSQL).ReturnDataTable;
            DB.FillFineUIDropDownList(this.SourceID, "select VendorName ,VendorID From tblVendor Where StatusCode='Y' ", dt.Rows[0][0].ToString());
        }
    }

    protected void btnPSave_Click(object sender, EventArgs e)
    {

    }
}

   



