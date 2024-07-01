<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server"  />
        <f:Window ID="Window1" runat="server" Title="彤鑫管理系統 " IsModal="false" EnableClose="false"
            WindowPosition="GoldenSection" Width="450px">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" BodyPadding="10px"
                    LabelWidth="80px" ShowHeader="false">
                    <Items>
                        <f:TextBox ID="tbxUserName" Label="用戶名" Required="true" runat="server" Text="">
                        </f:TextBox>
                        <f:TextBox ID="tbxPassword" Label="密碼" TextMode="Password" Required="true" runat="server" Text="">
                        </f:TextBox>
                       <%-- <f:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" Layout="HBox" BoxConfigAlign="Stretch" runat="server">
                            <Items>
                                <f:TextBox ID="tbxCaptcha" BoxFlex="1" Margin="0 5px 0 0" Label="驗證碼" Required="true" runat="server">
                                </f:TextBox>
                                <f:LinkButton ID="imgCaptcha" CssClass="imgcaptcha" Width="100px" EncodeText="false" runat="server" OnClick="imgCaptcha_Click">
                                </f:LinkButton>
                            </Items>
                        </f:Panel>--%>
                    </Items>
                </f:SimpleForm>
            </Items>
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" Position="Bottom" ToolbarAlign="Right">
                    <Items>
                        <f:Button ID="btnLogin" Text="登入" Type="Submit" ValidateForms="SimpleForm1" ValidateTarget="Top" runat="server" OnClick="btnLogin_Click"/>                        
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>
    </form>
</body>
</html>
