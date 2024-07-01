﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form.aspx.cs" Inherits="FineUIPro.Examples.block.form" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
    <style>
        body.f-body {
            overflow-x: hidden;
        }

        .myblockform .f-panel-body .f-field {
            margin: 0;
        }
    </style>
</head>
<body class="f-body-bgcolor">
    <form id="_form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Panel IsFluid="true" runat="server"
            Layout="Block" BlockConfigSpace="20px" ShowBorder="false" ShowHeader="false">
            <Items>
                <f:Panel BlockMD="6" 
                    Layout="Block" BlockConfigSpace="20px"
                    runat="server" ShowBorder="false" ShowHeader="false">
                    <Items>
                        <f:Panel ID="Panel1" CssClass="blockpanel myblockform" BlockMD="12" EnableCollapse="true"
                            Layout="Block" BlockConfigSpace="20px" BodyPadding="10px"
                            runat="server" ShowBorder="true" ShowHeader="true" Title="表单 1">
                            <Items>
                                <f:Label ID="Label1" BlockMD="6" runat="server" Label="标签" Text="标签的值">
                                </f:Label>
                                <f:CheckBox ID="CheckBox1" BlockMD="6" runat="server" Text="复选框" Label="复选框">
                                </f:CheckBox>
                                <f:DropDownList ID="DropDownList1" BlockMD="6" runat="server" Required="true" ShowRedStar="true" AutoSelectFirstItem="false" Label="下拉列表">
                                    <f:ListItem Text="可选项 1" Value="0"></f:ListItem>
                                    <f:ListItem Text="可选项 2" Value="2"></f:ListItem>
                                    <f:ListItem Text="可选项 3" Value="3"></f:ListItem>
                                    <f:ListItem Text="可选项 4" Value="4"></f:ListItem>
                                    <f:ListItem Text="可选项 5" Value="5"></f:ListItem>
                                    <f:ListItem Text="可选项 6" Value="6"></f:ListItem>
                                    <f:ListItem Text="可选项 7" Value="7"></f:ListItem>
                                    <f:ListItem Text="可选项 8" Value="8"></f:ListItem>
                                </f:DropDownList>
                                <f:TextBox ID="TextBox1" BlockMD="6" ShowRedStar="true" runat="server" Label="文本框" Required="true"
                                    Text="">
                                </f:TextBox>
                                <f:Button runat="server" BlockMD="12" Text="验证此表单并提交" ValidateForms="Panel1"
                                    ID="btnSubmitForm1" OnClick="btnSubmitForm1_Click">
                                </f:Button>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel2" CssClass="blockpanel myblockform" BlockMD="12" EnableCollapse="true"
                            Layout="Block" BlockConfigSpace="20px" BodyPadding="10px"
                            runat="server" ShowBorder="true" ShowHeader="true" Title="表单 2">
                            <Items>
                                <f:DatePicker runat="server" BlockMD="6" EnableEdit="false" Required="true" Label="日期" EmptyText="请选择日期"
                                    ID="DatePicker1" SelectedDate="2014-07-10" ShowRedStar="true">
                                </f:DatePicker>
                                <f:TimePicker ID="TimePicker1" BlockMD="6" EnableEdit="false" ShowRedStar="true" Label="时间" Increment="30"
                                    Required="true" Text="08:30" EmptyText="请选择时间" runat="server">
                                </f:TimePicker>
                                <f:CheckBox runat="server" BlockMD="12" ID="cbxAtSchool" Label="是否在读"></f:CheckBox>
                                <f:CheckBoxList ID="CheckBoxList1" BlockMD="12" Label="复选框列表" ColumnNumber="3" runat="server">
                                    <f:CheckItem Text="可选项 1" Value="value1" />
                                    <f:CheckItem Text="可选项 2" Value="value2" Selected="true" />
                                    <f:CheckItem Text="可选项 3" Value="value3" Selected="true" />
                                    <f:CheckItem Text="可选项 4" Value="value4" Selected="true" />
                                    <f:CheckItem Text="可选项 5" Value="value5" Selected="true" />
                                </f:CheckBoxList>
                                <f:RadioButtonList ID="RadioButtonList2" BlockMD="12" Label="单选框列表" Required="true" ColumnNumber="3" runat="server">
                                    <f:RadioItem Text="可选项 1" Value="value1" />
                                    <f:RadioItem Text="可选项 2" Value="value2" />
                                    <f:RadioItem Text="可选项 3" Value="value3" />
                                    <f:RadioItem Text="可选项 4" Value="value4" />
                                    <f:RadioItem Text="可选项 5" Value="value5" />
                                </f:RadioButtonList>
                            </Items>
                            <Toolbars>
                                <f:Toolbar runat="server" Position="Bottom" ToolbarAlign="Center">
                                    <Items>
                                        <f:Button ID="btnSubmitForm2" Text="验证此表单并提交" runat="server" OnClick="btnSubmitForm2_Click"
                                            ValidateForms="Panel2">
                                        </f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                        </f:Panel>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel3" CssClass="blockpanel myblockform" BlockMD="6" EnableCollapse="true"
                    Layout="Block" BlockConfigSpace="20px" BodyPadding="10px"
                    runat="server" ShowBorder="true" ShowHeader="true" Title="表单 3">
                    <Items>
                        <f:Label ID="Label3" BlockMD="6" Label="电话" Text="0551-1234567" runat="server" />
                        <f:Label ID="Label16" BlockMD="6" runat="server" Label="申请人" Text="admin">
                        </f:Label>
                        <f:Label ID="Label4" BlockMD="6" Label="编号" Text="200804170006" runat="server" />
                        <f:TextBox ID="TextBox2" BlockMD="6" Required="true" ShowRedStar="true" Label="电子邮箱" RegexPattern="EMAIL"
                            RegexMessage="请输入有效的邮箱地址" runat="server">
                        </f:TextBox>
                        <f:DropDownList ID="DropDownList3" BlockMD="12" Label="审批人" runat="server" Required="true" ShowRedStar="true"
                            EmptyText="请选择审批人" AutoSelectFirstItem="false">
                            <f:ListItem Text="老大甲" Value="0"></f:ListItem>
                            <f:ListItem Text="老大乙" Value="1"></f:ListItem>
                            <f:ListItem Text="老大丙" Value="2"></f:ListItem>
                            <f:ListItem Text="老大丁" Value="3"></f:ListItem>
                            <f:ListItem Text="老大午" Value="4"></f:ListItem>
                            <f:ListItem Text="老大己" Value="5"></f:ListItem>
                        </f:DropDownList>
                        <f:NumberBox ID="NumberBox1" BlockMD="12" Label="申请数量" NoDecimal="true" NoNegative="true" MaxValue="1000" Required="true" runat="server"
                            ShowRedStar="true" />
                        <f:TextArea ID="TextArea1" BlockMD="12" runat="server" Label="描述" ShowRedStar="true" Required="true">
                        </f:TextArea>
                        <f:Panel BlockMD="12" runat="server" ShowBorder="false" ShowHeader="false">
                            <Items>
                                <f:Button ID="btnSubmitForm3" Text="验证此表单并提交" runat="server" OnClick="btnSubmitForm3_Click"
                                    ValidateForms="Panel3">
                                </f:Button>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
