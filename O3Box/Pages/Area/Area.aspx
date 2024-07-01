<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Area.aspx.cs" Inherits="Area" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>彤鑫管理系統</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" ></f:PageManager>
        <f:Grid ID="Grid1" Title="營業處管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="AreaID ,AreaName"  SortField="AreaID" SortDirection="Desc"  >
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server" >
                    <Items>
                        <f:Button runat="server" ID ="btnAdd" Icon="Add" Text="增加" OnClick="btnAdd_Click" ></f:Button>
                        <f:Textbox runat="server" ID ="txtSearch" Label="模糊查詢" EmptyText="請輸入編號或名稱查詢"></f:Textbox>
                        <f:Button ID="btnSelectItem6" Text="查詢" runat="server"  OnClick="btnSelectItem6_Click" Icon="Zoom" />
                        <f:Button ID="btnRefresh" Text="重置" runat="server"   Icon="Reload" OnClick="btnRefresh_Click" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="導出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField Width="200px" DataField="AreaID" DataFormatString="{0} " HeaderText="營業處ID" SortField="StockID" /> 
                <f:BoundField Width="200px" DataField="AreaName" DataFormatString="{0} " HeaderText="營業處名稱" SortField="StockName" /> 
                <f:BoundField Width="100px" DataField="CreateTime" DataFormatString="{0} " HeaderText="建檔時間" SortField="CreateTime" Hidden="true" /> 
                <f:BoundField Width="100px" DataField="CreateUser" DataFormatString="{0} " HeaderText="建檔者" SortField="CreateUser" Hidden="true" /> 
                <f:BoundField Width="100px" DataField="EditTime" DataFormatString="{0} " HeaderText="更檔時間" SortField="EditTime" Hidden="true" /> 
                <f:BoundField Width="100px" DataField="EditUser" DataFormatString="{0} " HeaderText="更檔者" SortField="EditUser" Hidden="true" /> 
                <f:BoundField Width="100px" DataField="StatusCode" DataFormatString="{0} " HeaderText="顯示" SortField="StatusCode" Hidden="true" /> 
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="60px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="刪除" Icon="ApplicationDelete" ToolTip="刪除"  Width="60px" CommandName="Action2" ConfirmText="確定要刪除嗎？" />
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
                                <f:TextBox runat = "server" ID = "AreaID" Label = "營業處ID" Required = "true" ShowRedStar="true" />
                                <f:TextBox runat = "server" ID = "AreaName" Label = "營業處名稱" Required = "true" ShowRedStar="true" />
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
