using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using JSBeautifyLib;
using System.Text;
using System.IO;
using System.Collections;


public partial class Admin_Page_Member_MemberTree : System.Web.UI.Page    
{
    public string strDataSource;
    protected void Page_Load(object sender, EventArgs e)
    {
        string MemberID = Request.QueryString["id"].ToString();
        string name = MemberModel.MemberDetail(MemberID).MemberName;
        string title = MemberID;
        string office = MemberModel.MemberDetail(MemberID).MemberClassID;
        strDataSource = @"{
          'name': '" + MemberModel.MemberDetail(MemberID).MemberName + @"',
          'title': '" + MemberID + @"',
          'office': '" + DBClass .GetMemberClassName(MemberModel.MemberDetail(MemberID).MemberClassID) +  @"',";
        strDataSource += FillSubOrg(MemberID);
        strDataSource += "}";
    }


    protected string  FillSubOrg(string MemberID)
    {
        string args = string.Empty;
        string strSQL = @"Select  * From tblMember Where UpMemberID = @MemberID ";
        ArrayList Params = new ArrayList();
        Params.Add(new SqlParameter("@MemberID", MemberID));
        DataTable dt = DB.getObject().GetData(strSQL, Params, false).ReturnDataTable;
        args = "'children': [";
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                args += "{ ";
                args += "'name': '" + dt.Rows[i]["MemberID"].ToString() + "', 'title':'" + dt.Rows[i]["MemberName"].ToString() + "', 'office': '" + DBClass .GetMemberClassName(dt.Rows[i]["MemberClassID"].ToString())  + @"(" + dt.Rows[i]["MemberClassID"].ToString() + ")' ,";
                args += FillSubOrg(dt.Rows[i]["MemberID"].ToString());
                args +="},";
                
            }

        }
        args += "]";
        return args;
    }
}