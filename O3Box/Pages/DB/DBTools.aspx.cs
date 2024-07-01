using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_DB_DBTools : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DB.FillFineUIDropDownList(this.drpDataBase, "SELECT name ,name as names FROM master.sys.databases", "CosmeticDB");
            string strSQL = @"Use " + this.drpDataBase.SelectedText + @"  select * from sysobjects where type = 'u' order by name";
            DB.FillFineUIDropDownList(this.drpTable, strSQL, "");
        }
    }

    protected void drpDataBase_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSQL = @"Use " + this.drpDataBase.SelectedText + @"  select * from sysobjects where type = 'u' order by name";
        DB.FillFineUIDropDownList(this.drpTable, strSQL , "");
    }

    protected void drpTable_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = GetDT();
        FillClass(dt);
        FillCDRU(dt);
        FillDetailFineUI(dt);
        FillForm(dt);
        FillAdd(dt);
        FillBen(dt);
        FillGrid(dt);
        FillSQL(dt);
    }

    protected DataTable GetDT()
    {
        string strSQL = @" Use " + this.drpDataBase.SelectedText + @" 
                            SELECT a.name 字段名 ,
                            COLUMNPROPERTY(a.id, a.name, 'IsIdentity') 标识 ,
                            ( CASE WHEN ( SELECT COUNT(*)
                            FROM sysobjects
                            WHERE ( name IN (
                            SELECT name
                            FROM sysindexes
                            WHERE ( id = a.id )
                            AND ( indid IN (
                            SELECT indid
                            FROM sysindexkeys
                            WHERE ( id = a.id )
                            AND ( colid IN (
                            SELECT
                            colid
                            FROM
                            syscolumns
                            WHERE
                            ( id = a.id )
                            AND ( name = a.name ) ) ) ) ) ) )
                            AND ( xtype = 'PK' )
                            ) > 0 THEN '1'
                            ELSE '0'
                            END ) 主鍵 ,
                            b.name 類型 ,
                            COLUMNPROPERTY(a.id, a.name, 'PRECISION') AS 長度 ,
                            ISNULL(COLUMNPROPERTY(a.id, a.name, 'Scale'), 0) AS 小數位數 ,
                            ( CASE WHEN a.isnullable = 1 THEN '1'
                            ELSE '0'
                            END ) 允許空 ,
                            ISNULL(g.[value], '') AS 字段說明
                            FROM syscolumns a
                            LEFT JOIN systypes b ON a.xtype = b.xusertype
                            INNER JOIN sysobjects d ON a.id = d.id
                            AND d.xtype = 'U'
                            AND d.name <> 'dtproperties'
                            LEFT JOIN syscomments e ON a.cdefault = e.id
                            LEFT JOIN sys.extended_properties g ON a.id = g.major_id
                            AND a.colid = g.minor_id
                            WHERE d.name = '" + this.drpTable.SelectedText + @"'
                            ORDER BY a.id ,
                            a.colorder";
        DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
        return dt;
    }

    void FillClass(DataTable dt )
    {
        string args = string.Empty;
        args += "public class " + this.drpTable.SelectedText.Replace("tbl", "") + "Model\n";
        args += "{ \n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            args += "// " + dt.Rows[i]["字段說明"].ToString() + "\n";
            args += "public string " + dt.Rows[i][0].ToString() + " { get; set; }\n";
        }
        args += "} \n";
        this.lblClass.Text = args;
    }

    void FillCDRU(DataTable dt)
    {
        string args = string.Empty;
        args += "// Insert \n";
        args += "public static void " + this.drpTable.SelectedText.Replace("tbl", "") + "Create(" + this.drpTable.SelectedText.Replace("tbl", "") + "Model " + this.drpTable.SelectedText.Replace("tbl", "") + ") \n";
        args += "{ \n";
        args += "string strSQL = @\"Insert Into " + this.drpTable.SelectedText + "(  ";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i == dt.Rows.Count - 1)
            {
                args += dt.Rows[i][0].ToString() + ") \n";
            }
            else
            {
                args += dt.Rows[i][0].ToString() + ",";
            }
        }

        args += "Values  (";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i == dt.Rows.Count - 1)
            {
                args += "@" + dt.Rows[i][0].ToString() + ") \";\n";
            }
            else
            {
                args += "@" + dt.Rows[i][0].ToString() + ",";
            }
        }
        args += "ArrayList Params = new ArrayList();\n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            args += "Params.Add(new SqlParameter(\"@" + dt.Rows[i][0].ToString() + "\", " + this.drpTable.SelectedText.Replace("tbl", "") + "." + dt.Rows[i][0].ToString() + "));\n";
        }
        args += "DB.getObject().Execute(strSQL, Params, false); \n";
        args += "} \n";

        args += "\n// Update \n";
        args += "public static void " + this.drpTable.SelectedText.Replace("tbl", "") + "Edit(" + this.drpTable.SelectedText.Replace("tbl", "") + "Model " + this.drpTable.SelectedText.Replace("tbl", "") + ") \n";
        args += "{ \n";
        args += "string strSQL = @\"Update " + this.drpTable.SelectedText + "  Set \n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i == dt.Rows.Count - 1)
            {
                args += dt.Rows[i][0].ToString() + "=@" + dt.Rows[i][0].ToString() + "\n";
            }
            else
            {
                args += dt.Rows[i][0].ToString() + "=@" + dt.Rows[i][0].ToString() + ",\n";
            }
        }
        //args += "Where ID ='\" + ID.text + \"'";
        args += "Where " + dt.Rows[0][0].ToString() + " = @" + dt.Rows[0][0].ToString() + " \";\n";
        args += "ArrayList Params = new ArrayList();\n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            args += "Params.Add(new SqlParameter(\"@" + dt.Rows[i][0].ToString() + "\", " + this.drpTable.SelectedText.Replace("tbl", "") + "." + dt.Rows[i][0].ToString() + "));\n";
        }
        args += "DB.getObject().Execute(strSQL, Params, false); \n";
        args += "} \n\n";
        args += "\n// Delete \n";
        args += "public static void " + this.drpTable.SelectedText.Replace("tbl", "") + "Del(string SNo)  \n";
        args += "{ \n";
        args += "string strSQL = @\"Delete  " + this.drpTable.SelectedText  + " Where " + dt.Rows[0][0].ToString() + " = @" + dt.Rows[0][0].ToString() + "\"; \n";
        args += "ArrayList Params = new ArrayList();\n";
        args += "Params.Add(new SqlParameter(\"@SNo\", SNo));\n";
        args += "DB.getObject().Execute(strSQL, Params, false);\n";
        args += "}\n\n";
        this.lblCDRU.Text = args;
    }

    void FillDetailFineUI(DataTable dt)
    {
        string args = string.Empty;
        args += "\n-- Detail \n";
        args += "public static " + this.drpTable.SelectedText.Replace("tbl", "") + "Model  " + this.drpTable.SelectedText.Replace("tbl", "") + "Detail(string " + dt.Rows[0][0].ToString() + ")  \n";
        args += "{ \n";
        args += this.drpTable.SelectedText.Replace("tbl", "") + "Model " + this.drpTable.SelectedText.Replace("tbl", "") + " = new " + this.drpTable.SelectedText.Replace("tbl", "") + "Model();\n";
        args += "string strSQL = @\"Select * From  " + this.drpTable.SelectedText + " Where " + dt.Rows[0][0].ToString() + " = @" + dt.Rows[0][0].ToString() + " \";\n";
        args += "ArrayList Params = new ArrayList();\n";
        args += "Params.Add(new SqlParameter(\"@" + dt.Rows[0][0].ToString() + "\", " + dt.Rows[0][0].ToString() + "));\n";
        args += "DataTable dt =DB.getObject().GetData(strSQL, Params, false).ReturnDataTable;\n";
        args += "if (dt.Rows.Count > 0)\n";
        args += "{\n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            args += "    " + this.drpTable.SelectedText.Replace("tbl", "") + "." + dt.Rows[i][0].ToString() + " =  dt.Rows[0][\"" + dt.Rows[i][0].ToString() + "\"].ToString();\n";
        }

        args += "}\n";
        args += "return " + this.drpTable.SelectedText.Replace("tbl", "") + ";\n";
        args += "}\n\n";
        this.lblDetailFineUI.Text = args;
    }
    void FillForm(DataTable dt)
    {
        string args = string.Empty;
        args += "\n-- Form \n";

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            args += "&lt;f:TextBox runat = \"server\" ID = \"" + dt.Rows[i][0].ToString() + "\" Label = \"" + dt.Rows[i][7].ToString() + "\" Required = \"false\" /&gt;" + "\n";

        }

        args += "\n\n";

        
        this.lblForm.Text = HttpUtility.HtmlDecode(args);
    }
    void FillAdd(DataTable dt)
    {
        string args= string.Empty ;
        args += "//Create \n";
        args += this.drpTable.SelectedText.Replace("tbl", "") + "Model " + this.drpTable.SelectedText .Replace("tbl", "") + " = new " + this.drpTable.SelectedText.Replace("tbl", "") + "Model(); \n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            args += this.drpTable.SelectedText.Replace("tbl", "") + "." + dt.Rows[i][0].ToString() + " = this." + dt.Rows[i][0].ToString() + ".Text;\n";
        }
        args += "try \n";
        args += "{ \n";
        args += this.drpTable.SelectedText.Replace("tbl", "") + "Model." + this.drpTable.SelectedText.Replace("tbl", "") + "Edit(" + this.drpTable.SelectedText.Replace("tbl", "") + "); \n";
        args += "Response.Write(\" < script>alert('更改成功!!');window.parent.location.reload();</script> \"); \n";
        args += "} \n";
        args += "catch \n";
        args += "{ \n";
        args += "} \n";
        this.lblAdd.Text = HttpUtility.HtmlDecode(args);
    }
    void FillBen(DataTable dt)
    {
        this.lblBen.Text = "string strSQL =@\"Select * From \"" + "\n";
        this.lblBen.Text += "DateTime.Now.ToString(\"yyyy-MM-dd HH:mm:ss\")" + "\n";
        this.lblBen.Text += "DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;" + "\n";
        this.lblBen.Text += "FineUIPro.Alert.Show(\"\");" + "\n";
        this.lblBen.Text += "#region \"" + this.drpTable.SelectedText.Replace("tbl", "") + "\"" + "\n";
        this.lblBen.Text += "#endregion " + "\n";
        this.lblBen.Text += "FineUIPro.Notify notify = new FineUIPro.Notify();" + "\n";
        this.lblBen.Text += "notify.Message = \"資料處理完畢...\";" + "\n";
        this.lblBen.Text += "notify.DisplayMilliseconds = 2000;" + "\n";
        this.lblBen.Text += "notify.ShowLoading = true;" + "\n";
        this.lblBen.Text += "notify.PositionX = FineUIPro.Position.Center;" + "\n";
        this.lblBen.Text += "notify.PositionY = FineUIPro.Position.Center;" + "\n";
        this.lblBen.Text += "" + "\n";
        this.lblBen.Text += "notify.Show();" + "\n";
        this.lblBen.Text += HttpUtility.HtmlDecode( "&lt;") + "\n";
    }

    void FillGrid(DataTable dt)
    {
        string args = string.Empty;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i][0].ToString() == "CreateUser" | dt.Rows[i][0].ToString() == "CreateTime" | dt.Rows[i][0].ToString() == "EditUser" | dt.Rows[i][0].ToString() == "EditTime" | dt.Rows[i][0].ToString() == "StatusCode")
            {
                args += "&lt;f:BoundField Width=\"100px\" DataField=\"" + dt.Rows[i][0].ToString() + "\" DataFormatString=\"{0} \" HeaderText=\"" + dt.Rows[i][7].ToString() + "\" SortField=\"" + dt.Rows[i][0].ToString() + "\" Hidden=\"true\" /&gt; \n";
            }
            else
            {
                args += "&lt;f:BoundField Width=\"100px\" DataField=\"" + dt.Rows[i][0].ToString() + "\" DataFormatString=\"{0} \" HeaderText=\"" + dt.Rows[i][7].ToString() + "\" SortField=\"" + dt.Rows[i][0].ToString() + "\" /&gt; \n";
            }
            
        }
        this.lblGrid.Text = HttpUtility.HtmlDecode(args);
    }

    void FillSQL(DataTable dt)
    {
        string args = string.Empty;
        args += "// Insert \n";
        args += "string strSQL = @\"Insert Into " + this.drpTable.SelectedText + "(  ";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i == dt.Rows.Count - 1)
            {
                args += dt.Rows[i][0].ToString() + ") \n";
            }
            else
            {
                args += dt.Rows[i][0].ToString() + ",";
            }
        }

        args += "Values  (";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i == dt.Rows.Count - 1)
            {
                args +="'\" + " + dt.Rows[i][0].ToString() + ".Text) \n";
            }
            else 
            {
                args += "'\" +" +  dt.Rows[i][0].ToString() + ".Text + @\"', \n";
            }
        }
        args += "DB.getObject().Execute(strSQL, Params, false); \n";
        args += "} \n";

        args += "\n// Update \n";
        
        args += "string strSQL = @\"Update " + this.drpTable.SelectedText + "  Set \n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i == dt.Rows.Count - 1)
            {
                args += dt.Rows[i][0].ToString() + "=" + dt.Rows[i][0].ToString() + ".Text\n";
            }
            else
            {
                args += dt.Rows[i][0].ToString() + "=" + dt.Rows[i][0].ToString() + ".Text, \";\n";
            }
        }
        //args += "Where ID ='\" + ID.text + \"'";
        args += "Where " + dt.Rows[0][0].ToString() + " = " + dt.Rows[0][0].ToString() + " \";\n";
        
        args += "DB.getObject().Execute(strSQL, Params, false); \n";
        args += "} \n\n";
        args += "\n// Delete \n";
        args += "public static void " + this.drpTable.SelectedText.Replace("tbl", "") + "Del(string SNo)  \n";
        args += "{ \n";
        args += "string strSQL = @\"Delete  " + this.drpTable.SelectedText + " Where " + dt.Rows[0][0].ToString() + " = @" + dt.Rows[0][0].ToString() + "\"; \n";
        args += "ArrayList Params = new ArrayList();\n";
        args += "Params.Add(new SqlParameter(\"@SNo\", SNo));\n";
        args += "DB.getObject().Execute(strSQL, Params, false);\n";
        args += "}\n\n";
        this.lblSQL.Text = args;
    }

}