<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeLink.aspx.cs" Inherits="EmployeeLink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
         <f:SimpleForm ID="SimpleForm1"  CssClass="blockpanel" BodyPadding="10px" runat="server" EnableCollapse="false"
            ShowBorder="true" Title="简单下拉列表" ShowHeader="false">
            <Items>
               <%-- <f:TextBox runat="server" ID ="CheckMName" Label="检查项目类别"/>--%>
                <f:CheckBoxList runat="server" ID="CheckDItem" Label="项目" ColumnNumber="2"/>

                <f:Button ID="btnSubmit" Text="确定送出" runat="server" CssClass="marginr" OnClick="btnSubmit_Click"/>
            </Items>
        </f:SimpleForm>
    </form>
</body>
</html>
