<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillPODetail.aspx.cs" Inherits="BillPODetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
<%--    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">--%>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server"></f:PageManager>
        <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="true" LabelWidth="120px"
            Title="採購單" runat="server">
            <Toolbars>
                 <f:Toolbar ID="Toolbar1" Position="Top" runat="server">
                     <Items>
                         <f:Button runat="server" ID="btnBack" CssClass="btn bg-success text-white " Text="回採購列表" CssStyle="background-color:gray;color:white;" OnClick="btnBack_Click" ></f:Button>
                         <f:Button runat="server" ID="btnSave" CssClass="btn bg-success text-white " Text="存檔" CssStyle="background-color:green;color:white;" ConfirmText="確定存檔嗎?" OnClick="btnSave_Click" ValidateForms="SimpleForm1"></f:Button>
                     </Items>
                 </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow ID="FormRow5" ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:TextBox runat="server" ID="BillNo" Label="單號" Required="true" ShowRedStar="true" />
                        <f:DatePicker runat="server" ID="BillDate" Label="日期" Required="true" ShowRedStar="true" />
                        <f:DatePicker runat="server" ID="HopeDate" Label="希望完成日" Required="true" ShowRedStar="true" />
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:DropDownList runat="server" ID="SourceID" Label="供應商" Required="true" ShowRedStar="true" />
                        <f:DropDownList runat="server" ID="StockID" Label="目標倉庫" Required="true" ShowRedStar="true" Hidden="true" />
                        <f:NumberBox runat="server" ID="Amount" Label="小計" Readonly="true"  />
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:TextBox runat="server" ID="SourceNo" Label="來源單號"  Hidden="true" />
                        <f:CheckBox runat="server" ID="IsClose" Label="是否結案" Text="是" />
                        <f:DatePicker runat="server" ID="CloseDate" Label="結案日"  />
                    </Items>
                </f:FormRow>
                
                <f:FormRow ColumnWidths="100%">
                    <Items>
                        <f:TextArea runat="server" ID="Memo" Label="備註" Required="false" ShowRedStar="false" />
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
        <f:Grid ID="Grid1" Title="明細" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"   OnRowCommand="Grid1_RowCommand"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="false" PageSize="20" AllowSorting="false" ShowSelectedCell="true" EnableRowDoubleClickEvent="true"
            DataKeyNames="PID" >
            <Toolbars>
                <f:Toolbar ID="Toolbar2" Position="Top" runat="server">
                    <Items>
                        <f:DropDownList runat="server" ID="PID"  AutoPostBack="true" OnSelectedIndexChanged="drpProduct_SelectedIndexChanged"/>
                        <f:NumberBox runat="server" ID="Price" Label="單價"  Width="200"    LabelAlign="Right"/>
                        <f:NumberBox runat="server" ID="PNum" Label="數量"  Width="200" Text="1"  LabelAlign="Right"/>
                        <f:Button runat="server" ID="btnAddSub" Text="確定" CssStyle=" background-color:blue;color:white;" OnClick="btnAddSub_Click"></f:Button>
                        <f:Button runat="server" ID="btnCancel" Text="取消"  CssStyle="background-color:orange;color:white;" OnClick="btnCancel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField Width="200px" DataField="PID" DataFormatString="{0} " HeaderText="產品代號"  /> 
                <f:BoundField Width="200px" DataField="PName" DataFormatString="{0} " HeaderText="產品名稱"  /> 
                <f:BoundField Width="200px" DataField="Price" DataFormatString="{0:N2} " HeaderText="單價" TextAlign="Right" /> 
                <f:BoundField Width="200px" DataField="ItemNum" DataFormatString="{0} " HeaderText="數量"  TextAlign="Right" /> 
                <f:BoundField Width="200px" DataField="Amount" DataFormatString="{0:N2} " HeaderText="小計"  TextAlign="Right" /> 
                <f:BoundField MinWidth="200px" ExpandUnusedSpace="true" DataField="Memo" DataFormatString="{0} " HeaderText="備註"  /> 
                        <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="删除" Icon="ApplicationDelete" ToolTip="删除"  Width="50px" CommandName="Action1" ConfirmText="確定要刪除嗎？" />
            </Columns>
        </f:Grid>
    </form>
</body>
</html>
