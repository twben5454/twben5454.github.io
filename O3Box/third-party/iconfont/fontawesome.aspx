<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fontawesome.aspx.cs" Inherits="FineUIPro.Examples.thirdparty.iconfont.fontawesome" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Button ID="btnIcon1" Text="图标在左侧" IconFont="Tags" runat="server" CssClass="marginr" />
        <f:Button ID="btnIcon2" Text="图标在右侧" IconAlign="Right" IconFont="Star" runat="server" />
        <br />
        <br />
        <f:Button ID="btnIcon3" Text="图标在上面" IconAlign="Top" IconFont="ShoppingCart" runat="server"
            CssClass="marginr" />
        <f:Button ID="btnIcon4" Text="图标在下面" IconAlign="Bottom" IconFont="Cloud" runat="server" />
        <br />
        <br />
        只有图片的按钮：
        <br />
        <br />
        <f:Button ID="Button1" IconFont="Share" CssClass="marginr" runat="server" />
        <f:Button ID="Button2" IconFont="Key" CssClass="marginr" runat="server" />
        <f:Button ID="Button7" IconFont="Lock" CssClass="marginr" runat="server" />
        <f:Button ID="Button8" IconFont="Trash" CssClass="marginr" runat="server" />
        <br />
        <br />
        <f:Panel ID="Panel1" Width="500px" runat="server" Title="面板" Height="250px"
            BodyPadding="10px" EnableCollapse="true" IconFont="List">
            <Items>
                <f:Label runat="server" Text="面板内容"></f:Label>
            </Items>
            <Tools>
                <f:Tool runat="server" IconFont="Cog" ToolTip="设置" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
                <f:Tool runat="server" IconFont="CloudDownload" ToolTip="下载" EnablePostBack="false">
                    <Listeners>
                        <f:Listener Event="click" Handler="onToolIconClick" />
                    </Listeners>
                </f:Tool>
            </Tools>
            <Toolbars>
                <f:Toolbar runat="server" Position="Bottom" ToolbarAlign="Right">
                    <Items>
                        <f:Button ID="btnMenu" Text="操作" EnablePostBack="false" IconFont="Pencil" runat="server">
                            <Menu runat="server">
                                <f:MenuButton runat="server" IconFont="Trash" EnablePostBack="false" Text="删除选中项">
                                </f:MenuButton>
                                <f:MenuButton runat="server" IconFont="Ban" EnablePostBack="false" Text="禁用选中项">
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
                        <f:TreeNode Text="驻马店市" Expanded="true" IconFont="Flag" NodeID="zhumadian">
                            <f:TreeNode Text="遂平县" IconFont="Tag" NodeID="suiping">
                            </f:TreeNode>
                            <f:TreeNode Text="西平县" IconFont="Book" NodeID="xiping">
                            </f:TreeNode>
                        </f:TreeNode>
                        <f:TreeNode Text="漯河市" NodeID="luohe" IconFont="Bookmark" />
                    </f:TreeNode>
                    <f:TreeNode Text="安徽省" NodeID="anhui">
                    </f:TreeNode>
                </f:TreeNode>
            </Nodes>
        </f:Tree>
        <br />
        <br />
        <a href="https://fontawesome.com/" target="_blank">https://fontawesome.com/</a>
    </form>
    <script>

        function onToolIconClick(event) {
            // 当前点击的图标字体
            var iconFont = this.iconFont;

            F.notify({
                message: '你点击了标题栏工具图标：' + iconFont,
                messageIconFont: iconFont,
                displayMilliseconds: 300000,
                positionX: 'center',
                positionY: 'center'
            });
        }

    </script>
</body>
</html>
