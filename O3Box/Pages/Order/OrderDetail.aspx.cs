using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Order_OrderDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.OrderID.Text = Request.QueryString["id"].ToString();
            string strSQL = @"Select 
	                            a.* ,b.MemberName ,c.MemberName as UpMemberName ,b.CellPhone ,b.CountryID ,b.PersonID ,b.UpMemberID ,c.MemberName as UpMemberName ,c.MemberClassID as UpMemberClassID
                            From tblOrderM a 
                            Left join tblMember b on a.MemberID = b.MemberID 
                            Left join tblMember c on b.UpMemberID = c.MemberID 
                            Where a.OrderID='" + Request.QueryString["id"].ToString() + "'";
            DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
            if (dt.Rows.Count > 0)
            {
                this.MemberName.Text = dt.Rows[0]["MemberName"].ToString();
                this.PersonID.Text = dt.Rows[0]["PersonID"].ToString();
                this.OrderDate.Text = dt.Rows[0]["OrderDate"].ToString();
                this.Amount .Text = dt.Rows[0]["Amount"].ToString();
                this.CellPhone.Text = dt.Rows[0]["CellPhone"].ToString();
                this.UpMemberID.Text = dt.Rows[0]["UpMemberID"].ToString();
                this.UpMemberClassID.Text = dt.Rows[0]["UpMemberClassID"].ToString();
                this.UpMemberName.Text = dt.Rows[0]["UpMemberName"].ToString();
            }
            FillGrid();
        }
    }

    protected void FillGrid()
    {
        string strSQL = "Select * ,dbo.GetPName(PID) as PName ,(Num*Price ) as Amount  From tblOrderD Where OrderID='" + Request.QueryString["id"].ToString() + "'";
        DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
        this.Grid2.DataSource = dt;
        this.Grid2.DataBind();
    }
}