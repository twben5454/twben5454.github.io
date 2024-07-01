<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CatchaFace</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" ></f:PageManager>
        <f:Grid ID="Grid1" Title="後台使用者" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="UserID,UserName,UserPassword,CellPhone,IsUse"  SortField="UserID" SortDirection="Desc"  >
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server" >
                    <Items>
                        <f:Button runat="server" ID ="btnAdd" Icon="Add" Text="新增" OnClick="btnAdd_Click" ></f:Button>
                        <f:Textbox runat="server" ID ="txtSearch" Label="關鍵字查詢" EmptyText=""></f:Textbox>
                        <f:Button ID="btnSelectItem6" Text="查詢" runat="server"  OnClick="btnSelectItem6_Click" Icon="Zoom" />
                        <f:Button ID="btnRefresh" Text="重新整理" runat="server"   Icon="Reload" OnClick="btnRefresh_Click" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="導出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField Width="100px" DataField="UserID" DataFormatString="{0} " HeaderText="ID" SortField="UserID" /> 
                <f:BoundField Width="200px" DataField="UserName" DataFormatString="{0} " HeaderText="使用者名稱" SortField="UserName" />
                <f:BoundField Width="100px" DataField="CreateTime" DataFormatString="{0} " HeaderText="建檔" SortField="CreateTime" Hidden="true" /> 
                <f:BoundField Width="100px" DataField="CreateID" DataFormatString="{0} " HeaderText="建檔時間" SortField="CreateID"  Hidden="true"/> 
                <f:BoundField Width="100px" DataField="EditTime" DataFormatString="{0} " HeaderText="更檔" SortField="EditTime" Hidden="true" /> 
                <f:BoundField Width="100px" DataField="EditID" DataFormatString="{0} " HeaderText="更檔時間" SortField="EditID"  Hidden="true"/> 
                <f:BoundField Width="100px" DataField="StatusCode" DataFormatString="{0} " HeaderText="顯示" SortField="StatusCode" Hidden="true" />  
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="更改" Icon="ApplicationEdit" ToolTip="更改"  Width="60px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="刪除" Icon="ApplicationDelete" ToolTip="刪除"  Width="60px" CommandName="Action2" ConfirmText="確定要刪除嗎？" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction3" HeaderText="重置密碼" Icon="ArrowRefresh" ToolTip="重置密碼"  Width="80px" CommandName="Action3" ConfirmText="確定要重置密碼嗎？" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction4" HeaderText="權限" Icon="ApplicationViewList" ToolTip="權限"  Width="80px" CommandName="Action4" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="400px" Height="300px" Title="维护" BodyPadding="5px" EnableIFrame="false"
            WindowPosition="GoldenSection" EnableMaximize="true">
            <Items>
                <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="false" LabelWidth="120px"
                    Title="表单" runat="server">
                    <Rows>
                        <f:FormRow ID="FormRow5">
                            <Items>
                               <f:TextBox runat="server" ID="UserID" Label ="使用者ID" Required="true" ShowRedStar="true"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow6">
                            <Items>
                               <f:TextBox runat="server" ID="UserName" Label ="使用者姓名" Required="true" ShowRedStar="true"/>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow7">
                            <Items>
                               <f:TextBox runat="server" ID="UserPassword" Label ="密碼" Required="true" InputType="Password" ShowRedStar="true"/> 
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Button ID="Button5" IconFont="_Save" Text="存檔" ValidateForms="SimpleForm1" runat="server" OnClick="btnSubmit_Click" />
            </Items>
        </f:Window>
    </form>
</body>
</html>
