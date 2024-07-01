using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class DB_DBList : System.Web.UI.Page
{
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            BindGrid();
        }
    }

    #region "Grid 操作"

    void BindGrid()
    {
        string sortField = Grid1.SortField;
        string sortDirection = Grid1.SortDirection;
        string strSQL = @"Select 
	                            (convert(nvarchar(50) ,IsNull(B.Description,''))) as TableDesc , A.TABLE_NAME
                            From INFORMATION_SCHEMA.TABLES A
                            Left join 
                            (
                            SELECT sys.objects.name AS TableName, ep.name AS PropertyName,
                                   ep.value AS Description
                            FROM sys.objects
                            CROSS APPLY fn_listextendedproperty(default,
                                                                'SCHEMA', schema_name(schema_id),
                                                                'TABLE', name, null, null) ep
                            WHERE sys.objects.name NOT IN ('sysdiagrams')
                            ) B on A.TABLE_NAME = B.TableName 
                            Order by A.TABLE_NAME";
        dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        Grid1.RecordCount = dt.Rows.Count;
        DataView view1 = dt.DefaultView;
        view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
        ViewState["dt"] = dt;
        Grid1.DataSource = view1;
        Grid1.DataBind();
        //FineUIPro.Alert.Show(strSQL);
    }
    //事件
    protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        
    }

    protected void Grid1_RowDoubleClick(object sender, FineUIPro.GridRowClickEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
    }
    protected void Grid1_PageIndexChange(object sender, FineUIPro.GridPageEventArgs e)
    {
        Grid1.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    //排序
    protected void Grid1_Sort(object sender, FineUIPro.GridSortEventArgs e)
    {
        BindGrid();
    }

    protected void Grid1_AfterEdit(object sender, FineUIPro.GridAfterEditEventArgs e)
    {
        Dictionary<int, Dictionary<string, object>> modifiedDict = Grid1.GetModifiedDict();

        foreach (int rowIndex in modifiedDict.Keys)
        {
            string rowID = Grid1.DataKeys[rowIndex][0].ToString();
            DataRow row = FindRowByID(rowID);
            //FineUIPro.Alert.Show(rowID.ToString());
            //UpdateDataRow(modifiedDict[rowIndex], row);
        }
        //FineUIPro.Alert.Show(Grid1.GetModifiedData().ToString(Newtonsoft.Json.Formatting.Indented));
        string jsonData = Grid1.GetModifiedData().ToString(Newtonsoft.Json.Formatting.Indented).Replace("[","").Replace("]","");
        JObject jsonObj = JObject.Parse(jsonData);
        string originalIndex = jsonObj["originalIndex"].ToString();
        string NewDesc = ((JObject)jsonObj["values"])["TableDesc"].ToString();
        //FineUIPro.Alert.Show(originalIndex);
        object[] keys = Grid1.DataKeys[Convert.ToInt16(originalIndex)];
        //FineUIPro.Alert.Show(keys[0].ToString() + "-" + NewDesc);
        string strSQL = "exec sp_ModifyTableDesc '" + keys[0].ToString() + "',N'" + NewDesc + "'";
        DB.getObject().Execute(strSQL, null, false);
        BindGrid();
    }
    public class Values
    {
        public string TableDesc { get; set; }
    }

    public class MyArray
    {
        public int index { get; set; }
        public Values values { get; set; }
        public string status { get; set; }
        public int originalIndex { get; set; }
        public string id { get; set; }
    }
    private DataRow FindRowByID(string rowID)
    {
        DataTable table = (DataTable)ViewState["dt"];
        foreach (DataRow row in table.Rows)
        {
            if (row["Table_Name"].ToString() == rowID)
            {
                return row;
            }
        }
        return null;
    }
    
    #endregion

    #region "Export To Excel"
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + this.Grid1.Title + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        Response.ContentType = "application/vnd.ms-excel";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.Write(GetGridTableHtml(Grid1));
        Response.End();
    }

    private string GetGridTableHtml(FineUIPro.Grid grid)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("<meta http-equiv=\"Content-Type\" content=\"application/vnd.ms-excel;charset=utf-8\"/>");


        sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");

        sb.Append("<tr>");
        foreach (FineUIPro.GridColumn column in grid.Columns)
        {
            sb.AppendFormat("<td>{0}</td>", column.HeaderText);
        }
        sb.Append("</tr>");


        foreach (FineUIPro.GridRow row in grid.Rows)
        {
            sb.Append("<tr>");
            foreach (object value in row.Values)
            {
                string html = value.ToString();
                if (html.StartsWith(FineUIPro.Grid.TEMPLATE_PLACEHOLDER_PREFIX))
                {
                    // 模板列
                    string templateID = html.Substring(FineUIPro.Grid.TEMPLATE_PLACEHOLDER_PREFIX.Length);
                    Control templateCtrl = row.FindControl(templateID);
                    html = GetRenderedHtmlSource(templateCtrl);
                }
                else
                {
                    // CheckBox
                    if (html.Contains("f-grid-static-checkbox"))
                    {
                        if (!html.Contains("f-checked"))
                        {
                            html = "×";
                        }
                        else
                        {
                            html = "√";
                        }
                    }

                    if (html.Contains("<img"))
                    {
                        string prefix = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
                        html = html.Replace("src=\"", "src=\"" + prefix);
                    }
                }

                sb.AppendFormat("<td>{0}</td>", html);
            }
            sb.Append("</tr>");
        }

        sb.Append("</table>");

        return sb.ToString();
    }

    private string GetRenderedHtmlSource(Control ctrl)
    {
        if (ctrl != null)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    ctrl.RenderControl(htw);

                    return sw.ToString();
                }
            }
        }
        return String.Empty;
    }
    #endregion

    
}