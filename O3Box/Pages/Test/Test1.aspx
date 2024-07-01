<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test1.aspx.cs" Inherits="Admin_Page_Test_Test1" %>

<%@ Register Src="~/Admin/WebUserControl2.ascx" TagPrefix="uc1" TagName="WebUserControl2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server"></f:PageManager>
        <uc1:WebUserControl2 runat="server" ID="WebUserControl2" />
        <f:Form runat="server" ID="SimpleForm1" ShowHeader="true" LabelAlign="Right" LabelWidth="150px" Title="測試____ 會員新加入">
            <Rows>
                <f:FormRow ColumnWidths="50% 50%">
                    <Items>
                        <f:TextBox runat="server" ID="MemberID" Label="會員手機" Required="true" Text="0911111111" />
                        <f:TextBox runat="server" ID="MemberName" Label="會員名稱" Required="true" Text="測試11"/>
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:TriggerBox ID="UpMemberID" ShowLabel="true" Readonly="false" TriggerIcon="Search" Label="上線會員ID" 
                            OnTriggerClick="UpMemberID_TriggerClick" EmptyText="點選選擇上線會員ID" runat="server" EnablePostBack="true"  >
                        </f:TriggerBox>
                        <f:TextBox runat="server" ID="UpMemberName" Label="上線會員名稱" Required="true" />
                        <f:TextBox runat="server" ID="UpMemberClassID" Label="上線會員等級" Required="true" />
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:DatePicker runat="server" ID="JoinDate" Label="加入日期" Required="true" Text="2019-09-22" />
                        <f:TextBox runat="server" ID="OrderID" Label="訂單ID" Required="true" />
                        <f:NumberBox runat="server" ID="Amount" Label="訂單金額" Required="true" Text="5600" />
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="50% 50%">
                    <Items>
                        <f:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidateForms="SimpleForm1" Text="確認" />
                        <f:Button ID="Button1" runat="server" OnClick="Button1_Click"  Text="Check" />
                        <f:Button ID="Button2" runat="server" OnClick="Button2_Click"  Text="Clear" />
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="100%">
                    <Items>
                        <f:TextArea runat="server" ID="Memo" Label="輸出"  Height="500px" />
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="800px" Height="600px" Title="上線會員選擇" BodyPadding="5px" EnableIFrame="false"            
            WindowPosition="Center" EnableMaximize="true" AutoScroll="true">
            <Items>
                <f:Grid ID="Grid1" Title="會員列表" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="false" CssClass="blockpanel"
                    runat="server" EnableCheckBoxSelect="false" AllowPaging="false" AllowSorting="false" ShowSelectedCell="true" EnableRowDoubleClickEvent="true"
                     EnableTextSelection="true" OnRowDoubleClick="Grid1_RowDoubleClick"
                    DataKeyNames="MemberID,MemberName,MemberClassName" SortField="MemberID" SortDirection="Asc">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" Position="Top" runat="server">
                            <Items>
                                <f:TextBox runat="server" ID="txtSearch" Label="關鍵字查詢" EmptyText="" LabelWidth="160"></f:TextBox>
                                <f:Button ID="btnSearch" Text="查詢" runat="server" OnClick="btnSearch_Click" Icon="Zoom" />
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField Width="150px" DataField="MemberID" DataFormatString="{0} " HeaderText="會員ID" SortField="PID" />
                        <f:BoundField Width="250px" DataField="MemberName" DataFormatString="{0} " HeaderText="會員名稱" SortField="PName" ExpandUnusedSpace="true" MinWidth="150px" HtmlEncode="true" />
                        <f:BoundField Width="150px" DataField="MemberClassName" DataFormatString="{0} " HeaderText="會員等級" SortField="Spec" />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Window>
        <f:HiddenField ID="HiddenField1" runat="server">
        </f:HiddenField>
    </form>
</body>
</html>
