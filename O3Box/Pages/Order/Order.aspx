<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CatchaFace</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Grid ID="Grid1" Title="订单管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="OrderID，OrderDate,Amount,PayType,MemberID,RestaurantID,DinnerDate,DinnerTime"  SortField="OrderID" SortDirection="Desc"  >
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
                <f:BoundField Width="100px" DataField="OrderID" DataFormatString="{0} " HeaderText="ID" SortField="OrderID" /> 
                <f:BoundField Width="100px" DataField="OrderDate" DataFormatString="{0} " HeaderText="日期" SortField="OrderDate" /> 
                <f:BoundField Width="100px" DataField="Amount" DataFormatString="{0} " HeaderText="金额" SortField="Amount" /> 
                <f:BoundField Width="100px" DataField="PayType" DataFormatString="{0} " HeaderText="付款方式" SortField="PayType" /> 
                <f:BoundField Width="100px" DataField="MemberName" DataFormatString="{0} " HeaderText="会员" SortField="MemberName" /> 
                <f:BoundField Width="100px" DataField="RestaurantName" DataFormatString="{0} " HeaderText="餐厅" SortField="RestaurantName" /> 
                <f:BoundField Width="100px" DataField="Status" DataFormatString="{0} " HeaderText="状态" SortField="Status" /> 
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="60px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="删除" Icon="ApplicationDelete" ToolTip="删除"  Width="60px" CommandName="Action2" ConfirmText="确定要删除吗？" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="600px" Height="400px" Title="维护" BodyPadding="5px" EnableIFrame="false"
            WindowPosition="GoldenSection" EnableMaximize="true">
            <Items>
                <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="false" LabelWidth="120px"
                    Title="表单" runat="server">
                    <Rows>
                        <f:FormRow ID="FormRow5">
                            <Items>
                               <f:TextBox runat="server" ID="OrderID" Label ="订单ID" Required="true"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow6">
                            <Items>
                                <f:DatePicker runat="server" ID="OrderDate" Label ="订单日期" Required="false"/>
                            </Items>
                        </f:FormRow>
                         <f:FormRow ID="FormRow45">
                            <Items>
                               <f:TextBox runat="server" ID="PayType" Label ="付款方式" Required="false"/> 
                            </Items>
                        </f:FormRow>
                         <f:FormRow ID="FormRow76">
                            <Items>
                                <f:NumberBox runat="server" ID="Amount" Label ="订单总计" Required="false"/> 
                            </Items>
                        </f:FormRow>
                         <f:FormRow ID="FormRow16">
                            <Items>
                               <f:DropDownList runat="server" ID="MemberID" Label ="会员" Required="false"/>
                            </Items>
                        </f:FormRow>
                         <f:FormRow ID="FormRow06">
                            <Items>
                               <f:DropDownList runat="server" ID="RestaurantID" Label ="餐厅" Required="false"/>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Button ID="Button5" IconFont="_Save" Text="保存" ValidateForms="SimpleForm1" runat="server" OnClick="btnSubmit_Click" />
            </Items>
        </f:Window>
    </form>
</body>
</html>
