<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Carsouel.aspx.cs" Inherits="CreatWeb_Home_Carsouel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/animate.css" rel="stylesheet" />
    <link href="../../css/font-awesome.min.css" rel="stylesheet" />
    <script src="../../js/jquery-3.3.1.slim.min.js"></script>
    <script src="../../js/popper.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
   
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AjaxAspnetControls="carouselExampleFade" />
        <div class="ml-3 text-danger">请上传图档 1920 X 800 (考虑使用者资源，最多只能上传四张;上传图档系统会自动缩图处理，请自行保管原始图档)</div>


        <f:Grid ID="Grid1" Title="形象广告管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="false" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" OnRowCommand="Grid1_RowCommand"
            DataKeyNames="WebID,ImageID,ImageUrl,DisplayOrder,IsUse" SortField="DisplayOrder" SortDirection="Asc">
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server">
                    <Items>
                        <f:FileUpload runat="server" ID="filePhoto" ShowRedStar="false" ShowEmptyLabel="true" OnFileSelected="filePhoto_FileSelected"
                            ButtonText="上传图片1920 X 800" ButtonOnly="true" Required="false" ButtonIcon="ImageAdd"
                            AutoPostBack="true" />
                        <f:Button runat="server" ID="Btnreload" Text="更新后按刷新看效果" CssClass ="bg-danger text-white" OnClick="Btnreload_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:ImageField Width="200px" DataImageUrlField="ImageUrl" DataImageUrlFormatString="~/upload/{0}" HeaderText="图档" ImageHeight="80px" ImageWidth="192px"></f:ImageField>
                <f:BoundField Width="100px" DataField="DisplayOrder" DataFormatString="{0} " HeaderText="排序" SortField="DisplayOrder" />
                <f:CheckBoxField Width="80px" RenderAsStaticField="true" DataField="IsUse" HeaderText="状态" />
                <f:LinkButtonField TextAlign="Center" Text="" ColumnID="lbfAction1" HeaderText="上升" Icon="ArrowUp" ToolTip="上升" Width="60px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center" Text="" ColumnID="lbfAction2" HeaderText="下降" Icon="ArrowDown" ToolTip="下降" Width="60px" CommandName="Action2" />
                <f:LinkButtonField TextAlign="Center" Text="" ColumnID="lbfAction3" HeaderText="禁用" Icon="ApplicationDelete" ToolTip="删除" Width="60px" CommandName="Action3" ConfirmText="确定要禁用吗？" />
            </Columns>
        </f:Grid>

        <f:ContentPanel ID="ContentPanel1" IsFluid="true" CssClass="blockpanel" runat="server" BodyPadding="10px" Height="800px" AutoScroll="true"
            ShowBorder="true" ShowHeader="true" Title="网页预览">
            <div id="carouselExampleFade" class="carousel slide carousel-fade" data-ride="carousel" runat="server">
                <%--<ol class="carousel-indicators">
                    <li data-target="#carouselExampleFade" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleFade" data-slide-to="1"></li>
                    <li data-target="#carouselExampleFade" data-slide-to="2"></li>
                </ol>--%>
                <div class="carousel-inner">

                    <%--<div class="carousel-item active">
                        <img class="d-block w-100" src="/upload/ben/636853990036099170_5300811240d99.jpg" alt="First slide">
                    </div>--%>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="carousel-item <%#Eval("Status") %>">
                                <img class="d-block w-100" src="<%# "/upload/" + Eval("ImageUrl") %>" alt="<%#Eval("DisplayOrder") %>">
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleFade" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">上一张</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleFade" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">下一张</span>
                </a>
            </div>

        </f:ContentPanel>
    </form>
</body>
</html>
