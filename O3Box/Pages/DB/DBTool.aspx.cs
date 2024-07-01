using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class Test_DBTool : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string strSQL = string.Empty;

            DataTable dt = DB.getObject().GetData(@"Use O3BoxDB  select * from sysobjects where type = 'u' order by name").ReturnDataTable;
            this.drpTable.DataSource = dt;
            this.drpTable.DataTextField = "name";
            this.drpTable.DataValueField = "name";
            this.drpTable.DataBind();
        }
    }



    protected DataTable GetDT()
    {
        string strSQL = @" Use O3BoxDB 
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
                            WHERE d.name = '" + this.drpTable.SelectedValue + @"'
                            ORDER BY a.id ,
                            a.colorder";
        DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
        return dt;
    }



    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string args = string.Empty;
        string strSQL = string.Empty;
        DataTable dt = GetDT();
        args += "-- Class \n";
        args += "public class " + this.drpTable.SelectedValue.Replace("tbl", "") + "Model\n";
        args += "{ \n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            args += "// " + dt.Rows[i]["字段說明"].ToString() + "\n";
            args += "public string " + dt.Rows[i][0].ToString() + " { get; set; }\n";
        }
        args += "} \n";
        args += "-- Insert \n";
        args += "public static void " + this.drpTable.SelectedValue.Replace("tbl", "") + "Create(" + this.drpTable.SelectedValue.Replace("tbl", "") + "Model " + this.drpTable.SelectedValue.Replace("tbl", "") + ") \n";
        args += "{ \n";
        args += "string strSQL = @\"Insert Into " + this.drpTable.SelectedValue + "(  ";
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
            args += "Params.Add(new SqlParameter(\"@" + dt.Rows[i][0].ToString() + "\", " + this.drpTable.SelectedValue.Replace("tbl", "") + "." + dt.Rows[i][0].ToString() + "));\n";
        }
        args += "DB.getObject().Execute(strSQL, Params, false); \n";
        args += "} \n";

        args += "\n-- Update \n";
        args += "public static void " + this.drpTable.SelectedValue.Replace("tbl", "") + "Edit(" + this.drpTable.SelectedValue.Replace("tbl", "") + "Model " + this.drpTable.SelectedValue.Replace("tbl", "") + ") \n";
        args += "{ \n";
        args += "string strSQL = @\"Update " + this.drpTable.SelectedValue + "  Set \n";
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
            args += "Params.Add(new SqlParameter(\"@" + dt.Rows[i][0].ToString() + "\", " + this.drpTable.SelectedValue.Replace("tbl", "") + "." + dt.Rows[i][0].ToString() + "));\n";
        }
        args += "DB.getObject().Execute(strSQL, Params, false); \n";
        args += "} \n\n";
        args += "\n-- Delete \n";
        args += "public static void " + this.drpTable.SelectedValue.Replace("tbl", "") + "Del(string SNo)  \n";
        args += "{ \n";
        args += "string strSQL = @\"Delete  " + this.drpTable.SelectedValue + " Where " + dt.Rows[0][0].ToString() + " = @" + dt.Rows[0][0].ToString() + "\"; \n";
        args += "ArrayList Params = new ArrayList();\n";
        args += "Params.Add(new SqlParameter(\"@SNo\", SNo));\n";
        args += "DB.getObject().Execute(strSQL, Params, false);\n";
        args += "}\n\n";

        args += "\n-- Detail \n";
        args += "public static " + this.drpTable.SelectedValue.Replace("tbl", "") + "Model  " + this.drpTable.SelectedValue.Replace("tbl", "") + "Detail(string SNo)  \n";
        args += "{ \n";
        args += this.drpTable.SelectedValue.Replace("tbl", "") + "Model " + this.drpTable.SelectedValue.Replace("tbl", "") + " = new " + this.drpTable.SelectedValue.Replace("tbl", "") + "Model();\n";
        args += "string strSQL = @\"Select * From  " + this.drpTable.SelectedValue + " Where SNo = @SNo \";\n";
        args += "ArrayList Params = new ArrayList();\n";
        args += "Params.Add(new SqlParameter(\"@SNo\", SNo));\n";
        args += "DataTable dt =DB.getObject().GetData(strSQL, Params, false).ReturnDataTable;\n";
        args += "if (dt.Rows.Count > 0)\n";
        args += "{\n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            args += "    " + this.drpTable.SelectedValue.Replace("tbl", "") + "." + dt.Rows[i][0].ToString() + " =  dt.Rows[0][\"" + dt.Rows[i][0].ToString() + "\"].ToString();\n";
        }       
            
        args += "}\n";
        args += "return " + this.drpTable.SelectedValue.Replace("tbl", "") + ";\n";
        args += "}\n\n";

        args += "\n-- Form \n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            args += "&lt;td class=\"center\"&gt;&lt;%#Eval(\"" + dt.Rows[i][0].ToString() + "\")%&gt;&lt;/td&gt; \n";
        }
        args += "\n\n";

        args += "\n-- EidtForm \n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            args += "&lt;label for= \"input" + dt.Rows[i][0].ToString() + "\" >" + dt.Rows[i][7].ToString() + "&lt;/label&gt; \n";
            args += "&lt;asp:TextBox runat = \"server\" ID = \"" + dt.Rows[i][0].ToString() + "\" CssClass = \"form-control\" placeholder = \"" + dt.Rows[i]["字段說明"].ToString() + "\" required = \"required\" type = \"text\" /&gt;\n";
            args += "&lt;div class=\"help-block with-errors\">&lt;/div&gt;\n";
        }
        args += "\n\n";
        args += "//FillData()\n";
        args += this.drpTable.SelectedValue.Replace("tbl", "") + "Model " + this.drpTable.SelectedValue.Replace("tbl", "") + " = " + this.drpTable.SelectedValue.Replace("tbl", "") + "Model." + this.drpTable.SelectedValue.Replace("tbl", "") + "Detail(Request.QueryString[\"id\"].ToString()); \n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            args += "this." + dt.Rows[i][0].ToString() + ".Text = " + this.drpTable.SelectedValue.Replace("tbl", "") + "." + dt.Rows[i][0].ToString() + "; \n";
        }

        args += "//Create \n";
        args += this.drpTable.SelectedValue.Replace("tbl", "") + "Model " + this.drpTable.SelectedValue.Replace("tbl", "") + " = new " + this.drpTable.SelectedValue.Replace("tbl", "") + "Model(); \n";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            args += this.drpTable.SelectedValue.Replace("tbl", "") + "." + dt.Rows[i][0].ToString() + " = this." + dt.Rows[i][0].ToString() + ".Text;\n";
        }
        args += "try \n";
        args += "{ \n";
        args += this.drpTable.SelectedValue.Replace("tbl", "") + "Model." + this.drpTable.SelectedValue.Replace("tbl", "") + "Edit(" + this.drpTable.SelectedValue.Replace("tbl", "") + "); \n";
        args += "Response.Write(\" < script>alert('更改成功!!');window.parent.location.reload();</script> \"); \n";
        args += "} \n";
        args += "catch \n";
        args += "{ \n";
        args += "} \n";
        //args += "-- Insert \n";
        //args += "Insert Into " + this.drpTable.SelectedValue + "(  \n";
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    if (i == dt.Rows.Count - 1)
        //    {
        //        args += dt.Rows[i][0].ToString() + ") \n";
        //    }
        //    else
        //    {
        //        args += dt.Rows[i][0].ToString() + ",";
        //    }
        //}
        //args += "Values  \n";
        //args += "(";
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    if (i == dt.Rows.Count - 1)
        //    {
        //        args += "'\" + " + dt.Rows[i][0].ToString() + ".Text + @\"'\n";
        //    }
        //    else
        //    {
        //        args += "'\" + " + dt.Rows[i][0].ToString() + ".Text + @\"',\n";
        //    }
        //}
        //args += ")\n";
        //// <f:TextBox runat="server" ID="SDate" Label ="起"/>
        ////args += "\n-- SqlParameter \n";
        ////args += "ArrayList sp = new ArrayList();";
        ////for (int i = 0; i < dt.Rows.Count; i++)
        ////{
        ////    args += "sp.Add(new SqlParameter(\"@" + dt.Rows[i][0].ToString() + "\", " + dt.Rows[i][0].ToString() + ".Text)); \n";
        ////}
        ////args += "\n-- Grid \n";
        ////for (int i = 0; i < dt.Rows.Count; i++)
        ////{
        ////    args += "<f:BoundField Width=\"100px\" DataField=\"" + dt.Rows[i][0].ToString() + "\" DataFormatString=\"{0} \" HeaderText=\"" + dt.Rows[i]["字段说明"].ToString() + "\" SortField=\"" + dt.Rows[i][0].ToString() + "\" /> \n";
        ////}
        ////args += "\n-- Form \n";
        ////for (int i = 0; i < dt.Rows.Count; i++)
        ////{
        ////    if (dt.Rows[i]["类型"].ToString() == "date")
        ////    {
        ////        args += "<f:DatePicker runat=\"server\" ID=\"" + dt.Rows[i][0].ToString() + "\" Label =\"" + dt.Rows[i]["字段说明"].ToString() + "\" Required=\"false\"/> \n";
        ////    }
        ////    else
        ////    {
        ////        args += "<f:TextBox runat=\"server\" ID=\"" + dt.Rows[i][0].ToString() + "\" Label =\"" + dt.Rows[i]["字段说明"].ToString() + "\" Required=\"false\"/> \n";
        ////    }
        ////}
        //args += "\n-- Update \n";
        //args += "Update " + this.drpTable.SelectedValue + "  Set \n";
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    if (i == dt.Rows.Count - 1)
        //    {
        //        args += dt.Rows[i][0].ToString() + "='\" + " + dt.Rows[i][0].ToString() + ".Text + @\"'\n";
        //    }
        //    else
        //    {
        //        args += dt.Rows[i][0].ToString() + "='\" + " + dt.Rows[i][0].ToString() + ".Text + @\"',\n";
        //    }
        //}
        ////args += "Where ID ='\" + ID.text + \"'";
        //args += "Where " + dt.Rows[0][0].ToString() + " = @" + dt.Rows[0][0].ToString() + " \n";
        //args += "\n-- Delete \n";
        //args += "Delete  " + this.drpTable.SelectedValue + " Where " + dt.Rows[0][0].ToString() + " = txt" + dt.Rows[0][0].ToString() + " \n";
        //args += "\n-- FillData \n";
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{

        //    args += "this." + dt.Rows[i][0].ToString() + ".Text= dt.Rows[0][\"" + dt.Rows[i][0].ToString() + "\"].ToString();  \n";


        //}


        Label1.Text =args.Replace("\n","<br>");


    }
}