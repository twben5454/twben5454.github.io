<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Table.aspx.cs" Inherits="Table" %>

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
            runat="server" EnableCheckBoxSelect="false" AllowPaging="false" PageSize="15" AllowSorting="true" ShowSelectedCell="true"  EnableRowDoubleClickEvent="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"  EnableTextSelection="true"  OnRowDoubleClick="Grid1_RowDoubleClick"
            DataKeyNames="字段名"  SortField="PrimaryKey" SortDirection="Desc"  AllowCellEditing="true" ClicksToEdit="1"
            EnableAfterEditEvent="true" OnAfterEdit="Grid1_AfterEdit" >
            <Toolbars>
                <f:Toolbar ID="Toolbar2" Position="Top" runat="server" >
                    <Items>
                        <f:Button runat="server" ID ="btnBack" Icon="ArrowLeft" Text="回資料表列表" OnClick="btnBack_Click"></f:Button>
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="導出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
                </Toolbars>
            <Columns>
                <f:RowNumberField />
                    <f:BoundField Width="150px" DataField="字段名" DataFormatString="{0} " HeaderText="字段名" SortField="Table_Name" /> 
                    <f:BoundField Width="150px" DataField="標識" DataFormatString="{0} " HeaderText="標識" SortField="標識" /> 
                    <f:BoundField Width="150px" DataField="PrimaryKey" DataFormatString="{0} " HeaderText="PrimaryKey" SortField="PrimaryKey" /> 
                    <f:BoundField Width="150px" DataField="類型" DataFormatString="{0} " HeaderText="類型" SortField="類型" /> 
                    <f:BoundField Width="150px" DataField="長度" DataFormatString="{0} " HeaderText="長度" SortField="長度" /> 
                    <f:BoundField Width="150px" DataField="小位數" DataFormatString="{0} " HeaderText="小位數" SortField="小位數" /> 
                    <f:BoundField Width="150px" DataField="允許空" DataFormatString="{0} " HeaderText="允許空" SortField="允許空" /> 
                    <f:RenderField Width="400px" ColumnID="TableDesc" DataField="字段說明"  HeaderText="字段說明" ExpandUnusedSpace="true">
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
