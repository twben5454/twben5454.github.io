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
public partial class Admin_Page_Member_MemberDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MemberModel Member = MemberModel.MemberDetail(Request.QueryString["id"].ToString());
            this.lblMemberID.Text = Member.MemberID;
            this.lblMemberName.Text = Member.MemberName;
            this.lblMemberClassName.Text = DBClass.GetMemberClassName(Member.MemberClassID);
            this.lblUpMemberName.Text = Member.UpMemberName;
            this.lblUpMemberID.Text = Member.UpMemberID;
            this.lblUpMemberClassName.Text = Member.UpMemberClassName;
            //this.Tab1.IFrameUrl = "ContractList.aspx?id=" + Request.QueryString["id"].ToString();
            this.Tab2.IFrameUrl = "MemberDetailA.aspx?id=" + Request.QueryString["id"].ToString();
            this.Tab3.IFrameUrl = "MemberOrder.aspx?id=" + Request.QueryString["id"].ToString();
            this.Tab4.IFrameUrl = "MemberBonus.aspx?id=" + Request.QueryString["id"].ToString();
            this.Tab5.IFrameUrl = "MemberPromotion.aspx?id=" + Request.QueryString["id"].ToString();
            this.Tab7.IFrameUrl = "MemberTree.aspx?id=" + Request.QueryString["id"].ToString();
            this.Tab21.IFrameUrl = "GroupOrder.aspx?id=" + Request.QueryString["id"].ToString();
            this.Tab22.IFrameUrl = "GroupAmount.aspx?id=" + Request.QueryString["id"].ToString();
            this.Tab23.IFrameUrl = "GroupPromotion.aspx?id=" + Request.QueryString["id"].ToString();
            this.Tab24.IFrameUrl = "GroupBonus.aspx?id=" + Request.QueryString["id"].ToString(); 
            //CheckStatus();
        }
    }

    protected void btnBackup_Click(object sender, EventArgs e)
    {
        FineUIPro.PageContext.Redirect("Member.aspx");
    }
}