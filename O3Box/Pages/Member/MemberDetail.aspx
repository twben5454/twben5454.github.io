<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberDetail.aspx.cs" Inherits="Admin_Page_Member_MemberDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>彤鑫管理系統 </title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" Height="800px" ShowBorder="true" TabPosition="Top"  AutoScroll="true"
            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server" >            
            <Toolbars>
                <f:Toolbar runat="server" ID="Toolbar1">
                    <Items>
                        <f:Button runat="server" ID="btnBackup" Text="回上一頁" OnClick="btnBackup_Click" ></f:Button>
                        <f:Label runat="server" ID="lblMemberID" Label="<span style=color:blue;>會員ID</span>" LabelAlign="Right"></f:Label>
                        <f:Label runat="server" ID="lblMemberName" Label="<span style=color:blue;>會員姓名</span>" LabelAlign="Right"></f:Label>
                        <f:Label runat="server" ID="lblMemberClassName" Label="<span style=color:blue;>會員等級</span>" LabelAlign="Right"></f:Label>
                        <f:Label runat="server" ID="lblUpMemberID" Label="<span style=color:blue;>上線ID</span>" LabelAlign="Right"></f:Label>
                        <f:Label runat="server" ID="lblUpMemberName" Label="<span style=color:blue;>上線姓名</span>" LabelAlign="Right"></f:Label>
                        <f:Label runat="server" ID="lblUpMemberClassName" Label="<span style=color:blue;>上線等級</span>" LabelAlign="Right"></f:Label>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Tabs>
                <%--<f:Tab Title="CheckOut" BodyPadding="10px" Layout="Fit" runat="server" ID="Tab1" EnableIFrame ="true" />--%>
                <f:Tab ID="Tab2" EnableIFrame="true" IFrameUrl="MemberDetailA.aspx"  BodyPadding="10px" Title="<span style='color:red;'>[會員基本資料]</span>" runat="server" Height="980px" />
                <f:Tab ID="Tab3" EnableIFrame="true" IFrameUrl="MemberOrder.aspx"  BodyPadding="10px" Title="<span style='color:red;'>[本人訂單記錄]</span>" runat="server" Height="800px" />
                <f:Tab ID="Tab4" EnableIFrame="true" IFrameUrl="MemberBonus.aspx"  BodyPadding="10px" Title="<span style='color:red;'>[本人獎金記錄]</span>" runat="server" Height="800px" />
                <f:Tab ID="Tab5" EnableIFrame="true" IFrameUrl="MemberPromotion.aspx"  BodyPadding="10px" Title="<span style='color:red;'>[本人晉升記錄]</span>" runat="server" Height="800px" />
                <f:Tab ID="Tab7" EnableIFrame="true" IFrameUrl="MemberOrg.aspx"  BodyPadding="10px" Title="<span style='color:red;'>[組織圖]</span>" runat="server" Height="800px" />
                <f:Tab ID="Tab21" EnableIFrame="true" IFrameUrl="GroupOrderList.aspx"  BodyPadding="10px" Title="<span style='color:blue;'>[組織訂單記錄]</span>" runat="server" Height="800px" />
                <f:Tab ID="Tab22" EnableIFrame="true" IFrameUrl="GroupOrder.aspx"  BodyPadding="10px" Title="<span style='color:blue;'>[組織業績記錄]</span>" runat="server" Height="800px" />
                <f:Tab ID="Tab23" EnableIFrame="true" IFrameUrl="GroupPromotion.aspx"  BodyPadding="10px" Title="<span style='color:blue;'>[組織晉升記錄]</span>" runat="server" Height="800px" />
                <f:Tab ID="Tab24" EnableIFrame="true" IFrameUrl="GroupPromotion.aspx"  BodyPadding="10px" Title="<span style='color:blue;'>[組織獎金記錄]</span>" runat="server" Height="800px" />
            </Tabs>
        </f:TabStrip>

    </form>
</body>
</html>
