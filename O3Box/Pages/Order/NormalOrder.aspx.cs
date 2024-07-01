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
using System.Collections.Specialized;

public partial class NormalOrder : System.Web.UI.Page
{
    DataTable Cart = new DataTable();
    DataRow dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginUserID"] == null)
        {
            FineUIPro.Alert.Show("請先登入!!");
            return;
        }
        
        if (!IsPostBack)
        {
            Session["ShopingCart"] = null;
            DB.FillFineUIDropDownList(this.PID, "Select PName ,PID From tblProduct", "");
            DB.FillFineUIRadioButtonList(this.PayType, "Select ClassName ,ClassID  From tblClass Where LinkID='PayType' and StatusCode='Y'", "1");
            DB.FillFineUIDropDownList (this.AreaID , "Select AreaName ,AreaID  From tblArea Where StatusCode ='Y'" , "");
            DB.FillFineUIDropDownList(this.StockID, "Select StockName ,StockID  From tblStock Where StatusCode ='Y'", "");
            HttpCookie cookieAreaID = Request.Cookies["AreaID"];
            HttpCookie cookieStockID = Request.Cookies["StockID"];
            if (cookieAreaID != null)
            {
                this.AreaID.SelectedValue = cookieAreaID.Value ;
            }
            if (cookieStockID != null)
            {
                this.StockID.SelectedValue = cookieStockID.Value;
            }
        }
    }

    #region "Even"
    protected void MemberID_TriggerClick(object sender, EventArgs e)
    {
        this.Window1.Hidden = false;
        string strSQL = @"Select a.* ,b.MemberClassName
                            From tblMember a 
                            Left join tblMemberClass b on a.MemberClassID = b.MemberClassID
                            Where a.MemberID <> ''";
        //FineUIPro.Alert.Show(strSQL);
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        string strSQL = @"Select a.* ,b.MemberClassName
                            From tblMember a 
                            Left join tblMemberClass b on a.MemberClassID = b.MemberClassID
                            Where a.MemberClassID = 'E'";
        if (this.txtSearch.Text.Length > 0)
        {
            strSQL += " and (a.MemberID Like '%" + this.txtSearch.Text + "%' or a.MemberName Like '%" + this.txtSearch.Text + "%')";
        }
        //FineUIPro.Alert.Show(strSQL);
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
    }
   
    

    protected void PID_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSQL = @"Select * From tblProduct Where PID = @PID ";
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@PID", PID.SelectedValue));
        DataTable dt = DB.getObject().GetData(strSQL, Params, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            this.Price.Text = dt.Rows[0]["Price"].ToString();

        }
        this.Num.Text = "1";
        //this.lblTotal.Text = dt.Rows[0][0].ToString();
    }
    #endregion
    #region "Method"
    protected void FillGrid()
    {
        this.Grid2.DataSource = Cart;
        this.Grid2.DataBind();
        int Amount = 0;
        for (int i = 0; i < Cart.Rows.Count; i++)
        {
            Amount += Convert.ToInt32(Cart.Rows[i]["Price"].ToString()) * Convert.ToInt32(Cart.Rows[i]["Num"].ToString());
        }
        if (Amount >= 30000)
        {
            this.lblTotal.CssStyle = "color:black;font-size:16px;";
        }
        this.lblTotal.Text = Amount.ToString("N2");
    }
    private void createOrderTable()
    {

        Cart.Columns.AddRange
            (new DataColumn[4]
                {   new DataColumn("PID", typeof(string)),
                    new DataColumn("PName", typeof(string)),
                    new DataColumn("Price", typeof(int)),
                    new DataColumn("Num", typeof(int))
                }
            );
        //Append Data Row
        Session["ShoppingCart"] = Cart;
    }
    protected string GetNewOrderID()
    {
        string args = string.Empty;
        string NewOrderID = DateTime.Today.ToString("yyyyMMdd");
        string strSQL = @"Select Top 1 OrderID From tblOrderM Where Left(OrderID ,8 ) ='" + NewOrderID + "' Order by OrderID Desc";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        if (dt.Rows.Count > 0)
        {
            args = (Convert.ToInt64(dt.Rows[0][0].ToString()) + 1).ToString();
        }
        else
        {
            args = DateTime.Today.ToString("yyyyMMdd") + "0001";
        }
        return args;
    }
    #endregion
    #region "Grid"
    protected void Grid1_RowDoubleClick(object sender, FineUIPro.GridRowClickEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        this.UpMemberID.Text = keys[0].ToString();
        this.UpMemberName.Text = keys[1].ToString();
        this.UpMemberClassID.Text = keys[2].ToString();
        //MemberModel UpMember = MemberModel.MemberDetail(keys[3].ToString());
        //this.UpMemberID.Text = keys[3].ToString();
        //this.UpMemberName.Text = UpMember.MemberName;
        //this.UpMemberClassID.Text = ClassDB.GetMemberClassName(UpMember.MemberClassID);
        this.Window1.Hidden = true;

       
    }
    protected void Grid2_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
    {
        object[] keys = Grid2.DataKeys[e.RowIndex];
        if (e.CommandName == "Action1")
        {
            
            DataTable dt = (DataTable)Session["ShopingCart"];
            DataRow[] rows = dt.Select("PID = '" + keys[0].ToString() + "'");
            for (int i = 0; i < rows.Length; i++)
            {

                rows[i].Delete();
            }
            FillGrid();
        }

    }
    #endregion
    #region "Export"
    #endregion

    #region "Event"
    //存檔 tblOrderM ,tblOrderD
    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["AreaID"];
        if (cookie == null && this.AreaID.SelectedValue  != "" && this.StockID.SelectedValue != "")
        {
            HttpCookie cookieAreaID = new HttpCookie("AreaID");
            //設定單值
            cookieAreaID.Value = Server.UrlEncode(this.AreaID.SelectedValue );
            //設定過期日
            cookieAreaID.Expires = DateTime.Now.AddDays(20);
            //寫到用戶端
            HttpCookie cookieStockID = new HttpCookie("StockID");
            //設定單值
            cookieStockID.Value = Server.UrlEncode(this.StockID.SelectedValue );
            //寫到用戶端
            Response.Cookies.Add(cookie);
        }

        if (Session["LoginUserID"] == null)
        {
            FineUIPro.Alert.Show("請先登入!!");
            return;
        }
       
        if (CheckError().Length > 0)
        {
            FineUIPro.Alert.Show(CheckError());
        }
        else
        {
            string NewOrderID = GetNewOrderID();
            string strSQL = string.Empty;
            ArrayList Params = new ArrayList();
            string MemberID = DB.GetMemberNo();
            MemberModel UpMember = MemberModel.MemberDetail(UpMemberID.Text);
            // 1.新增會員 , 新增訂單 , 新增晉升 , 新增獎金
            // 會員
           
            //訂單
            strSQL += @"Insert Into tblOrderM( OrderID,OrderDate,MemberID,Amount,YM,PayType ,BankAccount4 ,CreditCardNo, TaxNo ,AreaID ,StockID,CreateTime,CreateUser,EditTime,EditUser,StatusCode)
                        Values  (
                        '" + NewOrderID + @"',
                        '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                        '" + MemberID + @"',
                        '" + Convert.ToDouble(this.lblTotal.Text).ToString() + @"',
                        '" + DateTime.Now.ToString("yyyyMM") + @"',
                        '" + this.PayType.SelectedValue + @"',
                        '" + this.BankAccount4.Text + @"',
                        '" + this.CreditCardNo.Text + @"',
                        '" + this.TaxNo.Text + @"',
                        '" + this.AreaID.SelectedValue + @"',
                        '" + this.StockID.SelectedValue + @"',
                        '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                        '" + Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress() + @"',
                        '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                        '" + Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress() + @"',
                        'Y') ";

            //訂單明細

            Cart = (DataTable)Session["ShoppingCart"];
            for (int i = 0; i < Cart.Rows.Count; i++)
            {
                strSQL += @"Insert Into tblOrderD( OrderID,item,PID,Num,Price,CreateTime,CreateUser,EditTime,EditUser,StatusCode)
                            Values  (
                        '" + NewOrderID + @"',
                        '" + (i + 1).ToString() + @"',
                        '" + Cart.Rows[i]["PID"].ToString() + @"',
                        '" + Cart.Rows[i]["Num"].ToString() + @"',
                        '" + Cart.Rows[i]["Price"].ToString() + @"',
                        '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                        '" + Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress() + @"',
                        '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                        '" + Session["LoginUserID"].ToString() + "/" + DB.GetIPAddress() + @"',
                        'Y') ";
            }
            //更改庫存
                for (int i = 0; i < Cart.Rows.Count; i++)
                {
                    strSQL += @" exec spUpdateStockNum 
                        '" + Cart.Rows[i]["PID"].ToString() + @"',
                        '" + (Convert.ToInt32(Cart.Rows[i]["Num"].ToString()) * -1) + @"',
                        '" + StockID.SelectedValue + @"',
                        'Order'";
                }
            //晉升
            
            //strSQL += "exec dbo.ComputerBonus '" + NewOrderID + "'";
            //strSQL += "exec dbo.ComputerPromotion '" + NewOrderID + "'";

            if (DB.getObject().Execute(strSQL, null, false).Success == true)

            {
                FineUIPro.Alert.Show("新增成功");
            }
            else
            {
                FineUIPro.Alert.Show(strSQL);
            }
            //this.Button1.Enabled = false;
            //FineUIPro.Alert.Show(strSQL);
        }
    }
    //新增一筆記錄
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(this.Num.Text) >= 1)
        {
            if (Session["ShopingCart"] == null)
            {
                createOrderTable();
            }
            else
            {
                Cart = (DataTable)Session["ShoppingCart"];
            }
            DataRow[] rows = Cart.Select("PID = '" + this.PID.SelectedValue + "'");
            if (rows.Length > 0)
            {
                rows[0][3] = Convert.ToInt32(rows[0][3].ToString()) + Convert.ToInt32(this.Num.Text);
            }
            else
            {
                dr = Cart.NewRow();
                dr[0] = this.PID.SelectedValue;
                dr[1] = this.PID.SelectedText;
                dr[2] = this.Price.Text;
                dr[3] = this.Num.Text;
                //dr[4] = (Convert.ToInt32(this.Price.Text) * Convert.ToInt32(this.Num.Text)).ToString();
                Cart.Rows.Add(dr);
            }

            Session["ShopingCart"] = Cart;
            FillGrid();
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        FineUIPro.PageContext.Redirect("BillPOList.aspx");
    }   

    
    #endregion

    #region "Method"
    //購物車
    private void createTable()
    {
        if (Session["dt"] == null)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[5] {
            new DataColumn("PID", typeof(string)),
            new DataColumn("PName", typeof(string)),
            new DataColumn("ItemNum", typeof(int)),
            new DataColumn("Price", typeof(double)),
            new DataColumn("Amount", typeof(double))});
            Session["dt"] = dt;
        }
    }
    
    #endregion

    #region "Grid"
    protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        if (e.CommandName == "Action1")
        {
            createTable();
            DataTable dt = (DataTable)Session["dt"];
            DataView dv = new DataView(dt);
            dv.RowFilter = "PID='" + keys[0].ToString() + "'"; // query example = "id = 10"
            this.Price.Text = keys[3].ToString();
            this.Num.Text = keys[2].ToString();
        }
        if (e.CommandName == "Action2")
        {
            createTable();
            DataTable dt = (DataTable)Session["dt"];
            DataRow[] rows = dt.Select("PID = '" + keys[0].ToString() + "'");
            for (int i = 0; i < rows.Length; i++)
            {

                rows[i].Delete();
            }
            this.Grid1.DataSource = dt;
            this.Grid1.DataBind();
            Session["dt"] = dt;
            double TotalAmount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TotalAmount += Convert.ToDouble(dt.Rows[i]["Amount"].ToString());
            }
            
        }
    }
    #endregion


    
    //付款方式 1.現金 2.銀行匯款 3.信用卡
    protected void PayType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.PayType.SelectedValue == "1")
        {
            BankAccount4.Hidden = true;
            CreditCardNo.Hidden = true;
        }
        if (this.PayType.SelectedValue == "2")
        {
            BankAccount4.Hidden = false ;
            CreditCardNo.Hidden = true;
        }
        if (this.PayType.SelectedValue == "3")
        {
            BankAccount4.Hidden = true;
            CreditCardNo.Hidden = false ;
        }
    }

    protected string CheckError()
    {
        string args = string.Empty;
        if (this.AreaID.SelectedValue ==""){ args += "營業處未填!!"; }
        if (this.StockID.SelectedValue == "") { args += "出庫倉庫未填!!"; }
        if (this.PayType.SelectedValue == "2" && BankAccount4.Text.Length == 0)
        {
            args += "銀行轉帳, 末四碼未填!!";
        }
        if (this.PayType.SelectedValue == "3" && CreditCardNo.Text.Length == 0)
        {
            args += "信用卡號未填!!";
        }
        string strSQL = string.Empty;
        
        //發票號碼檢查
        strSQL = "Select OrderID From tblOrderM Where TaxNo='" + this.TaxNo.Text + "' ";
        if (this.TaxNo.Text.Length > 0 && DB.getObject().GetData(strSQL, null, false).ReturnDataTable.Rows.Count > 0)
        {
            args += "發票號碼已存在!!";
        }
        return args;
    }
}