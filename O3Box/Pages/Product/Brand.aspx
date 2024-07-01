<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Brand.aspx.cs" Inherits="Brand" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>购物商城后台</title>
    <style>
        .photo {
            height: 100px;
            line-height: 100px;
            overflow: hidden;
        }

            .photo img {
                height: 100px;
                vertical-align: middle;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Grid ID="Grid1" Title="品牌管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="BrandID,BrandName,BrandImage,IsUse,Memo"  SortField="BrandID" SortDirection="Desc"  >
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
                <f:BoundField Width="100px" DataField="BrandID" DataFormatString="{0} " HeaderText="品牌ID" SortField="BrandID" /> 
                <f:BoundField Width="100px" DataField="BrandName" DataFormatString="{0} " HeaderText="品牌名稱" SortField="BrandName" /> 
                <f:BoundField Width="200px" DataField="BrandImage" DataFormatString="{0} " HeaderText="圖檔" SortField="BrandImage" /> 
                <f:CheckBoxField Width="80px" RenderAsStaticField="true" DataField="IsUse" HeaderText="是否使用" />
                <f:BoundField Width="200px" DataField="Created" DataFormatString="{0} " HeaderText="建档" SortField="QAAnswer" Hidden="true" /> 
                <f:BoundField Width="200px" DataField="Updated" DataFormatString="{0} " HeaderText="更档" SortField="QAAnswer" Hidden="true" /> 
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="60px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="禁用" Icon="ApplicationDelete" ToolTip="禁用"  Width="60px" CommandName="Action2" ConfirmText="确定要禁用吗？" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="400px" Height="600px" Title="维护" BodyPadding="5px" EnableIFrame="false"
            WindowPosition="GoldenSection" EnableMaximize="true">
            <Items>
                <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="false" LabelWidth="120px"
                    Title="表单" runat="server">
                    <Rows>
                        <f:FormRow ID="FormRow5">
                            <Items>
                               <f:TextBox runat="server" ID="BrandID" Label ="品牌ID" Required="true" ShowRedStar="true"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow6">
                            <Items>
                               <f:TextBox runat="server" ID="BrandName" Label ="品牌名稱"  Required="true" ShowRedStar="true"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow7">
                            <Items>
                               <f:TextArea runat="server" ID="Memo" Label ="說明" Required="false"/>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow8">
                            <Items>
                               <f:Image ID="imgPhoto" CssClass="photo" ImageUrl="~/res/images/blank.png" ShowEmptyLabel="true" runat="server" >
                        </f:Image>
                                </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow9">
                            <Items>
                        <f:FileUpload runat="server" ID="filePhoto" ShowRedStar="false" ShowEmptyLabel="true"
                            ButtonText="上传图片" ButtonOnly="true" Required="false" ButtonIcon="ImageAdd"
                            AutoPostBack="true" OnFileSelected="filePhoto_FileSelected">
                        </f:FileUpload>
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
