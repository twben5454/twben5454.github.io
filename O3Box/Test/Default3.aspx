<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Test_Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1"  runat="server"  AutoSizePanelID="Panel1"/>
        <f:TextBox runat="server" ID="textBox1" Label="OrderID" Text="202104030001"></f:TextBox>
        <f:Button runat="server" ID="btnButton" Text="Search" OnClick="btnButton_Click"></f:Button></br>
        <f:Button runat="server" ID="Button1" Text="AAA" OnClick="Button1_Click"></f:Button></br>
        <f:Label runat="server" ID="lbl1" Label="Result"></f:Label>
        <f:Grid ID="Grid1" Title="文章管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"            
            DataKeyNames=""  SortField="lvl" SortDirection="Asc"  EnableTextSelection="true" >
            <Columns>
                <f:BoundField Width="100px" DataField="MemberID" DataFormatString="{0} " HeaderText="MemberID" SortField="MemberID" /> 
                <f:BoundField Width="150px" DataField="MeMemberClassID" DataFormatString="{0} " HeaderText="MeMemberClassID" SortField="MeMemberClassID" />
                <f:BoundField Width="100px" DataField="MeLvl" DataFormatString="{0} " HeaderText="MeLvl" SortField="MeLvl" /> 
                <f:BoundField Width="100px" DataField="YM" DataFormatString="{0} " HeaderText="YM" SortField="YM" /> 
                <f:BoundField Width="100px" DataField="Amount" DataFormatString="{0} " HeaderText="Amount" SortField="Amount" /> 
                <f:BoundField Width="150px" DataField="OrderID" DataFormatString="{0} " HeaderText="OrderID" SortField="OrderID" /> 
                <f:BoundField Width="100px" DataField="UpMemberID" DataFormatString="{0} " HeaderText="UpMemberID" SortField="UpMemberID" /> 
                <f:BoundField Width="100px" DataField="lvl" DataFormatString="{0} " HeaderText="Uplvl" SortField="lvl" /> 
                <f:BoundField Width="150px" DataField="MemberClassID" DataFormatString="{0} " HeaderText="UpMemberClassID" SortField="MemberClassID" /> 
                <f:TemplateField Width="100px" HeaderText="百分比" TextAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# GetBonusPercent(Eval("MeMemberClassID").ToString() , Eval("Melvl").ToString(), Eval("MemberClassID").ToString() ,Eval("lvl").ToString() ,true )%>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
            </Columns>
        </f:Grid>
        <f:TextArea runat="server" ID="Ben" Height="600" Width="1800"></f:TextArea>
    </form>
</body>
</html>
