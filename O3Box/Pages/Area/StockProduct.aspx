<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockProduct.aspx.cs" Inherits="StockProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>彤鑫管理系統</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" ></f:PageManager>
        <f:Grid ID="Grid1" Title="商品庫存管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" IsDatabasePaging="true"
            DataKeyNames="StockID ,StockName"  SortField="StockID" SortDirection="Desc" EnableTextSelection="true"  >
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server"  >
                    <Items>
                        <f:DropDownList runat="server" ID ="YM" Label="年月" LabelAlign="Right" ></f:DropDownList>
                        <f:DropDownList runat="server" ID ="StockID" Label="倉庫" LabelAlign="Right" ></f:DropDownList>
                        <f:Textbox runat="server" ID ="txtSearch" Label="模糊查詢" EmptyText="請輸入編號或名稱查詢"></f:Textbox>
                        <f:Button ID="btnSelectItem6" Text="查詢" runat="server"  OnClick="btnSelectItem6_Click" Icon="Zoom" />
                        <f:Button ID="btnRefresh" Text="重置" runat="server"   Icon="Reload" OnClick="btnRefresh_Click" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="導出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField Width="100px" DataField="YM" DataFormatString="{0} " HeaderText="年月" SortField="YM" /> 
                <f:BoundField Width="200px" DataField="StockName" DataFormatString="{0} " HeaderText="倉庫" SortField="StockName" /> 
                <f:BoundField Width="200px" DataField="PID" DataFormatString="{0} " HeaderText="商品ID" SortField="PID" /> 
                <f:BoundField Width="200px" DataField="PName" DataFormatString="{0} " HeaderText="商品名稱" SortField="PName" /> 
                <f:BoundField Width="200px" DataField="PNum" DataFormatString="{0:N0} " HeaderText="庫存" SortField="PNum" TextAlign="Right" /> 
                <f:BoundField Width="100px" DataField="CreateTime" DataFormatString="{0} " HeaderText="建檔時間" SortField="CreateTime" Hidden="true" /> 
                <f:BoundField Width="100px" DataField="CreateUser" DataFormatString="{0} " HeaderText="建檔者" SortField="CreateUser" Hidden="true" /> 
                <f:BoundField Width="100px" DataField="EditTime" DataFormatString="{0} " HeaderText="更檔時間" SortField="EditTime" Hidden="true" /> 
                <f:BoundField Width="100px" DataField="EditUser" DataFormatString="{0} " HeaderText="更檔者" SortField="EditUser" Hidden="true" /> 
                <f:BoundField Width="100px" DataField="StatusCode" DataFormatString="{0} " HeaderText="顯示" SortField="StatusCode" Hidden="true" /> 
<%--                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="60px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="刪除" Icon="ApplicationDelete" ToolTip="刪除"  Width="60px" CommandName="Action2" ConfirmText="確定要刪除嗎？" />--%>
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="800px" Height="200px" Title="維護" BodyPadding="5px" EnableIFrame="false"
            WindowPosition="GoldenSection" EnableMaximize="true">
            <Items>
                <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="false" LabelWidth="120px"
                    Title="表單" runat="server">
                    <Rows>
                        <f:FormRow ID="FormRow5" ColumnWidths="50% 50%">
                            <Items>
                                <f:TextBox runat = "server" ID = "StockIsD" Label = "倉庫ID" Required = "true" ShowRedStar="true" />
                                <f:TextBox runat = "server" ID = "StockName" Label = "倉庫名稱" Required = "true" ShowRedStar="true" />
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Button ID="Button5" IconFont="_Save" Text="保存" ValidateForms="SimpleForm1" runat="server" OnClick="btnSubmit_Click" />
            </Items>
        </f:Window>
    </form>
</body>
</html>
