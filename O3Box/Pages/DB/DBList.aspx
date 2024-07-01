<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DBList.aspx.cs" Inherits="DB_DBList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server"></f:PageManager>
        <f:Grid ID="Grid1" Title="資料庫 Table 管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"  EnableRowDoubleClickEvent="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"  EnableTextSelection="true"  OnRowDoubleClick="Grid1_RowDoubleClick"
            DataKeyNames="Table_Name"  SortField="Table_Name" SortDirection="Asc"  AllowCellEditing="true" ClicksToEdit="1"
            EnableAfterEditEvent="true" OnAfterEdit="Grid1_AfterEdit" >
            <Toolbars>
                <f:Toolbar ID="Toolbar2" Position="Top" runat="server" >
                    <Items>
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="導出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
                </Toolbars>
            <Columns>
                <f:RowNumberField />
                     <f:HyperLinkField HeaderText="資料表" DataToolTipField="Table_Name" DataTextField="Table_Name"
                        DataTextFormatString="{0}" DataNavigateUrlFields="Table_Name" DataNavigateUrlFormatString="Table.aspx?id={0}" UrlEncode="true"
                        Target="_self"  MinWidth="150px" />
                   <%-- <f:BoundField Width="150px" DataField="Table_Name" DataFormatString="{0} " HeaderText="資料表" SortField="Table_Name" /> --%>
                    <f:RenderField Width="400px" ColumnID="TableDesc" DataField="TableDesc"  HeaderText="說明" ExpandUnusedSpace="true">
                        <Editor>
                            <f:TextBox ID="tbxEditorName" Required="true" runat="server">
                            </f:TextBox>
                        </Editor>
                    </f:RenderField>
            </Columns>
        </f:Grid>
    </form>
</body>
</html>
