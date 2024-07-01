<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartMent.aspx.cs" Inherits="DepartMent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>市卫生计生随机抽查信息管理系统</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Grid ID="Grid1" Title="组织单位管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="DepartID ,DepartName ,LinkDepartID,DMLevel,DMLocation,DMType"  SortField="DepartID" SortDirection="Asc"  >
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server" >
                    <Items>
                        <f:Button runat="server" ID ="btnAdd" Icon="Add" Text="增加" OnClick="btnAdd_Click" ></f:Button>
                        <f:Textbox runat="server" ID ="txtSearch" Label="模糊查询" EmptyText="请输入编号或名称查询"></f:Textbox>
                        <f:DropDownList runat="server" ID="DropDownList1" Label="级别" Width="200px" LabelWidth="50px" />
                        <f:DropDownList runat="server" ID="DropDownList2" Label="座落位置"  Width="200px" LabelWidth="80px" />
                        <f:DropDownList runat="server" ID="DropDownList3" Label="类型"  Width="200px" LabelWidth="50px" />
                        <f:Button ID="btnSelectItem6" Text="查询" runat="server"  OnClick="btnSelectItem6_Click" Icon="Zoom" />
                        <f:Button ID="btnRefresh" Text="重置" runat="server"   Icon="Reload" OnClick="btnRefresh_Click" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="导出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:RowNumberField />
                <f:BoundField Width="100px" DataField="DepartID" DataFormatString="{0} " HeaderText="编号" SortField="ClassNo" /> 
                <f:BoundField Width="200px" DataField="DepartName" DataFormatString="{0} " HeaderText="名称" SortField="ClassName" /> 
                <f:BoundField Width="100px" DataField="DMLevelName" DataFormatString="{0} " HeaderText="级别" SortField="ClassNo" /> 
                <f:BoundField Width="100px" DataField="DMLocationName" DataFormatString="{0} " HeaderText="座落位置" SortField="ClassNo" /> 
                <f:BoundField Width="200px" DataField="DMTypeName" DataFormatString="{0} " HeaderText="类型" SortField="ClassNo" /> 
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="50px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="删除" Icon="ApplicationDelete" ToolTip="删除"  Width="50px" CommandName="Action2" ConfirmText="确定要删除吗？" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="400px" Height="300px" Title="维护" BodyPadding="5px"
            WindowPosition="Center" EnableMaximize="true">
            <Items>
                <f:SimpleForm runat="server" ID="SimpleForm1" ShowHeader="false" LabelAlign="Right">
                    <Items>
                        <f:TextBox runat="server" Label="编号" ID="txtID" Required="true" />
                        <f:TextBox runat="server" ID="txtName" Label="名称" Required="true" />
                        <f:DropDownList runat="server" ID="dpDMLevel" Label="级别" Required="true" />
                        <f:DropDownList runat="server" ID="dpDMLocation" Label="座落位置" Required="true" />
                        <f:DropDownList runat="server" ID="dpDMType" Label="类型" Required="true" />
                        <f:Button ID="btnSubmit" CssClass="marginr" runat="server" OnClick="btnSubmit_Click" ValidateForms="SimpleForm1" Text="更改"/>
                    </Items>
                </f:SimpleForm>
            </Items>
        </f:Window>
    </form>
</body>
</html>
