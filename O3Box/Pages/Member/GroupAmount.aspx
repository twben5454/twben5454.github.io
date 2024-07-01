<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupAmount.aspx.cs" Inherits="GroupAmount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CatchaFace</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>        
        <f:Grid ID="Grid1" Title="組織業績記錄" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"  
            DataKeyNames="OrderID ,MemberID"  SortField="MemberID" SortDirection="Desc"  >
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server" >
                    <Items>
                        <f:DropDownList runat="server" ID="YM" Label="年月" LabelAlign="Right"></f:DropDownList>
                        <f:Textbox runat="server" ID ="txtSearch" Label="關鍵字查詢" EmptyText=""></f:Textbox>
                        <f:Button ID="btnSelectItem6" Text="查詢" runat="server"  OnClick="btnSelectItem6_Click" Icon="Zoom" />
                        <f:Button ID="btnRefresh" Text="重新整理" runat="server"   Icon="Reload" OnClick="btnRefresh_Click" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="導出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField Width="150px" DataField="MemberID" DataFormatString="{0} " HeaderText="會員ID" SortField="MemberID" /> 
                <f:BoundField Width="150px" DataField="MemberName" DataFormatString="{0} " HeaderText="會員姓名" SortField="MemberName" /> 
                <f:BoundField Width="150px" DataField="MemberClassID" DataFormatString="{0} " HeaderText="會員等級" SortField="MemberClassID" /> 
                <f:BoundField Width="150px" DataField="lvl" DataFormatString="{0} " HeaderText="階數" SortField="lvl" /> 
                <f:BoundField Width="150px" DataField="JoinDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="加入日期" SortField="JoinDate" /> 
                <f:BoundField Width="150px" DataField="PersonAmount" DataFormatString="{0:N0} " HeaderText="個人業績" SortField="PersonAmount"  TextAlign="Right" /> 
                <f:BoundField Width="150px" DataField="GroupAmount" DataFormatString="{0:N0} " HeaderText="組織業績" SortField="GroupAmount" TextAlign="Right" /> 
            </Columns>
        </f:Grid>
       
    </form>
</body>
</html>
