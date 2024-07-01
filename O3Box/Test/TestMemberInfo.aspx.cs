using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Test_TestMemberInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        DataTable dt = GetUpGroup(MemberID.Text );
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
    }
    //取得上線群
    protected DataTable GetUpGroup(string MemberID)
    {
        string strSQL = @"Declare @MemberID nvarchar(50) = '" + MemberID + @"'
                            Declare @UpGroup nvarchar(Max) = (Select UpGroup From tblMember Where MemberID = @MemberID )
                            select a.name as UpMemberID , b.MemberClassID , b.lvl ,b.MemberName , dbo.fn_GetMemberAmount(a.name ,'','2') as GroupAmount ,dbo.fn_GetSubMemberClassIDCount(a.name) as SubMemberClassIDCount 
	                        From [dbo].[splitstring](@UpGroup ) a
	                        join tblMember b on a.name = b.MemberID 
                            where a.name <> '" + MemberID + @"'
                            order by b.lvl desc";
        DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
        return dt;
    }
    //取得會員各等級的人數
    protected int GetMemberClassIDCount(string MemberID ,string MemberClassID)
    {
        int args = 0;
        return args;
    }

    //取得會員累積的組織業績
    protected int GetMemberGroupAmount(string MemberID)
    {
        int args = 0;
        return args;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dt = GetUpGroup(MemberID.Text);
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
    }
}