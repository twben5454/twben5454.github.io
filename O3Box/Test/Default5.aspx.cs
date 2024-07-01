using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Newtonsoft.Json.Linq;

public partial class Default5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            DB.FillFineUIRadioButtonList(this.textBox1, "Select OrderID,OrderID as OrderIDValue From tblOrderM Where StatusCode='Y' and OrderID > '202010250003'", "");
            
        }

    }



    protected void textBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSQL = "select * From tblBonus WHere OrderID ='" + this.textBox1.SelectedValue + "'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
        //FineUIPro.Alert.Show(strSQL);
        OutputSummaryData(dt);
    }

    private void OutputSummaryData( DataTable dt )
    {
        int BonusPercent = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            BonusPercent += Convert.ToInt32(dt.Rows[i]["BonusPercent"].ToString());
        }
        //DataTable source = DataSourceUtil.GetDataTable2();

        //float donateTotal = 0.0f;
        //float feeTotal = 0.0f;
        //foreach (DataRow row in source.Rows)
        //{
        //    donateTotal += Convert.ToInt32(row["Donate"]);
        //    feeTotal += Convert.ToInt32(row["Fee"]);
        //}


        JObject summary = new JObject();
        //summary.Add("Major", "全部合计");
        summary.Add("BonusPercent", BonusPercent.ToString());


        Grid1.SummaryData = summary;

    }
}