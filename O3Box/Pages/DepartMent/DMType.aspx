<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DMType.aspx.cs" Inherits="DMType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>市卫生计生随机抽查信息管理系统</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Grid ID="Grid1" Title="单位类型" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="ClassID ,ClassNo ,ClassName,IsUse"  SortField="ClassNo" SortDirection="Asc"  >
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server">
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
                <f:BoundField Width="100px" DataField="ClassNo" DataFormatString="{0} " HeaderText="编号" SortField="ClassNo" /> 
                <f:BoundField Width="200px" DataField="ClassName" DataFormatString="{0} " HeaderText="名称" SortField="ClassName" /> 
                <f:CheckBoxField Width="80px" RenderAsStaticField="true" DataField="IsUse" HeaderText="是否使用" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="50px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="删除" Icon="ApplicationDelete" ToolTip="删除"  Width="50px" CommandName="Action2" ConfirmText="确定要删除吗？" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction3" HeaderText="变更使用" Icon="BookEdit" ToolTip="使用"  Width="50px" CommandName="Action3"  ConfirmText="确定变更状态吗？"/>
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="400px" Height="200px" Title="维护" BodyPadding="5px"
            WindowPosition="Center" EnableMaximize="true">
            <Items>
                <f:SimpleForm runat="server" ID="SimpleForm1" ShowHeader="false" LabelAlign="Right">
                    <Items>
                        <f:HiddenField runat="server" ID="txtID"></f:HiddenField>
                        <f:TextBox runat="server" Label="编号" ID="txtNo" Required="true" />
                        <f:TextBox runat="server" ID="txtName" Label="名称" Required="true" />
                        <f:Button ID="btnSubmit" CssClass="marginr" runat="server" OnClick="btnSubmit_Click" ValidateForms="SimpleForm1" Text="更改"/>
                    </Items>
                </f:SimpleForm>
            </Items>
        </f:Window>
    </form>
</body>
</html>
