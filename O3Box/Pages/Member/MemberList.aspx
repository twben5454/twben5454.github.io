<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberList.aspx.cs" Inherits="MemberList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>天津车到食有限公司</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Grid ID="Grid1" Title="会员管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="MemberID"  SortField="JoinDate" SortDirection="Desc"  >
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server" >
                    <Items>
                        <f:Button runat="server" ID ="btnAdd" Icon="Add" Text="增加" OnClick="btnAdd_Click" ></f:Button>
                        <f:Textbox runat="server" ID ="txtSearch" Label="模糊查询" EmptyText="请输入编号或名称查询"></f:Textbox>
                        <f:Button ID="btnSelectItem6" Text="查询" runat="server"  OnClick="btnSelectItem6_Click" Icon="Zoom" />
                        <f:Button ID="btnRefresh" Text="重置" runat="server"   Icon="Reload" OnClick="btnRefresh_Click" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="导出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:RowNumberField />
                <f:BoundField Width="100px" DataField="MemberID" DataFormatString="{0} " HeaderText="ID" SortField="MemberID" /> 
                <f:BoundField Width="200px" DataField="MemberName" DataFormatString="{0} " HeaderText="姓名" SortField="MemberName" /> 
                <f:BoundField Width="100px" DataField="JoinDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="加入日期" SortField="JoinDate" /> 
                <f:BoundField Width="100px" DataField="UpMember" DataFormatString="{0:yyyy-MM-dd} " HeaderText="推荐人" SortField="UpMember" /> 
                <f:CheckBoxField Width="100px" RenderAsStaticField="true" DataField="IsHaveCar" HeaderText="有车" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="60px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="删除" Icon="ApplicationDelete" ToolTip="删除"  Width="60px" CommandName="Action2" ConfirmText="确定要删除吗？" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="800px" Height="600px" Title="维护" BodyPadding="5px" EnableIFrame="true" 
            WindowPosition="GoldenSection" EnableMaximize="true">
            <Items>
                
            </Items>
        </f:Window>
    </form>
</body>
</html>
