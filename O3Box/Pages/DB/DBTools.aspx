<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DBTools.aspx.cs" Inherits="Pages_DB_DBTools" validateRequest="False"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1"  runat="server" AjaxAspnetControls="lblForm"></f:PageManager>
        <f:DropDownList ID ="drpDataBase" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="drpDataBase_SelectedIndexChanged"></f:DropDownList>
        <f:DropDownList ID="drpTable" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="drpTable_SelectedIndexChanged"></f:DropDownList>
         <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" Height="850px" ShowBorder="true" TabPosition="Top"
            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
            <Tabs>
                <f:Tab Title="Class" BodyPadding="10px" Layout="Fit" runat="server">
                    <Items>
                       <f:TextArea runat="server" ID ="lblClass" Width="1800" Height="850px"></f:TextArea>
                    </Items>
                </f:Tab>
                <f:Tab Title="CDRU" BodyPadding="10px" runat="server">
                    <Items>
                        <f:TextArea runat="server" ID ="lblCDRU" Width="1800" Height="850px"></f:TextArea>
                    </Items>
                </f:Tab>
                <f:Tab Title="Detail" BodyPadding="10px" runat="server">
                    <Items>                        
                        <f:TextArea runat="server" ID ="lblDetailFineUI" Width="1800" Height="850px"></f:TextArea>
                    </Items>
                </f:Tab>
                <f:Tab Title="Form" BodyPadding="10px" runat="server">
                    <Items>      
                        <f:TextArea runat="server" ID ="lblForm" Width="1800" Height="850px"></f:TextArea>
                    </Items>
                </f:Tab>
                <f:Tab Title="Add" BodyPadding="10px" runat="server">
                    <Items>      
                        <f:TextArea runat="server" ID ="lblAdd" Width="1800" Height="850px"></f:TextArea>
                    </Items>
                </f:Tab>
                <f:Tab Title="常用" BodyPadding="10px" runat="server">
                    <Items>      
                        <f:TextArea runat="server" ID ="lblBen" Width="1800" Height="850px"></f:TextArea>
                    </Items>
                </f:Tab>
                <f:Tab Title="Grid" BodyPadding="10px" runat="server">
                    <Items>      
                        <f:TextArea runat="server" ID ="lblGrid" Width="1800" Height="850px"></f:TextArea>
                    </Items>
                </f:Tab>
                <f:Tab Title="SQL" BodyPadding="10px" runat="server">
                    <Items>      
                        <f:TextArea runat="server" ID ="lblSQL" Width="1800" Height="850px"></f:TextArea>
                    </Items>
                </f:Tab>
            </Tabs>
        </f:TabStrip>
    </form>
</body>
</html>
 