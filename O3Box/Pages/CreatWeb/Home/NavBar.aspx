<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NavBar.aspx.cs" Inherits="CreatWeb_Home_NavBar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/animate.css" rel="stylesheet" />
    <link href="../../css/font-awesome.min.css" rel="stylesheet" />
    <script src="../../js/jquery-3.3.1.slim.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AjaxAspnetControls="NarBar" />
        <div class="ml-3">请选择样式</div>
        <div class="ml-5">
        <f:Button runat="server" ID="btnprimary" Text="" CssClass="bg-primary text-white" OnClick="btnprimary_Click" Width="50"></f:Button>
        <f:Button runat="server" ID="btnsecondary" Text="" CssClass="bg-secondary text-white" OnClick="btnsecondary_Click" Width="50"></f:Button>
        <f:Button runat="server" ID="btnsuccess" Text="" CssClass="bg-success text-white" OnClick="btnsuccess_Click" Width="50"></f:Button>
        <f:Button runat="server" ID="btninfo" Text="" CssClass="bg-info text-white" OnClick="btninfo_Click" Width="50"></f:Button>
        <f:Button runat="server" ID="btnwarning" Text="" CssClass="bg-warning text-white" OnClick="btnwarning_Click" Width="50"></f:Button>
        <f:Button runat="server" ID="btndanger" Text="" CssClass="bg-danger text-white" OnClick="btndanger_Click" Width="50"></f:Button>
        <f:Button runat="server" ID="btnlight" Text="" CssClass="bg-light text-dark" OnClick="btnlight_Click" Width="50"></f:Button>
        <f:Button runat="server" ID="btndark" Text="" CssClass="bg-dark text-white" OnClick="btndark_Click" Width="50"></f:Button>

        </div>

        <f:ContentPanel ID="ContentPanel1" IsFluid="true" CssClass="blockpanel" runat="server" BodyPadding="10px" Height ="400px"
            ShowBorder="true" ShowHeader="true" Title="网页预览">

            <section id="Header" class="container " style="margin-top: 50px;">
                <nav class="navbar navbar-expand-lg navbar-dark  bg-dark" runat="server" id="NarBar">
                    <a class="navbar-brand" href="#">Logo</a>
                    <button
                        class="navbar-toggler"
                        type="button"
                        data-toggle="collapse"
                        data-target="#navbarSupportedContent"
                        aria-controls="navbarSupportedContent"
                        aria-expanded="false"
                        aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav ml-auto">
                            <li class="nav-item active">
                                <a class="nav-link" href="#">首页 <span class="sr-only">(current)</span></a>
                            </li>
                            <li class="nav-item"><a class="nav-link" href="#">关于我们</a></li>
                            <li class="nav-item dropdown">
                                <a
                                    class="nav-link dropdown-toggle"
                                    href="#"
                                    id="navbarDropdown"
                                    role="button"
                                    data-toggle="dropdown"
                                    aria-haspopup="true"
                                    aria-expanded="false">产品介绍
                                </a>
                                <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                                    <a class="dropdown-item" href="#">产品分类一</a>
                                    <a class="dropdown-item" href="#">产品分类二</a>
                                    <%--<div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="#">Something else here</a>--%>
                                </div>
                            </li>
                            <li class="nav-item"><a class="nav-link" href="#">连络我们</a></li>
                        </ul>
                    </div>
                </nav>
            </section>
        </f:ContentPanel>
    </form>
</body>
</html>
