<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inline.aspx.cs" Inherits="FineUIPro.Examples.autocomplete.inline" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
    <link rel="stylesheet" href="../../res/third-party/jqueryuiautocomplete/jquery-ui.css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="SimpleForm1" IsFluid="true" CssClass="blockpanel" runat="server" BodyPadding="10px" EnableCollapse="false"
            Title="简单表单">
            <Items>
                <f:TextBox ID="TextBox1" runat="server" ShowLabel="false" EmptyText="输入字母 a 试试">
                </f:TextBox>
            </Items>
        </f:SimpleForm>
    </form>

    <script src="../../res/third-party/jqueryuiautocomplete/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        var textbox1ID = '<%= TextBox1.ClientID %>';

        F.ready(function () {

            var availableTags = [
                "ActionScript",
                "AppleScript",
                "Asp",
                "BASIC",
                "C",
                "C++",
                "Clojure",
                "COBOL",
                "ColdFusion",
                "Erlang",
                "Fortran",
                "Groovy",
                "Haskell",
                "Java",
                "JavaScript",
                "Lisp",
                "Perl",
                "PHP",
                "Python",
                "Ruby",
                "Scala",
                "Scheme"];

            $('#' + textbox1ID + ' input').autocomplete({
                source: availableTags
            });

        });

    </script>
</body>
</html>
