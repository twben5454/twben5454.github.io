<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="remote_with_cache.aspx.cs"
    Inherits="FineUIPro.Examples.autocomplete.remote_with_cache" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
    <meta name="sourcefiles" content="~/third-party/autocomplete/search.ashx" />
    <link rel="stylesheet" href="../../res/third-party/jqueryuiautocomplete/jquery-ui.css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="SimpleForm1" IsFluid="true" CssClass="blockpanel" runat="server" LabelWidth="60px" BodyPadding="10px" EnableCollapse="false"
            Title="简单表单">
            <Items>
                <f:TextBox ID="TextBox1" runat="server" Label="标题" EmptyText="输入字母 ja 或者 sc 试试，必须输入两个字符后才有自动提示">
                </f:TextBox>
            </Items>
        </f:SimpleForm>
        <br />
        参考：http://jqueryui.com/autocomplete/#remote-with-cache
    </form>

    <script src="../../res/third-party/jqueryuiautocomplete/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        var textbox1ID = '<%= TextBox1.ClientID %>';

        F.ready(function () {

            var cache = {};

            $('#' + textbox1ID + ' input').autocomplete({
                minLength: 2,
                source: function (request, response) {
                    var term = request.term;
                    if (term in cache) {
                        response(cache[term]);
                        return;
                    }

                    $.getJSON("search.ashx", request, function (data, status, xhr) {
                        cache[term] = data;
                        response(data);
                    });
                }
            });

        });

    </script>
</body>
</html>
