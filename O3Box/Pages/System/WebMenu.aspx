<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebMenu.aspx.cs" Inherits="WebMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title runat="server" id="WebTitle"/>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Panel ID="RegionPanel1" CssClass="blockpanel" Layout="Region" Height="450px" ShowHeader="true" Title="后台功能管理"
            ShowBorder="true" runat="server">
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server">
                    <Items>
                        <f:Button runat="server" ID="btnAdd" Icon="Add" Text="新增功能" OnClick="btnAdd_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Tree ID="Tree1" RegionSplit="false" RegionPosition="Left" Width="200px" CssClass="lefttree" OnNodeCommand="Tree1_NodeCommand"
                    ShowHeader="false" ShowBorder="true" runat="server" EnableSingleClickExpand="false">
                </f:Tree>
                <f:Panel ID="Panel1" ShowHeader="false" EnableIFrame="false" ShowBorder="false"
                    RegionPosition="Center" runat="server">
                    <Items>
                        <f:Form ID="Form2" LabelAlign="Top" BodyPadding="10px" ShowBorder="true" ShowHeader="true" runat="server" Width="600px" Title="新增">
                            <Items>
                                <f:HiddenField runat="server" ID="txtID"></f:HiddenField>
                                <f:DropDownList runat="server" ID="LinkID" Label="上层选单"/>
                                <f:TextBox ID="WebMenuName" Required="true" ShowRedStar="true" Label="名称" runat="server"/>
                                <f:TextBox ID="Url"  Label="链结" runat="server"/>
                                <f:Button runat="server" ID="btnSubmit" Icon="Disk"  Text="新增确认" OnClick="btnSubmit_Click"></f:Button>
                                <f:Button runat="server" ID="btnDel" Icon="ApplicationDelete"  Text="删除" Hidden="true" OnClick="btnDel_Click" ConfirmText="确定要删除吗？"></f:Button>
                            </Items>
                        </f:Form>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
