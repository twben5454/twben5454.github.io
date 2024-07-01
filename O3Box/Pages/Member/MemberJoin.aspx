<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberJoin.aspx.cs" Inherits="Admin_Page_Member_MemberJoin" %>
<%@ Register Src="~/Admin/WebUserControl2.ascx" TagPrefix="uc1" TagName="WebUserControl2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CatchaFace</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <uc1:WebUserControl2 runat="server" ID="WebUserControl2" />
        <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="true" LabelWidth="120px"
            Title="會員加入" runat="server">
            <Toolbars>
                <f:Toolbar runat="server" ID="Toolbar1">
                    <Items>
                        <f:Button ID="Button1" IconFont="_Save" Text="存檔" ValidateForms="SimpleForm1" runat="server" OnClick="Button1_Click"  />
                        <f:Button ID="btnReInput" IconFont="_Save" Text="再輸入新會員"  runat="server" OnClick="btnReInput_Click"  />
                        <f:Button ID="btnBack" IconFont="_Save" Text="回會員列表"  runat="server" OnClick="btnBack_Click"  />
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow ID="FormRow5" ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:TextBox runat="server" ID="MemberID" Label="會員ID" Required="false" EmptyText="自動編號" />
                        <f:TextBox runat="server" ID="MemberName" Label="會員姓名" Required="true" ShowRedStar="true" />
                        <f:DatePicker runat="server" ID="JoinDate" Label="加入日期" Required="false" />
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:DatePicker runat="server" ID="Birthday" Label="生日" Required="false" />
                        <f:TextBox runat="server" ID="Email" Label="Email" Required="false" />
                        <f:TextBox runat="server" ID="CellPhone" Label="手機" Required="true" />
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:TextBox runat="server" ID="MemberUrl" Label="個人網址" Required="false" />
                        <f:TextBox runat="server" ID="FB" Label="FB" Required="false" />
                        <f:TextBox runat="server" ID="LineID" Label="Line" Required="false" />
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="33% 67%">
                    <Items>
                        <f:TextBox runat="server" ID="Zip" Label="郵遞區號" Required="false" />
                        <f:TextBox runat="server" ID="Address" Label="地址" Required="false" />
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:DropDownList runat="server" ID="BankID" Label="銀行" Required="false" />
                        <f:TextBox runat="server" ID="BankAccount" Label="銀行帳號" Required="false" />
                        <f:TextBox runat="server" ID="BankAccountName" Label="帳號姓名" Required="false" />
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
    </form>
</body>
</html>
