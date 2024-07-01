<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Shop.aspx.cs" Inherits="Shop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>麥德泰-建站平台</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Grid ID="Grid1" Title="平台客户管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="ShopID"  SortField="EmployeeID" SortDirection="Asc"  >
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server" >
                    <Items>
                        <f:Button runat="server" ID ="btnAdd" Icon="Add" Text="增加" OnClick="btnAdd_Click" ></f:Button>
                        <f:Textbox runat="server" ID ="txtSearch" Label="模糊查询" EmptyText="请输入关键字查询"></f:Textbox>
                        <f:Button ID="btnSelectItem6" Text="查询" runat="server"  OnClick="btnSelectItem6_Click" Icon="Zoom" />
                        <f:Button ID="btnRefresh" Text="重置" runat="server"   Icon="Reload" OnClick="btnRefresh_Click" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="导出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField Width="100px" DataField="ShopID" DataFormatString="{0} " HeaderText="编号" SortField="ShopID" /> 
                <f:BoundField Width="100px" DataField="ShopName" DataFormatString="{0} " HeaderText="名称" SortField="ShopName" /> 
                <f:BoundField Width="100px" DataField="VID" DataFormatString="{0} " HeaderText="执照号码" SortField="VID" /> 
                <f:BoundField Width="100px" DataField="JoinDate" DataFormatString="{0:d} " HeaderText="加入日期" SortField="JoinDate" /> 
                <f:BoundField Width="100px" DataField="LimitDate" DataFormatString="{0:d} " HeaderText="到期日期" SortField="LimitDate" /> 
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="50px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="删除" Icon="ApplicationDelete" ToolTip="删除"  Width="50px" CommandName="Action2" ConfirmText="确定要删除吗？" />
                <f:LinkButtonField TextAlign="Center" ColumnID="lbfAction4" Width="60px" CommandName="Action4" Text="事项" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="400px" Height="350px" Title="维护" BodyPadding="5px"
            WindowPosition="Center" EnableMaximize="true">
            <Items>
                <f:SimpleForm runat="server" ID="SimpleForm1" ShowHeader="false" LabelAlign="Right">
                    <Items>
                        <f:TextBox runat="server" Label="编号" ID="txtID" Required="true" />
                        <f:TextBox runat="server" ID="txtEmployeeName" Label ="姓名" Required="true"/> 
                         <f:DropDownList runat="server" ID="txtEmployeeType" Label ="人员类型" Required="false"/> 
                        <f:TextBox runat="server" ID="txtIDNo" Label ="身份证字号" Required="false"/> 
                        <f:TextBox runat="server" ID="txtEnforceNo" Label ="执法证号" Required="false"/> 
                        <f:TextBox runat="server" ID="txtCellPhone" Label ="联系电话" Required="false"/> 
                        <f:DropDownList runat="server" ID="txtDepartMentID" Label ="单位" Required="false" AutoPostBack="true" OnSelectedIndexChanged="txtDepartMentID_SelectedIndexChanged"/> 
                        <f:DropDownList runat="server" ID="txtDepartMentID2" Label ="部门" Required="false"/> 
                        <f:Button ID="btnSubmit" CssClass="marginr" runat="server" OnClick="btnSubmit_Click" ValidateForms="SimpleForm1" Text="更改"/>
                    </Items>
                </f:SimpleForm>
            </Items>
        </f:Window>
        <f:Window ID="Window2" runat="server" Hidden="true" Width="800px" Height="400px" Title="检查项目维护" BodyPadding="5px" EnableIFrame="true"
            WindowPosition="Center" EnableMaximize="true"/>
    </form>
</body>
</html>
