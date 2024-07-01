<%@ Page Language="C#" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>购物商城后台</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Grid ID="Grid1" Title="新闻管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="NewsID,NewsTitle,NewsMemo,IsUse"  SortField="NewsID" SortDirection="Desc"  >
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
                <f:BoundField Width="100px" DataField="NewsID" DataFormatString="{0} " HeaderText="新闻ID" SortField="NewsID" /> 
                <f:BoundField Width="200px" DataField="NewsTitle" DataFormatString="{0} " HeaderText="标题" SortField="NewsTitle" /> 
                <f:BoundField Width="200px" DataField="NewsMemo" DataFormatString="{0} " HeaderText="内容" SortField="NewsMemo" /> 
                <f:CheckBoxField Width="80px" RenderAsStaticField="true" DataField="IsUse" HeaderText="是否使用" />
                <f:BoundField Width="200px" DataField="Created" DataFormatString="{0} " HeaderText="建档" SortField="QAAnswer" Hidden="true" /> 
                <f:BoundField Width="200px" DataField="Updated" DataFormatString="{0} " HeaderText="更档" SortField="QAAnswer" Hidden="true" /> 
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="60px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="删除" Icon="ApplicationDelete" ToolTip="删除"  Width="60px" CommandName="Action2" ConfirmText="确定要删除吗？" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="1000px" Height="700px" Title="维护" BodyPadding="5px" EnableIFrame="false"
            WindowPosition="GoldenSection" EnableMaximize="true">
            <Items>
                <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="false" LabelWidth="120px"
                    Title="表单" runat="server">
                    <Rows>
                        <f:FormRow ID="FormRow5">
                            <Items>
                                <f:TextBox ID="NewsID" runat="server" Label="ID" ShowRedStar="true" Required="true" LabelWidth="120px"></f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow6">
                            <Items>
                                <f:TextBox ID="NewsTitle" runat="server" Label="标题" ShowRedStar="true" Required="true" LabelWidth="120px"></f:TextBox>
                            </Items>
                        </f:FormRow>
                         <f:FormRow ID="FormRow7" runat="server">
                    <Items>
                        <f:HtmlEditor runat="server" Label="文本编辑器" ID="NewsMemo" Readonly="false"  ShowRedStar="true"
                            Editor="UMEditor" BasePath="~/res/umeditor/" ToolbarSet="Full" Height="500px">
                        </f:HtmlEditor>
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
