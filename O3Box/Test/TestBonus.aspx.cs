using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Test_TestBonus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected DataTable GetMemberUpGroup(string MemberID)
    {
        string strSQL = "exec [dbo].[sp_GetMemberUpGroup] '" + MemberID + "'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        return dt;
    }

    protected int GetBonusA(DataTable dt) 
    {
        //MemberID, MemberNmae ,MemberClassID ,lvl ,UpClassID ,GroupAmount ,BALvl ,PALvl ,ALvl ,LALvl ,A10Lvl ,A15Lvl ,A20Lvl, A20Lvl
        int args = 0;
        return args;
    }

    protected int GetBonus(string TargetClassID, int lvl)
    {
        int args = 0;
        
            if (TargetClassID == "BA")
            {
                if (lvl == 1)
                {
                    args = 20;
                }
                else if (lvl == 2)
                {
                    args = 5;
                }
                else if (lvl == 3)
                {
                    args = 2;
                }
                else if (lvl > 3)
                {
                    args = 0;
                }
            }
            if (TargetClassID == "PA")
            {
                if (lvl == 1)
                {
                    args = 30;
                }
                else if (lvl == 2)
                {
                    args = 10;
                }
                else if (lvl == 3)
                {
                    args = 5;
                }
                else if (lvl == 4)
                {
                    args = 3;
                }
                else if (lvl > 4)
                {
                    args = 0;
                }
            }
        return args;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Label1.Text = GetBonus( "BA", 1).ToString();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Label1.Text = GetBonus("BA", 2).ToString();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        this.Label1.Text = GetBonus("BA", 3).ToString();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        this.Label1.Text = GetBonus("BA", 4).ToString();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        //PA-Lvl1
        this.Label1.Text = GetBonus("PA", 1).ToString();
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        this.Label1.Text = GetBonus("PA", 2).ToString();
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        this.Label1.Text = GetBonus("PA", 3).ToString();
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        this.Label1.Text = GetBonus("PA", 4).ToString();
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        this.Label1.Text = GetBonus("PA", 5).ToString();
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        this.Grid1.DataSource = GetMemberUpGroup(this.TextBox1.Text );
        this.Grid1.DataBind();
    }
}