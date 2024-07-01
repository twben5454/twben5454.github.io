<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vendor.aspx.cs" Inherits="Vendor" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>財團法人台灣商品檢測驗證中心 管理系統</title>
    <script src="res/jquery-3.4.1.min.js"></script>
    <script>
        $(document).on('mouseover', '.f-grid-table td', function () {
            $(this).attr('title', $(this).text());
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1"  runat="server"  ></f:PageManager>
        <f:Grid ID="Grid1" Title="供應商資料管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"   IsDatabasePaging="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"  EnableTextSelection="true"  
            DataKeyNames="SID"  SortField="SID" SortDirection="Desc"  ForceFit="true" >
            <Toolbars>
                <f:Toolbar ID="Toolbar2" Position="Top" runat="server" >
                    <Items>                        
                        <f:Button runat="server" ID ="btnAdd" Icon="Add" Text="新增" OnClick="btnAdd_Click" ></f:Button>
                        <f:Textbox runat="server" ID ="txtSearch" Label="關鍵字查詢" EmptyText="" LabelWidth="160"></f:Textbox>
                        <f:Button ID="btnSearch" Text="查詢" runat="server"  OnClick="btnSearch_Click" Icon="Zoom" />
                        <f:Button ID="btnRefresh" Text="重新整理" runat="server"   Icon="Reload" OnClick="btnRefresh_Click" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="導出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
                </Toolbars>
            <Columns>
                    <f:BoundField Width="100px" DataField="SID" DataFormatString="{0} " HeaderText="自動編號" SortField="SID" Hidden="true" /> 
                    <f:BoundField Width="100px" DataField="VendorID" DataFormatString="{0} " HeaderText="供應商編號" SortField="CustomerID" /> 
                   <f:BoundField Width="100px" DataField="VendorName" DataFormatString="{0} " HeaderText="供應商名稱" SortField="CustomerName" /> 
                    <%-- <f:BoundField Width="100px" DataField="TaxAddress" DataFormatString="{0} " HeaderText="發票地址" SortField="TaxAddress"  Hidden="true"/> 
                    <f:BoundField Width="100px" DataField="Address" DataFormatString="{0} " HeaderText="地址" SortField="Address" Hidden="true" /> 
                    <f:BoundField Width="100px" DataField="Tel" DataFormatString="{0} " HeaderText="電話" SortField="Tel" /> 
                    <f:BoundField Width="100px" DataField="Fax" DataFormatString="{0} " HeaderText="傳真" SortField="Fax" /> 
                    <f:BoundField Width="100px" DataField="CellPhone" DataFormatString="{0} " HeaderText="行動電話" SortField="CellPhone" /> 
                    <f:BoundField Width="100px" DataField="WebSite" DataFormatString="{0} " HeaderText="網站" SortField="WebSite"  Hidden="true"/> 
                    <f:BoundField Width="100px" DataField="InvoiceTitle" DataFormatString="{0} " HeaderText="發票抬頭" SortField="InvoiceTitle" /> --%>
                    <f:BoundField Width="100px" DataField="InvoiceNo" DataFormatString="{0} " HeaderText="統一編號" SortField="InvoiceNo" /> 
                    <f:BoundField Width="100px" DataField="ContractName" DataFormatString="{0} " HeaderText="連絡人" SortField="ContractName" /> 
                    <f:BoundField Width="100px" DataField="ContractTel" DataFormatString="{0} " HeaderText="連絡人電話" SortField="ContractTel" /> 
                    <f:BoundField Width="100px" DataField="ContractCellPhone" DataFormatString="{0} " HeaderText="連絡人行動" SortField="ContractCellPhone" /> 
                    <f:BoundField Width="100px" DataField="Memo" DataFormatString="{0} " HeaderText="備註" SortField="Memo"  Hidden="true"/> 
                    <f:BoundField Width="100px" DataField="CreateTime" DataFormatString="{0} " HeaderText="建檔時間" SortField="CreateTime" Hidden="true" /> 
                    <f:BoundField Width="100px" DataField="CreateUser" DataFormatString="{0} " HeaderText="建檔者" SortField="CreateUser" Hidden="true" /> 
                    <f:BoundField Width="100px" DataField="EditTime" DataFormatString="{0} " HeaderText="更檔時間" SortField="EditTime" Hidden="true" /> 
                    <f:BoundField Width="100px" DataField="EditUser" DataFormatString="{0} " HeaderText="更檔人" SortField="EditUser" Hidden="true" /> 
                    <f:BoundField Width="100px" DataField="StatusCode" DataFormatString="{0} " HeaderText="狀態" SortField="StatusCode" Hidden="true" />                 
                    <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="60px" CommandName="Action1" />
                    <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="删除" Icon="ApplicationDelete" ToolTip="删除"  Width="60px" CommandName="Action2" ConfirmText="確定要刪除嗎？" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="900px" Height="500px" Title="維護" BodyPadding="5px" AutoScroll="true" WindowPosition="Center" EnableMaximize="true">
            <Items>
                <f:Form runat="server" ID="SimpleForm1" ShowHeader="false" LabelAlign="Right" LabelWidth="110px">
                    <Rows>
                        <f:FormRow ColumnWidths="50% 50%" Hidden="true">
                            <Items>
                                <f:TextBox runat="server" ID="SID" Label="序號" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="50% 50%">
                            <Items>
                                <f:TextBox runat="server" ID="CustomerID" Label="客戶編號" Required="false" />
                                <f:TextBox runat="server" ID="CustomerName" Label="客戶名稱" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="100%">
                            <Items>
                                <f:TextBox runat="server" ID="TaxAddress" Label="發票地址" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="100%">
                            <Items>
                                <f:TextBox runat="server" ID="Address" Label="地址" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="50% 50%">
                            <Items>
                                <f:TextBox runat="server" ID="Tel" Label="電話" Required="false" />
                                <f:TextBox runat="server" ID="Fax" Label="傳真" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="50% 50%">
                            <Items>
                                <f:TextBox runat="server" ID="CellPhone" Label="行動電話" Required="false" />
                                <f:TextBox runat="server" ID="WebSite" Label="網站" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="50% 50%">
                            <Items>
                                <f:TextBox runat="server" ID="InvoiceTitle" Label="發票抬頭" Required="false" />
                                <f:TextBox runat="server" ID="InvoiceNo" Label="統一編號" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="33% 33% 33%">
                            <Items>
                                <f:TextBox runat="server" ID="ContractName" Label="連絡人" Required="false" />
                                <f:TextBox runat="server" ID="ContractTel" Label="連絡人電話" Required="false" />
                                <f:TextBox runat="server" ID="ContractCellPhone" Label="連絡人行動" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="100%">
                            <Items>
                                <f:TextArea runat="server" ID="Memo" Label="備註" Required="false" />
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="50% 50%">
                            <Items>
                                <f:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidateForms="SimpleForm1" CssStyle="background-color:green;color:white;" Text="更改" />
                                <f:Button ID="btnDel" runat="server" OnClick="btnDel_Click" CssStyle="background-color:red;color:white;" Text="刪除" ConfirmText="確定要刪除嗎?" />
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
        </f:Window>
        
    </form>
</body>
</html>
