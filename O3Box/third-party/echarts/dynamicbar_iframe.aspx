<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dynamicbar_iframe.aspx.cs" Inherits="FineUIPro.Examples.third_party.echarts.dynamicbar_iframe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%">
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body style="height: 100%; margin: 0">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfBarOptions" runat="server" />
    </form>

    <div id="container" style="height: 100%"></div>

    <script src="../../res/third-party/echarts/echarts.min.js"></script>
    <script>
        var dom = document.getElementById("container");
        var myChart = echarts.init(dom);
        var barOptions = document.getElementById("hfBarOptions").value;
        myChart.setOption(JSON.parse(barOptions));
    </script>
</body>
</html>
