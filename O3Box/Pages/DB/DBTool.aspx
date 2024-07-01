<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DBTool.aspx.cs" Inherits="Test_DBTool" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:DropDownList ID="drpTable" runat="server"></asp:DropDownList>
            <asp:Button runat="server" ID="btnSubmit" Text="產生" OnClick="btnSubmit_Click1"/><br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
