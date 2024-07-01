<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupBonus.aspx.cs" Inherits="GroupBonus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>彤鑫管理系統</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>        
        <f:Grid ID="Grid1" Title="組織獎金業績查詢" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"  
            DataKeyNames="MemberID"  SortField="OrderID" SortDirection="Desc" EnableTextSelection="true"  >
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server" >
                    <Items>
                        <f:DropDownList runat="server" ID="YM" Label="年月" LabelAlign="Right"></f:DropDownList>
                        <f:Button ID="btnSelectItem6" Text="查詢" runat="server"  OnClick="btnSelectItem6_Click" Icon="Zoom" />
                        <f:Button ID="btnRefresh" Text="重新整理" runat="server"   Icon="Reload" OnClick="btnRefresh_Click" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="導出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField Width="150px" DataField="MemberID" DataFormatString="{0} " HeaderText="會員ID" SortField="MemberID" /> 
                <f:BoundField Width="150px" DataField="MemberName" DataFormatString="{0} " HeaderText="會員姓名" SortField="MemberName" /> 
                <f:BoundField Width="150px" DataField="lvl" DataFormatString="{0} " HeaderText="階數" SortField="lvl" /> 
                <f:BoundField Width="200px" DataField="OrderID" DataFormatString="{0} " HeaderText="訂單ID" SortField="OrderID" /> 
                <f:BoundField Width="200px" DataField="MemberID" DataFormatString="{0} " HeaderText="訂單會員" SortField="MemberID" /> 
                <f:BoundField Width="200px" DataField="BonusPercent" DataFormatString="{0:N0} " HeaderText="獎金百分比" SortField="BonusPercent" TextAlign="Right" />  
                <f:BoundField Width="200px" DataField="Bonus" DataFormatString="{0:N0} " HeaderText="獎金" SortField="Bonus"  TextAlign="Right"/>  
            </Columns>
        </f:Grid>
       
    </form>
</body>
</html>
