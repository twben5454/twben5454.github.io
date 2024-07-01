<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="Article" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Grid ID="Grid1" Title="文章管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="ArticleID,ArticleClassID,ArticleDate,Author,Title,Memo,IsUse,SDate,EDate"  SortField="ArticleID" SortDirection="Desc"  >
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
                <f:BoundField Width="100px" DataField="ArticleID" DataFormatString="{0} " HeaderText="ID" SortField="ArticleID" /> 
                <f:BoundField Width="100px" DataField="ArticleClassID" DataFormatString="{0} " HeaderText="类别" SortField="ArticleClassID" /> 
                <f:BoundField Width="100px" DataField="ArticleDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="日期" SortField="ArticleDate" /> 
                <f:BoundField Width="100px" DataField="Author" DataFormatString="{0} " HeaderText="作者" SortField="Author" /> 
                <f:BoundField Width="100px" DataField="Title" DataFormatString="{0} " HeaderText="标题" SortField="Title" /> 
                <f:BoundField Width="100px" DataField="SDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="起" SortField="SDate" /> 
                <f:BoundField Width="100px" DataField="EDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="迄" SortField="EDate" /> 
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
                                <f:TextBox ID="ArticleID" runat="server" Label="ID" ShowRedStar="true" Required="true" LabelWidth="120px"></f:TextBox>
                                <f:DropDownList runat="server" ID="ArticleClassID" Label ="类别" Required="true" ShowRedStar="true"/>
                            </Items>
                        </f:FormRow>
                         <f:FormRow ID="FormRow62">
                            <Items>
                                <f:DatePicker runat="server" ID="ArticleDate" Label ="发布日期" Required="true" ShowRedStar="true"/>
                                <f:TextBox runat="server" ID="Author" Label ="作者" Required="false"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow6">
                            <Items>
                                <f:TextBox ID="Title" runat="server" Label="标题" ShowRedStar="true" Required="true" LabelWidth="120px"></f:TextBox>
                            </Items>
                        </f:FormRow>
                         <f:FormRow ID="FormRow7" runat="server">
                    <Items>
                        <f:HtmlEditor runat="server" Label="文本编辑器" ID="Memo" Readonly="false"  ShowRedStar="true"
                            Editor="UMEditor" BasePath="~/res/umeditor/" ToolbarSet="Full" Height="450px">
                        </f:HtmlEditor>
                    </Items>
                </f:FormRow>
                        
                        <f:FormRow ID="FormRow71">
                            <Items>
                                <f:DatePicker runat="server" ID="SDate" Label ="起" Required="false"/> 
                                <f:DatePicker runat="server" ID="EDate" Label ="迄" Required="false"/> 
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
