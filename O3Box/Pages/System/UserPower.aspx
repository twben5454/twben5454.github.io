<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserPower.aspx.cs" Inherits="Page_System_UserPower" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
       <f:PageManager ID="PageManager1" runat="server" />
        <f:Tree ID="Tree1" IsFluid="true" CssClass="blockpanel" ShowHeader="true" EnableCollapse="false" Expanded="true"
            Title="权限设置" runat="server" EnableCheckBox="true" OnlyLeafCheck="true">
            <Toolbars>
                <f:Toolbar runat="server" ID="Toolbar1">
                    <Items>
                        <f:Button runat="server" ID ="btnAdd" Icon="DiskEdit" Text="储存" OnClick="Button5_Click" ConfirmText="确定储存吗？？" ></f:Button>
                    </Items>
                    
                </f:Toolbar>
            </Toolbars>
        </f:Tree>
    </form>
</body>
</html>
