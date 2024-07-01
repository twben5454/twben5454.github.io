<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="OrderList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CatchaFace</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:Grid ID="Grid1" Title="訂單管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"  
            DataKeyNames="OrderID ,BonusClassID ,Amount"  SortField="OrderID" SortDirection="Desc"  >
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server" >
                    <Items>
                        <f:Button runat="server" ID ="btnAdd" Icon="Add" Text="新增" OnClick="btnAdd_Click" ></f:Button>
                        <f:Textbox runat="server" ID ="txtSearch" Label="關鍵字查詢" EmptyText=""></f:Textbox>
                        <f:DatePicker runat="server" ID="SDate" Label="起" LabelAlign="Right"></f:DatePicker>
                        <f:DatePicker runat="server" ID="EDate" Label="迄" LabelAlign="Right"></f:DatePicker>
                        <f:Button ID="btnSelectItem6" Text="查詢" runat="server"  OnClick="btnSelectItem6_Click" Icon="Zoom" />
                        <f:Button ID="btnRefresh" Text="重新整理" runat="server"   Icon="Reload" OnClick="btnRefresh_Click" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="導出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField Width="150px" DataField="OrderID" DataFormatString="{0} " HeaderText="訂單ID" SortField="OrderID" /> 
                <f:BoundField Width="150px" DataField="MemberID" DataFormatString="{0} " HeaderText="會員ID" SortField="MemberID" /> 
                <f:BoundField Width="150px" DataField="MemberName" DataFormatString="{0} " HeaderText="會員姓名" SortField="MemberName" /> 
                <f:BoundField Width="150px" DataField="OrderDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="訂單日期" SortField="OrderDate" /> 
                <f:BoundField Width="150px" DataField="Amount" DataFormatString="{0:N0} " HeaderText="金額" SortField="Amount" TextAlign="Right" /> 
               <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="訂單內容" Icon="ApplicationSideList" ToolTip="訂單內容"  Width="100px" CommandName="Action1" />
            </Columns>
        </f:Grid>
        <f:Window runat="server" ID="Window1" Width="1200" Height="700" EnableIFrame="true" Hidden="true" Title ="訂單明細"></f:Window>
    </form>
</body>
</html>
