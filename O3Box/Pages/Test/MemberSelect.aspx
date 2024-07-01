<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberSelect.aspx.cs" Inherits="Admin_Page_Test_MemberSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server"></f:PageManager>
        <f:Grid ID="Grid1" Title="會員列表" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="false" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="false" AllowSorting="false" ShowSelectedCell="true"  EnableRowDoubleClickEvent="true"
            OnRowCommand="Grid1_RowCommand"  EnableTextSelection="true"  OnRowDoubleClick="Grid1_RowDoubleClick"
            DataKeyNames="MemberID,MemberName,MemberClassID"  SortField="MemberID" SortDirection="Asc"   >
            <Toolbars>
                <f:Toolbar ID="Toolbar2" Position="Top" runat="server" >
                    <Items>                        
                        <f:Textbox runat="server" ID ="txtSearch" Label="關鍵字查詢" EmptyText="" LabelWidth="160"></f:Textbox>
                        <f:Button ID="btnSearch" Text="查詢" runat="server"  OnClick="btnSearch_Click" Icon="Zoom" />
                    </Items>
                </f:Toolbar>
                </Toolbars>
            <Columns>
                <f:RowNumberField />
                <f:BoundField Width="150px" DataField="MemberID" DataFormatString="{0} " HeaderText="會員ID" SortField="PID" /> 
                    <f:BoundField Width="250px" DataField="MemberName" DataFormatString="{0} " HeaderText="會員名稱" SortField="PName" ExpandUnusedSpace="true" MinWidth="150px" HtmlEncode="true"/> 
                    <f:BoundField Width="150px" DataField="MemberClassName" DataFormatString="{0} " HeaderText="會員等級" SortField="Spec" /> 
            </Columns>
        </f:Grid>
        <f:Tree ID="Tree1" IsFluid="true" CssClass="blockpanel" ShowHeader="true" Title="組織" EnableCollapse="true" runat="server" OnNodeCommand="Tree1_NodeCommand" Hidden="true" />
        <f:TextBox ID="TextBox1" Label="" runat="server" Required="true" Hidden="true"/>
    </form>
</body>
</html>
