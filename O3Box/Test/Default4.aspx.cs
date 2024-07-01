using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Test_Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
                         

                dt.Columns.AddRange(new DataColumn[6] {
                new DataColumn("MemberID", typeof(string)),
                new DataColumn("MemberClassID", typeof(string)),
                new DataColumn("lvl", typeof(int)),
                new DataColumn("UpMemberID", typeof(string)),
                new DataColumn("UpMemberClassID", typeof(string)),
                new DataColumn("Uplvl", typeof(string))});
            for (int i = 0; i < 6; i++)
            { 
                DataRow row ;
                row = dt.NewRow();
                row["MemberID"] = "TW000007";
                row["MemberClassID"] = "BA";
                row["lvl"] = 7;
                row["UpMemberID"] = "TW00000" + (i+1).ToString();
                row["UpMemberClassID"] = "";
                row["Uplvl"] = (i + 1).ToString();
                dt.Rows.Add(row);
            }
            this.Grid1.DataSource = dt;
            this.Grid1.DataBind();
        }
    }
}