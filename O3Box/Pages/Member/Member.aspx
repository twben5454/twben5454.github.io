<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>彤鑫管理系統</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        
        <f:Grid ID="Grid1" Title="會員管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"   IsDatabasePaging="true"
            DataKeyNames="MemberID ,MemberName"  SortField="MemberID" SortDirection="Desc"  >
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
                <f:BoundField Width="100px" DataField="MemberID" DataFormatString="{0} " HeaderText="會員ID" SortField="MemberID" /> 
                <f:BoundField Width="150px" DataField="MemberClassName" DataFormatString="{0} " HeaderText="會員等级" SortField="MemberClassName" /> 
                <f:BoundField Width="100px" DataField="MemberName" DataFormatString="{0} " HeaderText="會員姓名" SortField="MemberName" /> 
                <f:BoundField Width="100px" DataField="UpMemberID" DataFormatString="{0} " HeaderText="上線會員ID" SortField="UpMemberID" /> 
                <f:BoundField Width="100px" DataField="JoinDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="加入日期" SortField="JoinDate" /> 
                <f:BoundField Width="100px" DataField="lvl" DataFormatString="{0} " HeaderText="階" SortField="lvl" TextAlign="Center" /> 
                <f:BoundField Width="120px" DataField="SubMemberCount" DataFormatString="{0} " HeaderText="下線同階人數" SortField="SubMemberCount" TextAlign="Center" />
                <f:BoundField Width="100px" DataField="GroupAmount" DataFormatString="{0:N0} " HeaderText="組織業績" SortField="GroupAmount" TextAlign="Right" />  
                <f:BoundField Width="200px" DataField="Created" DataFormatString="{0} " HeaderText="建档" SortField="QAAnswer" Hidden="true" /> 
                <f:BoundField Width="200px" DataField="Updated" DataFormatString="{0} " HeaderText="更档" SortField="QAAnswer" Hidden="true" /> 
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="60px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="删除" Icon="ApplicationDelete" ToolTip="删除"  Width="60px" CommandName="Action2" ConfirmText="確定要刪除嗎？" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction3" HeaderText="重置密碼" Icon="ApplicationEdit" ToolTip="重置密碼"  Width="100px" CommandName="Action3" ConfirmText="確定要重置密碼嗎？"/>
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction4" HeaderText="詳細資料" Icon="UserHome" ToolTip="詳細資料"  Width="100px" CommandName="Action4" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="800px" Height="410px" Title="維護" BodyPadding="5px" EnableIFrame="false"
            WindowPosition="GoldenSection" EnableMaximize="true">
            <Items>
                <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="false" LabelWidth="120px"
                    Title="表单" runat="server">
                   <Rows>
                        <f:FormRow ID="FormRow5" ColumnWidths="50% 50%">
                            <Items>
                               <f:TextBox runat="server" ID="MemberID" Label ="會員ID" Required="true"/>
                                <f:TextBox runat="server" ID="MemberName" Label ="會員姓名" Required="true" ShowRedStar="true"/>                                
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="50% 50%">
                            <Items>
                                <f:DatePicker runat="server" ID="JoinDate" Label ="加入日期" Required="false"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="50% 50%">
                            <Items>
                               <f:DropDownList runat="server" ID="MemberClassID" Label ="會員等級" Required="true" ShowRedStar="true"/> 
                                <f:DatePicker runat="server" ID="Birthday" Label ="生日" Required="false"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow7" ColumnWidths="50% 50%">
                            <Items>
                               <f:TextBox runat="server" ID="Email" Label ="Email" Required="false"/> 
                               <f:TextBox runat="server" ID="MemberUrl" Label ="個人網址" Required="false"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="30% 70%">
                            <Items>
                               <f:TextBox runat="server" ID="Zip" Label ="郵遞區號" Required="false"/> 
                               <f:TextBox runat="server" ID="Address" Label ="地址" Required="false"/> 
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Button ID="Button1" IconFont="_Save" Text="存檔" ValidateForms="SimpleForm1" runat="server" OnClick="btnSubmit_Click" />
            </Items>
        </f:Window>
         <f:Window ID="Window2" runat="server" Hidden="true" Width="1200px" Height="700px" Title="維護" BodyPadding="5px" EnableIFrame="true"
            WindowPosition="GoldenSection" EnableMaximize="true" EnableClose="true">
         </f:Window>
    </form>
</body>
</html>
