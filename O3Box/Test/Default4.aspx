<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Test_Default4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1"  runat="server"  AutoSizePanelID="Panel1"/>
        <f:Grid ID="Grid1" Title="獎金試算" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false"  PageSize="20"  ShowSelectedCell="true"            
            DataKeyNames=""   EnableTextSelection="true" >
            <Columns>
                <f:BoundField Width="100px" DataField="MemberID" DataFormatString="{0} " HeaderText="MemberID" SortField="MemberID" /> 
                <f:BoundField Width="150px" DataField="MemberClassID" DataFormatString="{0} " HeaderText="MemberClassID" SortField="MemberClassID" />
                <f:BoundField Width="150px" DataField="Lvl" DataFormatString="{0} " HeaderText="MeLvl" SortField="MeLvl" /> 
                <f:BoundField Width="150px" DataField="UpMemberID" DataFormatString="{0} " HeaderText="UpMemberID" SortField="UpMemberID" /> 
                 <f:TemplateField Width="150px" HeaderText="UpMemberClassID" TextAlign="Right">
                    <ItemTemplate>
                        <asp:DropDownList ID="drpUpMemberClassID" runat="server" ></asp:DropDownList>
                    </ItemTemplate>
                </f:TemplateField>
                <f:BoundField Width="150px" DataField="Uplvl" DataFormatString="{0} " HeaderText="Uplvl" SortField="Uplvl" /> 
                <f:TemplateField Width="150px" HeaderText="百分比" TextAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
            </Columns>
        </f:Grid>
    </form>
</body>
</html>
