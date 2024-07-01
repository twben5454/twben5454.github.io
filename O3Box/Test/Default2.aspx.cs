using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Test_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string ben = "TW00299";
            //int NewNo = Convert.ToInt32(ben.Substring(2, 5)) + 1;
            //ben =  ("00000" + NewNo.ToString());
            ////Response.Write("TW" + ben.Substring(ben.Length-6,6));
            Response.Write(DB. GetMemberNo("TW"));
            
        }
    }

    protected string GetMemberNo(string strCity)
    {
        
        string args = string.Empty;
        string strSQL = @"Select top 1 MemberID From tblMember Where Left(MemberID,2) = '" + strCity + "' order by MemberID Desc";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;

        if (dt.Rows.Count > 0)
        {
            string strLast = dt.Rows[0][0].ToString();
            int NewNo = Convert.ToInt32(strLast.Substring(2, 6)) + 1;
            strLast = ("000000" + NewNo.ToString());
            args = strCity + strLast.Substring(strLast.Length - 6, 6);
        }
        else
        {
            args = strCity + "000001";
        }
        return args;
    }


}