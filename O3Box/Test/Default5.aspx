<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
    <style>
        .f-grid-row-summary .f-grid-cell-inner {
            font-weight: bold;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1"  runat="server"  AutoSizePanelID="Panel1"/>
        <f:RadioButtonList runat="server" ID="textBox1" Label="OrderID" ColumnNumber="6" AutoPostBack="true" OnSelectedIndexChanged="textBox1_SelectedIndexChanged"></f:RadioButtonList>
       
        <f:Grid ID="Grid1" Title="訂單獎金管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"            
            DataKeyNames=""  SortField="lvl" SortDirection="Asc"  EnableTextSelection="true" EnableSummary="true" SummaryPosition="Flow" EnableColumnLines="true">
            <Columns>
                <f:BoundField Width="100px" DataField="YM" DataFormatString="{0} " HeaderText="YM" SortField="YM" /> 
                <f:BoundField Width="150px" DataField="OrderID" DataFormatString="{0} " HeaderText="OrderID" SortField="OrderID" /> 
                <f:BoundField Width="100px" DataField="Amount" DataFormatString="{0:N0} " HeaderText="Amount" SortField="Amount" TextAlign="Right" /> 
                <f:BoundField Width="150px" DataField="OrderMemberID" DataFormatString="{0} " HeaderText="OrderMemberID" SortField="OrderMemberID" /> 
                <f:BoundField Width="100px" DataField="MemberID" DataFormatString="{0} " HeaderText="MemberID" SortField="MemberID" /> 
                <f:BoundField Width="150px" DataField="MemberClassID" DataFormatString="{0} " HeaderText="MemberClassID" SortField="MemberClassID" />
                <f:BoundField Width="150px" DataField="BonusPercent" DataFormatString="{0:N0} " HeaderText="BonusPercent" SortField="BonusPercent"  TextAlign="Right" ColumnID="BonusPercent"/> 
                <f:BoundField Width="100px" DataField="Bonus" DataFormatString="{0:N0} " HeaderText="Bonus" SortField="Bonus"  TextAlign="Right"/> 
            </Columns>
        </f:Grid>
    </form>
</body>
</html>
