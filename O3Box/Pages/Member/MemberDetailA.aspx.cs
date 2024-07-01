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

public partial class Admin_Page_Member_MemberDetailA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MemberModel Member = MemberModel.MemberDetail(Request.QueryString["id"].ToString());
            this.MemberID.Text = Member.MemberID;
            this.MemberName.Text = Member.MemberName;
            this.CellPhone.Text = Member.CellPhone;
            if (Member.Birthday.Length > 0)
            {
                this.Birthday.Text = Convert.ToDateTime(Member.Birthday).ToString("yyyy-MM-dd");
            }
            //this.Birthday.Text = Member.Birthday;
            this.Address.Text = Member.Address;
            this.Zip.Text = Member.Zip;
            this.JoinDate.Text = Member.JoinDate;
            this.Email.Text = Member.Email;
            DB.FillFineUIDropDownList(this.BankID, "Select BankName ,BankID From tblBank", Member.BankID);
            this.BankAccount.Text = Member.BankAccount;
            this.MemberClassID.Text = Member.MemberClassName;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strSQL = @"Update tblMember  Set 
                            Birthday ='" + Birthday.Text + @"',
                            Address = '" + Address.Text + @"',
                            Zip = '" + Zip.Text + @"',
                            Email ='" + Email.Text + @"',
                            CellPhone ='" + CellPhone.Text + @"',
                            BankID = '" + BankID.SelectedValue  + @"',
                            BankAccount = '" + BankAccount.Text + @"',
                            EditTime ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                            EditUser ='" + Session["LoginUserID"].ToString() + " / " + DB.GetIPAddress() + @"'
                            Where MemberID = '" + MemberID.Text + "'";
        if (DB.getObject().Execute(strSQL, null, false).Success == true)
        {
            FineUIPro.Alert.Show("更檔成功");
        }
        else
        {
            FineUIPro.Alert.Show(strSQL);
        }
        
    }
}