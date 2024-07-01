<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderAdd.aspx.cs" Inherits="OrderAdd" %>

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
            Title="補貨訂單" runat="server">
            <Toolbars>
                <f:Toolbar runat="server" ID="Toolbar1">
                    <Items>
                        <f:Button ID="Button1" IconFont="_Save" Text="存檔" ValidateForms="SimpleForm1" runat="server" OnClick="Button1_Click" ConfirmText="確定要新增嗎?"  />
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow ID="FormRow5" ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:TriggerBox ID="MemberID" ShowLabel="true" Readonly="false" TriggerIcon="Search" Label="會員ID" 
                            OnTriggerClick="MemberID_TriggerClick" EmptyText="點選選擇會員ID" runat="server" EnablePostBack="true"  >
                        </f:TriggerBox>
                        <f:TextBox runat="server" ID="MemberName" Label="會員名稱" Required="true" />
                        <f:TextBox runat="server" ID="MemberClassID" Label="會員等級" Required="true" />
                    </Items>
                </f:FormRow>
                <f:FormRow  ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:TextBox runat="server" ID="UpMemberID" Label="上線會員名稱" Required="true" />
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
                    DataKeyNames="MemberID,MemberName,MemberClassName ,UpMemberID" SortField="MemberID" SortDirection="Asc">
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
        <f:Grid ID="Grid2" Title="產品列表" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
                    runat="server" EnableCheckBoxSelect="false" AllowPaging="false" AllowSorting="false" ShowSelectedCell="true" 
                     EnableTextSelection="true" 
                    DataKeyNames="PID" SortField="PID" SortDirection="Asc">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar3" Position="Top" runat="server">
                            <Items>
                                <f:DropDownList runat="server" ID="PID" Label="產品" EmptyText="" LabelWidth="160"  Width="450" AutoPostBack ="true" OnSelectedIndexChanged="PID_SelectedIndexChanged"/>
                                <f:Label runat="server" ID="Price" Label="單價"  LabelWidth="100"/>
                                <f:NumberBox runat="server" ID="Num" Label="數量" Text="1" LabelWidth="160" AutoPostBack="true" OnTextChanged="Num_TextChanged"/>
                                <f:Button ID="btnAdd" Text="增加" runat="server" OnClick="btnAdd_Click" Icon="Add" />
                                <f:Label runat="server" ID="lblTotal" Label="合計"  LabelWidth="100"/>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField Width="150px" DataField="PID" DataFormatString="{0} " HeaderText="產品ID" SortField="PID" />
                        <f:BoundField Width="250px" DataField="PName" DataFormatString="{0} " HeaderText="產品名稱" SortField="PName"  MinWidth="150px" HtmlEncode="true" />
                        <f:BoundField Width="150px" DataField="Price" DataFormatString="{0} " HeaderText="單價" SortField="Price" />
                        <f:BoundField Width="150px" DataField="Num" DataFormatString="{0} " HeaderText="數量" SortField="Num" />
<%--                        <f:BoundField Width="150px" DataField="Amount" DataFormatString="{0} " HeaderText="小計" SortField="Amount" />--%>
                    </Columns>
                </f:Grid>
    </form>
</body>
</html>
