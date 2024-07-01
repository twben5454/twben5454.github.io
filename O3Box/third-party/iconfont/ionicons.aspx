<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ionicons.aspx.cs" Inherits="FineUIPro.Examples.thirdparty.iconfont.ionicons" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
    <link rel="stylesheet" href="../../res/third-party/ionicons/fonts.css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Button ID="btnIcon1" Text="图标在左侧" IconFontClass="ion ion-md-pricetags" runat="server" CssClass="marginr" />
        <f:Button ID="btnIcon2" Text="图标在右侧" IconAlign="Right" IconFontClass="ion ion-md-star" runat="server" />
        <br />
        <br />
        <f:Button ID="btnIcon3" Text="图标在上面" IconAlign="Top" IconFontClass="ion ion-md-cart" runat="server"
            CssClass="marginr" />
        <f:Button ID="btnIcon4" Text="图标在下面" IconAlign="Bottom" IconFontClass="ion ion-md-cloud" runat="server" />
        <br />
        <br />
        只有图片的按钮：
        <br />
        <br />
        <f:Button ID="Button1" IconFontClass="ion ion-md-share" CssClass="marginr" runat="server" />
        <f:Button ID="Button2" IconFontClass="ion ion-md-key" CssClass="marginr" runat="server" />
        <f:Button ID="Button7" IconFontClass="ion ion-md-lock" CssClass="marginr" runat="server" />
        <f:Button ID="Button8" IconFontClass="ion ion-md-trash" CssClass="marginr" runat="server" />
        <br />
        <br />
        <f:Panel ID="Panel1" Width="500px" runat="server" Title="面板" Height="250px"
            BodyPadding="10px" EnableCollapse="true" IconFontClass="ion ion-md-list">
            <Items>
                <f:Label runat="server" Text="面板内容"></f:Label>
            </Items>
            <Tools>
                <f:Tool runat="server" IconFontClass="ion ion-md-cog" ToolTip="设置" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool runat="server" IconFontClass="ion ion-md-cloud-download" ToolTip="下载" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
            </Tools>
            <Toolbars>
                <f:Toolbar runat="server" Position="Bottom" ToolbarAlign="Right">
                    <Items>
                        <f:Button ID="btnMenu" Text="操作" EnablePostBack="false" IconFontClass="ion ion-md-create" runat="server">
                            <Menu runat="server">
                                <f:MenuButton runat="server" IconFontClass="ion ion-md-trash" EnablePostBack="false" Text="删除选中项">
                                </f:MenuButton>
                                <f:MenuButton runat="server" IconFontClass="ion ion-md-hand" EnablePostBack="false" Text="禁用选中项">
                                </f:MenuButton>
                            </Menu>
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Panel>
        <br />
        <f:Tree ID="Tree1" Width="500px" ShowHeader="true" Title="树控件" EnableCollapse="false"
            runat="server">
            <Nodes>
                <f:TreeNode Text="中国" Expanded="true">
                    <f:TreeNode Text="河南省" Expanded="true">
                        <f:TreeNode Text="驻马店市" Expanded="true" IconFontClass="ion ion-md-flag" NodeID="zhumadian">
                            <f:TreeNode Text="遂平县" IconFontClass="ion ion-md-pricetag" NodeID="suiping">
                            </f:TreeNode>
                            <f:TreeNode Text="西平县" IconFontClass="ion ion-md-book" NodeID="xiping">
                            </f:TreeNode>
                        </f:TreeNode>
                        <f:TreeNode Text="漯河市" NodeID="luohe" IconFontClass="ion ion-md-bookmark" />
                    </f:TreeNode>
                    <f:TreeNode Text="安徽省" NodeID="anhui">
                    </f:TreeNode>
                </f:TreeNode>
            </Nodes>
        </f:Tree>
        <br />
        <br />
        <a href="https://ionicons.com/" target="_blank">https://ionicons.com/</a>
    </form>
    <script>

        function onToolIconClick(event) {
            // 当前点击的图标字体
            var iconFontCls = this.iconFontCls;

            F.notify({
                message: '你点击了标题栏工具图标：' + iconFontCls,
                messageIconFontCls: iconFontCls,
                displayMilliseconds: 300000,
                positionX: 'center',
                positionY: 'center'
            });
        }

    </script>
</body>
</html>
