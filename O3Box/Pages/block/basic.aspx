﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="basic.aspx.cs" Inherits="FineUIPro.Examples.block.basic" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
    <style>
        body.f-body {
            overflow-x: hidden;
        }

        .f-field {
            margin-bottom: 0 !important;
        }
    </style>
</head>
<body class="f-body-bgcolor">
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:ContentPanel ID="Panel8" IsFluid="true" CssClass="blockpanel" runat="server" ShowBorder="true" EnableCollapse="false"
            BodyPadding="10px" ShowHeader="false">
            <h4>响应式布局</h4>
            为了丰富页面显示效果，我们引入了业界流行的响应式布局。和 Bootstrap 的 CSS3 媒体查询实现不同，FineUI 完全通过 JavaScript 来实现响应式布局，不仅可以融入现有的布局系统，而且更加灵活。
            <br />
            我们将容器分成了 12 块（可以自定义），然后定义子项在不同屏幕中的块大小，使其总和等于 12，从而在手机、平板、桌面和大尺寸屏幕中显示不同的布局。
            <br />
            <h4>布局规则</h4>
            <ol>
                <li>父容器定义 Layout=Block 属性。</li>
                <li>子项通过 BlockMD=6 定义块的响应宽度。
                <ul>
                    <li>后缀 MD 代表不同的屏幕尺寸（Block、BlockSM、BlockMD、BlockLG）。
                    </li>
                    <li>属性 6 代表子项占据的宽度（6-12）。</li>
                    <li>多个子项的宽度总和等于 12，则占据一行，多余的子项会另起一行。</li>
                </ul>
                </li>
            </ol>
            <br />
            <h4>响应规则</h4>
            <table class="result" style="width: 100%;">
                <tr>
                    <td></td>
                    <td style="font-weight: normal;">超小屏幕（手机）</td>
                    <td style="font-weight: normal;">小屏幕（平板）</td>
                    <td style="font-weight: normal;">中等屏幕（桌面）</td>
                    <td style="font-weight: normal;">大屏幕（大尺寸显示器）</td>
                </tr>
                <tr>
                    <td>屏幕尺寸</td>
                    <td>&lt; 768px</td>
                    <td>&gt;= 768px</td>
                    <td>&gt;= 992px</td>
                    <td>&gt;= 1200px</td>
                </tr>
                <tr>
                    <td>子项属性</td>
                    <td>Block</td>
                    <td>BlockSM</td>
                    <td>BlockMD</td>
                    <td>BlockLG</td>
                </tr>
                <tr>
                    <td>响应行为</td>
                    <td>始终水平排列</td>
                    <td colspan="3">当前屏幕水平排列，小于临界值层叠排列</td>
                </tr>
            </table>
        </f:ContentPanel>
        <br />
        <br />
        中等屏幕水平排列，小屏幕层叠排列：
        <br />
        <br />
        <f:Panel ID="Panel5" IsFluid="true" CssClass="blockpanel" runat="server" ShowBorder="true" EnableCollapse="false"
            Layout="Block" BodyPadding="10px" ShowHeader="false">
            <Items>
                <f:Panel ID="Panel6" BlockMD="6"
                    runat="server" BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label4" runat="server" EncodeText="false" Text="BlockMD=6">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel7" BlockMD="6"
                    runat="server" BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label5" runat="server" EncodeText="false" Text="BlockMD=6">
                        </f:Label>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>

        <br />
        <br />
        大屏幕水平排列，中等屏幕分两行显示，小屏幕层叠排列：
        <br />
        <br />
        <f:Panel ID="Panel2" IsFluid="true" CssClass="blockpanel" runat="server" ShowBorder="true" EnableCollapse="false"
            Layout="Block" BodyPadding="10px" ShowHeader="false">
            <Items>
                <f:Panel ID="Panel1" BlockMD="6" BlockLG="4"
                    runat="server" BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label1" runat="server" EncodeText="false" Text="BlockMD=6<br/>BlockLG=4">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel3" BlockMD="6" BlockLG="4"
                    runat="server" BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label2" runat="server" EncodeText="false" Text="BlockMD=6<br/>BlockLG=4">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel4" BlockMD="12" BlockLG="4"
                    runat="server" BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label3" runat="server" EncodeText="false" Text="BlockMD=12<br/>BlockLG=4">
                        </f:Label>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <br />
        <br />
        通过 BlockConfigSpace=10 设置子项之间的间距：
        <br />
        <br />
        <f:Panel ID="Panel9" IsFluid="true" CssClass="blockpanel" runat="server" ShowBorder="true" EnableCollapse="false"
            Layout="Block" BlockConfigSpace="10px" BodyPadding="10px" ShowHeader="false">
            <Items>
                <f:Panel ID="Panel10" BlockSM="6" BlockMD="9" BlockLG="4"
                    runat="server" BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label7" runat="server" EncodeText="false" Text="BlockSM=6<br/>BlockMD=9<br/>BlockLG=4">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel11" BlockSM="6" BlockMD="3" BlockLG="4"
                    runat="server" BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label8" runat="server" EncodeText="false" Text="BlockSM=6<br/>BlockMD=3<br/>BlockLG=4">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel12" BlockSM="12" BlockMD="12" BlockLG="4"
                    runat="server" BodyPadding="10px" ShowBorder="true" ShowHeader="false">
                    <Items>
                        <f:Label ID="Label9" runat="server" EncodeText="false" Text="BlockSM=12<br/>BlockMD=12<br/>BlockLG=4">
                        </f:Label>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
