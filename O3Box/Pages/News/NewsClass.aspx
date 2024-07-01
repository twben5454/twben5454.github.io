<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsClass.aspx.cs" Inherits="NewsClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>购物商城后台</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Grid ID="Grid1" Title="新闻分类管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="NewsClassID,NewsClassName,IsUse"  SortField="NewsClassID" SortDirection="Desc"  >
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
               <f:BoundField Width="100px" DataField="NewsClassID" DataFormatString="{0} " HeaderText="ID" SortField="NewsClassID" /> 
             <f:BoundField Width="200px" DataField="NewsClassName" DataFormatString="{0} " HeaderText="名称" SortField="NewsClassName" />
                <f:CheckBoxField Width="80px" RenderAsStaticField="true" DataField="IsUse" HeaderText="是否使用" />
                <f:BoundField Width="200px" DataField="Created" DataFormatString="{0} " HeaderText="建档" SortField="Created" Hidden="true" /> 
                <f:BoundField Width="200px" DataField="Updated" DataFormatString="{0} " HeaderText="更档" SortField="Updated" Hidden="true" /> 
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="60px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="禁用" Icon="ApplicationDelete" ToolTip="禁用"  Width="60px" CommandName="Action2" ConfirmText="确定要禁用吗？" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="400px" Height="200px" Title="维护" BodyPadding="5px" EnableIFrame="false"
            WindowPosition="GoldenSection" EnableMaximize="true">
            <Items>
                <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="false" LabelWidth="120px"
                    Title="表单" runat="server">
                    <Rows>
                        <f:FormRow ID="FormRow5">
                            <Items>
                               <f:TextBox runat="server" ID="NewsClassID" Label ="ID" Required="true"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow6">
                            <Items>
                               <f:TextBox runat="server" ID="NewsClassName" Label ="分类名称" Required="true"/>
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
