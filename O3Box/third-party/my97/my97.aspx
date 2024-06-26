﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my97.aspx.cs" Inherits="FineUIPro.Examples.aspnet.my97" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="SimpleForm1" IsFluid="true" CssClass="blockpanel" BodyPadding="10px" runat="server" EnableCollapse="false"
            ShowBorder="true" Title="表单" ShowHeader="true">
            <Items>
                <f:DatePicker runat="server" Required="true" Label="日期一" EmptyText="请选择日期一"
                    ID="DatePicker1" ShowRedStar="true">
                </f:DatePicker>
                <f:TriggerBox ID="tbxMyBox" Required="true" ShowRedStar="true" Label="日期和时间" EmptyText="请选择日期和时间" TriggerIcon="Date"
                    runat="server">
                </f:TriggerBox>
                <f:Button ID="btnSubmit" runat="server" ValidateForms="SimpleForm1" Text="提交表单"
                    OnClick="btnSubmit_Click">
                </f:Button>
            </Items>
        </f:SimpleForm>
        <f:Label ID="labResult" ShowLabel="false" EncodeText="false" runat="server">
        </f:Label>
    </form>
    <script src="../../res/third-party/my97/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tbxMyBoxClientID = '<%= tbxMyBox.ClientID %>';

        F.ready(function () {

            var tbxMyBox = F(tbxMyBoxClientID);

            tbxMyBox.onTriggerClick = function () {
                WdatePicker({
                    el: tbxMyBoxClientID + '-inputEl',
                    dateFmt: 'yyyy-MM-dd HH:mm:ss',
                    onpicked: function () {
                        // 确认选择后，执行触发器输入框的客户端验证
                        tbxMyBox.validate();
                    }
                });
            };


        });
    </script>
</body>
</html>
