<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestBonus.aspx.cs" Inherits="Test_TestBonus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <f:PageManager ID="PageManager1"  runat="server"  ></f:PageManager>
        <f:TextBox runat="server" ID="TextBox1" Label  ="會員編號" Text="TW800420"></f:TextBox>
        <f:Button runat="server" ID="Button10" Text="DataTable" OnClick="Button10_Click"></f:Button><br />
        <f:Grid runat="server" ID="Grid1" EnableColumnLines="true">
             <Columns>
                <f:BoundField Width="90px" DataField="MemberID" DataFormatString="{0} " HeaderText="MemberID" SortField="MemberID" /> 
                <f:BoundField Width="90px" DataField="MemberName" DataFormatString="{0} " HeaderText="Name" SortField="MemberName" /> 
                <f:BoundField Width="90px" DataField="MemberClassID" DataFormatString="{0} " HeaderText="ClassID" SortField="MemberClassID" />     
                <f:BoundField Width="90px" DataField="Lvl" DataFormatString="{0} " HeaderText="Lvl" SortField="Lvl" />     
                <f:BoundField Width="90px" DataField="UpClassID" DataFormatString="{0} " HeaderText="UpClassID" SortField="MemberClassID" />     
                <f:BoundField Width="90px" DataField="GroupAmount" DataFormatString="{0} " HeaderText="Amount" SortField="MemberClassID" />     
                <f:BoundField Width="90px" DataField="BALvl" DataFormatString="{0} " HeaderText="BALvl" SortField="MemberClassID" />     
                <f:BoundField Width="90px" DataField="PALvl" DataFormatString="{0} " HeaderText="PALvl" SortField="MemberClassID" />     
                <f:BoundField Width="90px" DataField="ALvl" DataFormatString="{0} " HeaderText="ALvl" SortField="MemberClassID" />     
                <f:BoundField Width="90px" DataField="LALvl" DataFormatString="{0} " HeaderText="LALvl" SortField="MemberClassID" />     
                <f:BoundField Width="90px" DataField="A10Lvl" DataFormatString="{0} " HeaderText="A10Lvl" SortField="MemberClassID" />     
                <f:BoundField Width="90px" DataField="A15Lvl" DataFormatString="{0} " HeaderText="A15Lvl" SortField="MemberClassID" />     
                <f:BoundField Width="90px" DataField="A20Lvl" DataFormatString="{0} " HeaderText="A20Lvl" SortField="MemberClassID" />       
                <f:BoundField Width="90px" DataField="BACount" DataFormatString="{0} " HeaderText="BACount" SortField="MemberClassID" />        
                <f:BoundField Width="90px" DataField="PACount" DataFormatString="{0} " HeaderText="PACount" SortField="MemberClassID" />      
                <f:BoundField Width="90px" DataField="ACount" DataFormatString="{0} " HeaderText="ACount" SortField="MemberClassID" />         
                <f:BoundField Width="90px" DataField="LACount" DataFormatString="{0} " HeaderText="LACount" SortField="MemberClassID" />         
                <f:BoundField Width="90px" DataField="A10ACount" DataFormatString="{0} " HeaderText="10ACount" SortField="MemberClassID" />         
                <f:BoundField Width="90px" DataField="A15ACount" DataFormatString="{0} " HeaderText="15Count" SortField="MemberClassID" />         
                <f:BoundField Width="90px" DataField="A20ACount" DataFormatString="{0} " HeaderText="20ACount" SortField="MemberClassID" />                     
            </Columns>
        </f:Grid>
        <f:Label runat="server" ID="Label1" Label  ="結果"></f:Label><br />
        <f:Button runat="server" ID="Button1" Text="BA1" OnClick="Button1_Click"></f:Button><br />
        <f:Button runat="server" ID="Button2" Text="BA2" OnClick="Button2_Click"></f:Button><br />
        <f:Button runat="server" ID="Button3" Text="BA3" OnClick="Button3_Click"></f:Button><br />
        <f:Button runat="server" ID="Button4" Text="BA4" OnClick="Button4_Click"></f:Button><br />
        <f:Button runat="server" ID="Button5" Text="PA-Lvl-1" OnClick="Button5_Click"></f:Button><br />
        <f:Button runat="server" ID="Button6" Text="PA-Lvl-2" OnClick="Button6_Click" ></f:Button><br />
        <f:Button runat="server" ID="Button7" Text="PA-Lvl-3" OnClick="Button7_Click"></f:Button><br />
        <f:Button runat="server" ID="Button8" Text="PA-Lvl-4" OnClick="Button8_Click"></f:Button><br />
        <f:Button runat="server" ID="Button9" Text="PA-Lvl-5" OnClick="Button9_Click" ></f:Button><br />
    </form>
</body>
</html>
