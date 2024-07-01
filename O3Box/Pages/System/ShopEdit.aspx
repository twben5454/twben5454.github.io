<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopEdit.aspx.cs" Inherits="ShopEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="robots" content="nofollow" />
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Window ID="Window1" runat="server" Title="平台客户编辑－" IsModal="false" EnableClose="false" EnableResize="true"
            Width="650px" BodyPadding="10px" AutoScroll="true">
            <Items>
                <f:Form ID="Form2" LabelAlign="Right" MessageTarget="Qtip"
                    ShowBorder="false" ShowHeader="false" runat="server">
                    <Items>
                        <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="公司信息" runat="server">
                            <Items>
                                <f:Panel ID="Panel2" Layout="HBox" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TextBox runat="server" ID="ShopID" Label ="平台客户ID" CssClass="marginr"  BoxFlex="2" Required="false"/> 
                                        <f:TextBox runat="server" ID="ShopName" Label ="平台客户名称" CssClass="marginr"  BoxFlex="2" Required="false"/> 
                                    </Items>
                                </f:Panel>
                                <f:Panel ID="Panel1" Layout="HBox" BoxConfigAlign="Stretch" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TextBox runat="server" ID="Boss" Label ="负责人"  BoxFlex="2" Required="false"/> 
                                        <f:TextBox runat="server" ID="Tel" Label ="电话"  BoxFlex="2" Required="false"/> 
                                    </Items>
                                </f:Panel>
                                <f:Panel ID="Panel11" Layout="HBox" BoxConfigAlign="Stretch" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TextBox ID="BusinessLicenceNo" ShowLabel="true" CssClass="marginr"  Label="营业执照号码"  BoxFlex="2" runat="server">
                                        </f:TextBox>
                                    </Items>
                                </f:Panel>
                                <f:Panel ID="Panel5" Layout="HBox" BoxConfigAlign="Stretch" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TextBox ID="Address" ShowLabel="true" CssClass="marginr"  Label="地址"  BoxFlex="2" runat="server">
                                        </f:TextBox>
                                    </Items>
                                </f:Panel>
                            </Items>
                        </f:GroupPanel>
                        <f:GroupPanel ID="GroupPanel2" Layout="Anchor" Title="域名信息" runat="server">
                            <Items>
                                <f:Panel ID="Panel4" Layout="HBox" BoxConfigAlign="Stretch" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TextBox ID="DomainName" ShowLabel="true" CssClass="marginr"  Label="域名"  BoxFlex="2" runat="server">
                                        </f:TextBox>
                                    </Items>
                                </f:Panel>
                                 <f:Panel ID="Panel7" Layout="HBox" BoxConfigAlign="Stretch" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:DatePicker ID="DomainNameSDate" ShowLabel="true" CssClass="marginr"  Label="起"  BoxFlex="2" runat="server">
                                        </f:DatePicker>
                                        <f:DatePicker ID="DomainNameEDate" ShowLabel="true" CssClass="marginr"  Label="迄"  BoxFlex="2" runat="server">
                                        </f:DatePicker>
                                    </Items>
                                </f:Panel>
                            </Items>
                        </f:GroupPanel>
                        <f:GroupPanel ID="GroupPanel3" Layout="Anchor" Title="微信公众号" runat="server">
                            <Items>
                                <f:Panel ID="Panel3" Layout="HBox" BoxConfigAlign="Stretch" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TextBox ID="WeiXin" ShowLabel="true" CssClass="marginr"  Label="公众号"  BoxFlex="2" runat="server">
                                        </f:TextBox>
                                    </Items>
                                </f:Panel>
                                 <f:Panel ID="Panel8" Layout="HBox" BoxConfigAlign="Stretch" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:DatePicker ID="WeiXinSDate" ShowLabel="true" CssClass="marginr"  Label="起"  BoxFlex="2" runat="server">
                                        </f:DatePicker>
                                        <f:DatePicker ID="WeiXinEDate" ShowLabel="true" CssClass="marginr"  Label="迄"  BoxFlex="2" runat="server">
                                        </f:DatePicker>
                                    </Items>
                                </f:Panel>
                            </Items>
                        </f:GroupPanel>
                        <f:GroupPanel ID="GroupPanel5" Layout="Anchor" Title="微信小程序" runat="server">
                            <Items>
                                <f:Panel ID="Panel9" Layout="HBox" BoxConfigAlign="Stretch" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TextBox ID="WeiXinP" ShowLabel="true" CssClass="marginr"  Label="小程序"  BoxFlex="2" runat="server">
                                        </f:TextBox>
                                    </Items>
                                </f:Panel>
                                 <f:Panel ID="Panel10" Layout="HBox" BoxConfigAlign="Stretch" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:DatePicker ID="WeiXinPSDate" ShowLabel="true" CssClass="marginr"  Label="起"  BoxFlex="2" runat="server">
                                        </f:DatePicker>
                                        <f:DatePicker ID="WeiXinPEDate" ShowLabel="true" CssClass="marginr"  Label="迄"  BoxFlex="2" runat="server">
                                        </f:DatePicker>
                                    </Items>
                                </f:Panel>
                            </Items>
                        </f:GroupPanel>
                        <f:GroupPanel ID="GroupPanel4" Layout="Anchor" Title="备注" runat="server">
                            <Items>
                                <f:TextArea runat="server" ID ="Memo" Label="备注"></f:TextArea>
                            </Items>
                        </f:GroupPanel>
                    </Items>
                </f:Form>
            </Items>
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="Button1" IconFont="_Save" Text="提交" ValidateForms="Form2"   runat="server" OnClick="Button1_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>
    </form>
</body>
</html>
