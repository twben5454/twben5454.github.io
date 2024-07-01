using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;


public partial class ShopEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["User"] = "ben";
        if (!IsPostBack)
        {
            if (Request.QueryString["typ"] != null)
            {
                if (Request.QueryString["typ"].ToString() == "add") { this.Window1.Title = this.Window1.Title + "新增"; this.ShopID.Text = DateTime.Now.ToFileTime().ToString(); }
                else if (Request.QueryString["typ"].ToString() == "edt") { this.Window1.Title = this.Window1.Title + "更改"; FillData(); }
            }
            else
            { this.Window1.Title = this.Window1.Title + "新增"; this.ShopID.Text = DateTime.Now.ToFileTime().ToString(); }

        }
    }

    protected void FillData()
    {
        string strSQL = string.Empty;
        strSQL = @"Select * From tblCustomer Where CustomerID = '" + Request.QueryString["id"].ToString() + "'";
        
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        

    }
    //新增
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string strSQL = string.Empty;
        if (Request.QueryString["typ"].ToString() == "add")
        {
            strSQL = @"Insert Into tblShop(  
                    ShopID,ShopName,VID,WebURL,Boss,Tel,Fax,Address,Zip,UpShopID,UpGroup,JoinDate,LimitDate,Created) 
                    Values  
                    (@ShopID,@ShopName,@VID,@WebURL,@Boss,@Tel,@Fax,@Address,@Zip,@UpShopID,@UpGroup,@JoinDate,@LimitDate,@Created) ";
            ArrayList sp = new ArrayList();
            
            sp.Add(new SqlParameter("@Created", DB.getObject().GetClientIP(this.Page) + "/" + DateTime.Now.ToString("yyyyMMddhhmmss") + "/" ));
            if (DB.getObject().Execute(strSQL, sp, false).Success == true)
            {
                FineUIPro.Alert.Show("新增成功！！");
            }
            else
            {
                FineUIPro.Alert.Show("程序发生错误！！");
            }
        }
        if (Request.QueryString["typ"].ToString() == "edt")
        {
            strSQL = @"Update tblCustomer  Set 
                        CustomerID= @CustomerID , 
                        CustomerName= @CustomerName , 
                        Tel= @Tel , 
                        Address= @Address , 
                        ContractName= @ContractName , 
                        ContractCellPhone= @ContractCellPhone , 
                        DomainName= @DomainName , 
                        DomainNameSDate= @DomainNameSDate , 
                        DomainNameEDate= @DomainNameEDate , 
                        WeiXin= @WeiXin , 
                        WeiXinP= @WeiXinP , 
                        WeiXinSDate= @WeiXinSDate , 
                        WeiXinEDate= @WeiXinEDate , 
                        WeiXinPSDate= @WeiXinPSDate , 
                        WeiXinPEDate= @WeiXinPEDate , 
                        Boss= @Boss , 
                        BusinessLicenceNo= @BusinessLicenceNo , 
                        Memo= @Memo , 
                        Updated= @Updated 
                        Where CustomerID = @CustomerID ";
            ArrayList sp = new ArrayList(); 
            if (DB.getObject().Execute(strSQL, sp, false).Success == true)
            {
                FineUIPro.Alert.Show("更改成功！！");
            }
            else
            {
                FineUIPro.Alert.Show("程序发生错误！！");
            }
        }
    }
}