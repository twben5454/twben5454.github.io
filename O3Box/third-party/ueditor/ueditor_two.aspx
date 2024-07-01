﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ueditor_two.aspx.cs" ValidateRequest="false"
    Inherits="FineUIPro.Examples.aspnet.ueditor_two" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="_form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="Form1" IsFluid="true" CssClass="blockpanel" BodyPadding="10px" EnableCollapse="false"
            Title="添加文章" runat="server">
            <Items>
                <f:TextBox ID="tbxTitle" Label="文章标题" Required="true" runat="server">
                </f:TextBox>
                <f:HtmlEditor runat="server" Label="文章正文" ID="HtmlEditor1"
                    Editor="UEditor" BasePath="~/res/third-party/ueditor/" ToolbarSet="Full" Height="400px">
                </f:HtmlEditor>
                <f:HtmlEditor runat="server" Label="文章摘要" ID="HtmlEditor2"
                    Editor="UEditor" BasePath="~/res/third-party/ueditor/" ToolbarSet="Basic" Height="200px">
                </f:HtmlEditor>
            </Items>
            <Toolbars>
                <f:Toolbar runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="Button1" runat="server" ValidateForms="Form1"
                            Text="获取文章内容" OnClick="Button1_Click">
                        </f:Button>
                        <f:Button ID="Button2" runat="server" Text="更新文章摘要" OnClick="Button2_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:SimpleForm>
        <f:Label runat="server" ID="labResult" EncodeText="false">
        </f:Label>
    </form>
</body>
</html>
