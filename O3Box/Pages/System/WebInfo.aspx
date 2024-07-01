<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebInfo.aspx.cs" Inherits="Page_System_WebInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Panel runat="server" ID="Panel1" Width="800px" ShowHeader="false">
            <Items>
                <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="true" LabelWidth="120px"
                    Title="网站资讯" runat="server">
                    <Rows>
                        <f:FormRow ID="FormRow5">
                            <Items>
                                <f:TextBox runat="server" ID="WebName" Label="网站名称" Required="true" ShowRedStar="true" />
                                <f:TextBox runat="server" ID="WebUrl" Label="网址" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow62">
                            <Items>
                                <f:TextBox runat="server" ID="WXID" Label="微信APPID" Required="false" />
                                <f:TextBox runat="server" ID="Tel" Label="电话" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow67">
                            <Items>
                                <f:TextBox runat="server" ID="WXName" Label="微信公众号" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow6">
                            <Items>
                                <f:TextBox runat="server" ID="Fax" Label="传真" Required="false" />
                                <f:TextBox runat="server" ID="Email" Label="Email" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow7" runat="server">
                            <Items>
                                <f:TextBox runat="server" ID="Address" Label="地址" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow81" runat="server">
                            <Items>
                                <f:TextArea runat="server" ID="MetaKeyWords" Label="SEO关键字" Required="false" EmptyText="以,符号区格。例:水果,衣服,茶叶" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow71">
                            <Items>
                                <f:DatePicker runat="server" ID="SDate" Label="起" Required="false" Readonly="true" />
                                <f:DatePicker runat="server" ID="EDate" Label="迄" Required="false" Readonly="true" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow72">
                            <Items>
                                <f:TextBox runat="server" ID="Created" Label="建档" Required="false" Readonly="true" />
                                <f:TextBox runat="server" ID="Updated" Label="更档" Required="false" Readonly="true" />
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Button ID="Button5" IconFont="_Save" Text="保存" ValidateForms="SimpleForm1" runat="server" OnClick="Button5_Click" />
            </Items>
        </f:Panel>
    </form>
</body>
</html>
