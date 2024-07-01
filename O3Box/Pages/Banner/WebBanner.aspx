<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebBanner.aspx.cs" Inherits="WebBanner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
    <style>
        .photo {
            height: 150px;
            line-height: 150px;
            overflow: hidden;
        }

            .photo img {
                height: 150px;
                vertical-align: middle;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Grid ID="Grid1" Title="Web Banner管理" EnableFrame="true" EnableCollapse="false" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="BannerID,BannerType,BannerText,BannerUrl,BannerImage,IsUse,Created,Updated"  SortField="BannerID" SortDirection="Asc"   >
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
                <f:BoundField Width="100px" DataField="BannerID" DataFormatString="{0} " HeaderText="BannerID" SortField="BannerID" /> 
                <f:ImageField Width="200px"   DataImageUrlField="BannerImage" DataImageUrlFormatString="~/upload/{0}"  HeaderText="图档" ImageHeight="25px" ImageWidth="200px"></f:ImageField>
                <f:BoundField Width="100px" DataField="BannerText" DataFormatString="{0} " HeaderText="文字" SortField="BannerText" /> 
                <f:BoundField Width="100px" DataField="BannerUrl" DataFormatString="{0} " HeaderText="链结" SortField="BannerUrl" /> 
                <f:BoundField Width="250px" DataField="BannerImage" DataFormatString="{0} " HeaderText="图档位置" SortField="BannerImage" /> 
                <f:CheckBoxField Width="80px" RenderAsStaticField="true" DataField="IsUse" HeaderText="是否使用" />
                <f:BoundField Width="200px" DataField="Created" DataFormatString="{0} " HeaderText="建档" SortField="QAAnswer" Hidden="true" /> 
                <f:BoundField Width="200px" DataField="Updated" DataFormatString="{0} " HeaderText="更档" SortField="QAAnswer" Hidden="true" /> 
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="50px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="删除" Icon="ApplicationDelete" ToolTip="删除"  Width="50px" CommandName="Action2" ConfirmText="确定要删除吗？" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="700px" Height="600px" Title="维护" BodyPadding="5px"
            WindowPosition="Center" EnableMaximize="true">
            <Items>
                <f:SimpleForm runat="server" ID="SimpleForm1" ShowHeader="false" LabelAlign="Right">
                    <Items>
                        <f:TextBox runat="server" Label="编号" ID="BannerID" Required="true" />
                        <f:TextBox runat="server" ID="BannerText" Label="文字" Required="false" />
                        <f:TextBox runat="server" ID="BannerUrl" Label="Url" Required="false" EmptyText="若无跳转，不需填写" />
                        <f:Image ID="imgPhoto" CssClass="photo" ImageUrl="~/res/images/blank.png" ShowEmptyLabel="true" runat="server" Width="325" Height="225">
                        </f:Image>
                        <f:FileUpload runat="server" ID="filePhoto" ShowRedStar="false" ShowEmptyLabel="true"
                            ButtonText="上传图片" ButtonOnly="true" Required="false" ButtonIcon="ImageAdd"
                            AutoPostBack="true" OnFileSelected="filePhoto_FileSelected">
                        </f:FileUpload>
                        <f:TextBox runat="server" ID ="Text1" Label="建议尺寸" Text="902 x 220" Readonly ="true" />
                        <f:Button ID="btnSubmit" CssClass="marginr" runat="server" OnClick="btnSubmit_Click" ValidateForms="SimpleForm1" Text="更改" />
                    </Items>
                </f:SimpleForm>
            </Items>
        </f:Window>
    </form>
</body>
</html>
