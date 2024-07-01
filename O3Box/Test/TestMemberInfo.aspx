<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestMemberInfo.aspx.cs" Inherits="Test_TestMemberInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
         <f:Grid ID="Grid1" Title="會員資訊管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"   IsDatabasePaging="true"            EnableTextSelection="true"  
            DataKeyNames="MemberID"  SortField="CustomerID" SortDirection="Desc"  ForceFit="true" >
            <Toolbars>
                <f:Toolbar ID="Toolbar2" Position="Top" runat="server" >
                    <Items>                        
                        <f:TextBox runat="server" ID="MemberID" Label="會員ID" Text="TW800322" />
                        <f:Button ID="btnSearch" Text="查詢" runat="server"  OnClick="btnSearch_Click" Icon="Zoom" />
                    </Items>
                </f:Toolbar>
                </Toolbars>
            <Columns>
                    <f:BoundField Width="100px" DataField="UpMemberID" DataFormatString="{0} " HeaderText="上線會員ID" SortField="UpMemberID"  /> 
                    <f:BoundField Width="100px" DataField="MemberClassID" DataFormatString="{0} " HeaderText="上線會員等級" SortField="MemberClassID" /> 
                    <f:BoundField Width="100px" DataField="MemberName" DataFormatString="{0} " HeaderText="上線會員名稱" SortField="MemberName" /> 
                    <f:BoundField Width="100px" DataField="lvl" DataFormatString="{0} " HeaderText="等級" SortField="lvl"  /> 
                    <f:BoundField Width="100px" DataField="GroupAmount" DataFormatString="{0:N0} " HeaderText="組織業績" SortField="GroupAmount" TextAlign="Right"  /> 
                    <f:BoundField Width="100px" DataField="SubMemberClassIDCount" DataFormatString="{0:N0} " HeaderText="下線同階數" SortField="GroupAmount" TextAlign="Right"  /> 
            </Columns>
        </f:Grid>
    </form>
</body>
</html>
