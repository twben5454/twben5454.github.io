using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_Default7 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MemberModel UpMember = MemberModel.MemberDetail("TW000003");
        Response.Write(UpMember.UpGroup);
    }
}