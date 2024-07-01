﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ueditor_config.aspx.cs" ValidateRequest="false"
    Inherits="FineUIPro.Examples.aspnet.ueditor_config" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="SimpleForm1" IsFluid="true" CssClass="blockpanel" BodyPadding="10px" runat="server" LabelAlign="Top" EnableCollapse="false"
            Title="表单">
            <Items>
                <f:HtmlEditor runat="server" Label="文本编辑器" ID="HtmlEditor1" 
                    Editor="UEditor" BasePath="~/res/third-party/ueditor/" ToolbarSet="Full" Height="350px">
                    <Options>
                        <f:OptionItem Key="lang" Value="en" />
                        <f:OptionItem Key="toolbars" 
                            Value="[['bold', 'italic', 'underline', 'strikethrough', '|', 'insertorderedlist', 'insertunorderedlist', '|', 'justifyleft', 'justifycenter', 'justifyright', '|', 'link', 'unlink', '|', 'source']]"
                            PersistOriginal="true" />
                    </Options>
                </f:HtmlEditor>
            </Items>
        </f:SimpleForm>
        <br />
        <f:Button ID="Button2" runat="server" CssClass="marginr" Text="设置编辑器的值" OnClick="Button2_Click">
        </f:Button>
        <f:Button ID="Button1" runat="server" Text="获取编辑器的值" OnClick="Button1_Click">
        </f:Button>
        <br />
        <br />
        注：本示例通过 Options 属性设置 UEditor 的语言（英文）和工具栏（自定义）。参考文档：http://fex.baidu.com/ueditor/#start-config
    </form>
</body>
</html>
