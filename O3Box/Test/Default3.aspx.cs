using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Test_Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["dt"] == null)
            {
                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[6] {
                new DataColumn("MemberID", typeof(string)),
                new DataColumn("MemberClassID", typeof(string)),
                new DataColumn("lvl", typeof(int)),
                new DataColumn("UpMemberID", typeof(string)),
                new DataColumn("UpMemberClassID", typeof(string)),
                new DataColumn("Uplvl", typeof(string))});
                Session["dt"] = dt;
            }
            for (int i = 1; i < 8; i++)
            {

            }
        }

    }

    protected void btnButton_Click(object sender, EventArgs e)
    {
        string strSQL = "exec [dbo].[sp_GetOrderInfo] '" + this.textBox1.Text + "'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
        CountBonus();
    }

    protected void CountBonus()        
    {
        this.Ben.Text = "";
        string strSQL = "exec [dbo].[sp_GetOrderInfo] '" + this.textBox1.Text + "'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        string expression = "MemberClassID='BA' and (MeLvl - Lvl > 0) ";
        string sortOrder = "lvl  Desc";
        DataRow[] rows = dt.Select(expression, sortOrder);
        int BASum = rows.Length;
        int TotalBABonus = 0;
        this.Ben.Text += "BA Sum :" + BASum.ToString() + "\n";
        for (int i = 0; i < rows.Length; i++)
        {
            int BABonus = 0;
            if (i == 0) { BABonus = 20; }
            if (i == 1) { BABonus = 5; }
            this.Ben.Text += rows[i]["UpMemberID"].ToString() + "---" + rows[i]["MemberClassID"].ToString() + "---" +  rows[i]["lvl"].ToString() + "---" + BABonus.ToString() +  "\n";
            TotalBABonus += BABonus;
        }
        this.Ben.Text += "Total BABonus  :" + TotalBABonus.ToString() + "\n";
        expression = "MemberClassID='PA' and (MeLvl - Lvl > 0) ";
        ///////////////// PA
        rows = dt.Select(expression, sortOrder);
        int PASum = rows.Length;
        int TotalPABonus = 0;
        this.Ben.Text += "PA Sum :" + PASum.ToString() + "\n";
        for (int i = 0; i < rows.Length; i++)
        {
            int PABonus = 0;
            if (rows.Length == 1)
            {
                PABonus = 30 - TotalBABonus ; 
            }
            //if (i == 1) { BABonus = 5; }
            this.Ben.Text += rows[i]["UpMemberID"].ToString() + "---" + rows[i]["MemberClassID"].ToString() + "---" + rows[i]["lvl"].ToString() + "---" + PABonus.ToString() + "\n";
            TotalPABonus += PABonus;
        }
        this.Ben.Text += "Total PABonus  :" + TotalPABonus.ToString() + "\n";
        /////////////////PA
    }
    protected string GetBonusPercent(string MemberClassID, string MeLvl, string UpMemberClassID, string UpLvl, bool IsFirst)
    {
        string args = string.Empty;
        if (MemberClassID == "BA" && UpMemberClassID == "BA")
        {
            if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) == 1)
            {
                args = "B1";
            }
            if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) == 2)
            {
                args = "B2";
            }
            if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) == 3)
            {
                args = "B3";
            }
        }
        return args;
    }
    protected string  GetBonusPercentA(string MemberClassID , string MeLvl , string UpMemberClassID ,string UpLvl ,bool IsFirst)
    {
        string args = string.Empty;
        string strSQL = "exec [dbo].[sp_GetOrderInfo] '" + this.textBox1.Text + "'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        int PACount = 0;
        int ACount = 0;
        int LACount = 0;
        string expression = "MemberClassID='BA' and (MeLvl - Lvl > 0) ";
        string sortOrder = "lvl  Asc";
        DataRow[] rows = dt.Select(expression, sortOrder);
        float BASum = 0;
        for (int i = 0; i < rows.Length; i++)
        {
            //FineUIPro.Alert.Show(rows[i]["name"].ToString());
            if (Convert.ToInt32(rows[i]["MeLvl"].ToString()) - Convert.ToInt32(rows[i]["Lvl"].ToString()) == 1)
            {
                BASum = 20 - BASum;
                args = BASum.ToString();
            }
            if (Convert.ToInt32(rows[i]["MeLvl"].ToString()) - Convert.ToInt32(rows[i]["Lvl"].ToString()) == 2)
            {
                args = "5";
                BASum = 5 - BASum;
                args = BASum.ToString();
            }
            if (Convert.ToInt32(rows[i]["MeLvl"].ToString()) - Convert.ToInt32(rows[i]["Lvl"].ToString()) == 3)
            {
                args = "2";
                BASum = 2 - BASum;
                args = BASum.ToString();
            }
        }
        //string strSQL = @"select Bonus From tblBonusSetup 
        //                    Where MemberClassID = '" + MemberClassID + @"' 
        //                    and TargetMemberClassID ='" + UpMemberClassID + @"'
        //                    and lvl  = '" + (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl)).ToString() + "'";
        //DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        //FineUIPro.Alert.Show(strSQL);
        //if (dt.Rows.Count > 0)
        //{
        //    args = dt.Rows[0][0].ToString();
        //}

        //float BACount = 0;
        //if (MemberClassID == "BA" && UpMemberClassID == "BA")
        //{
        //    if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) == 1)
        //    {
        //        args = "20";
        //    }
        //    if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) == 2)
        //    {
        //        args = "5";
        //    }
        //    if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) == 3)
        //    {
        //        args = "2";
        //    }
        //}
        //if (MemberClassID == "BA" && UpMemberClassID == "PA")
        //{
        //    if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) == 1)
        //    {
        //        args = "10";
        //    }
        //    if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) == 2)
        //    {
        //        args = "5";
        //    }
        //    if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) >= 3)
        //    {
        //        args = "3";
        //    }
        //}
        //if (MemberClassID == "BA" && UpMemberClassID == "A")
        //{
        //    if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) == 1)
        //    {
        //        args = "20";
        //    }
        //    if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) == 2)
        //    {
        //        args = "15";
        //    }
        //    if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) >= 3)
        //    {
        //        args = "13";
        //    }
        //}
        //if (MemberClassID == "BA" && UpMemberClassID == "LA")
        //{
        //    if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) == 1)
        //    {
        //        args = "20";
        //    }
        //    if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) == 2)
        //    {
        //        args = "15";
        //    }
        //    if (Convert.ToInt32(MeLvl) - Convert.ToInt32(UpLvl) >= 3)
        //    {
        //        args = "13";
        //    }
        //}
        return args;
    }

    protected double   GetClassIDCount()
    {
        double args = 0;
        string strSQL = "exec [dbo].[sp_GetOrderInfo] '" + this.textBox1.Text + "'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        int PACount = 0;
        int ACount = 0;
        int LACount = 0;
        string expression = "MemberClassID='BA'";
        string sortOrder = "lvl  DESC";
        DataRow[] rows = dt.Select(expression, sortOrder);
        foreach (DataRow row in rows)
        {
            //list.ImportRow(row);
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {           
                if (dt.Rows[i]["MeMemberClassID"].ToString() == "BA" && dt.Rows[i]["MemberClassID"].ToString() == "BA")
                {
                    if (Convert.ToInt32(dt.Rows[i]["MeLvl"].ToString()) - Convert.ToInt32(dt.Rows[i]["Lvl"].ToString()) == 1)
                    {
                        args = 0.2;
                    }
                    if (Convert.ToInt32(dt.Rows[i]["MeLvl"].ToString()) - Convert.ToInt32(dt.Rows[i]["Lvl"].ToString()) == 2)
                    {
                        args = 0.05;
                    }
                    if (Convert.ToInt32(dt.Rows[i]["MeLvl"].ToString()) - Convert.ToInt32(dt.Rows[i]["Lvl"].ToString()) == 3)
                    {
                        args = 0.02;
                    }
                }
            if (dt.Rows[i]["MeMemberClassID"].ToString() == "BA" && dt.Rows[i]["MemberClassID"].ToString() == "PA")
            {
                PACount = 1;
                if (PACount == 1)
                {
                    args = 0.2;
                }
                if (PACount == 2)
                {
                    args = 0.05;
                }
                if (Convert.ToInt32(dt.Rows[i]["MeLvl"].ToString()) - Convert.ToInt32(dt.Rows[i]["Lvl"].ToString()) == 3)
                {
                    args = 0.02;
                }
            }

        }
        return args;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        //    foreach (DataRow row in rows)
        //{
        //    FineUIPro.Alert.Show(row.ToString() );
        //}
    }
}