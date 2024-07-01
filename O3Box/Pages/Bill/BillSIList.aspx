<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillSIList.aspx.cs" Inherits="BillSIList" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
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
        <f:Grid ID="Grid1" Title="進貨單管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"  EnableRowDoubleClickEvent="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"  EnableTextSelection="true"  OnRowDoubleClick="Grid1_RowDoubleClick"
            DataKeyNames="billno"  SortField="billno" SortDirection="Desc"   >
            <Toolbars>
                <f:Toolbar ID="Toolbar2" Position="Top" runat="server" >
                    <Items>                        
                        <f:Button runat="server" ID ="btnAdd" Icon="Add" Text="新增" OnClick="btnAdd_Click"  ></f:Button>
                        <f:Textbox runat="server" ID ="txtSearch" Label="關鍵字查詢" EmptyText="" LabelWidth="100" LabelAlign="Right"></f:Textbox>
                        <f:Button ID="btnSearch" Text="查詢" runat="server"  OnClick="btnSearch_Click" Icon="Zoom" />
                        <f:Button ID="btnRefresh" Text="重新整理" runat="server"   Icon="Reload" OnClick="btnRefresh_Click" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="導出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
                </Toolbars>
            <Columns>
                <f:BoundField Width="150px" DataField="billno" DataFormatString="{0} " HeaderText="單號" SortField="billno" /> 
                <f:BoundField Width="100px" DataField="BillDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="日期" SortField="BillDate" /> 
                <f:BoundField Width="200px" DataField="SupplierName" DataFormatString="{0} " HeaderText="供應商" SortField="SupplierName" /> 
                <f:BoundField Width="100px" DataField="Amount" DataFormatString="{0:N2} " HeaderText="金額" SortField="Amount" TextAlign="Right" /> 
                <f:BoundField Width="250px" DataField="HopeDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="希望完成" SortField="HopeDate" /> 
                <f:BoundField Width="250px" DataField="CloseDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="完成日期" SortField="CloseDate" /> 
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="800px" Height="550px" Title="維護" BodyPadding="5px" AutoScroll="true"  WindowPosition="Center" EnableMaximize="true"  >
            <Items>
                <f:Form runat="server" ID="SimpleForm1" ShowHeader="false" LabelAlign="Right" LabelWidth="110px">
                    <Rows>
                        <f:FormRow ColumnWidths="50% 50%">
                            <Items>
                                <f:TextBox runat="server" ID="PID" Label ="產品ID" Required="true"/> 
                                <f:NumberBox runat="server" ID="Cost" Label ="成本" Required="true" /> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="100%">
                            <Items>
                                <f:TextBox runat="server" ID="PName" Label ="產品名稱" Required="true"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="100%">
                            <Items>
                                <f:NumberBox runat="server" ID="PriceA" Label ="總代理售價" Required="true"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="100%">
                            <Items>
                                <f:NumberBox runat="server" ID="PriceB" Label ="區代理售價" Required="true"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="100%">
                            <Items>
                                <f:NumberBox runat="server" ID="PriceC" Label ="一級代理售價" Required="true"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="100%">
                            <Items>
                                <f:NumberBox runat="server" ID="PriceD" Label ="體驗代理售價" Required="true"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="100%">
                            <Items>
                                <f:NumberBox runat="server" ID="PriceE" Label ="一般會員售價" Required="true"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="100%">
                            <Items>
                                <f:TextBox runat="server" ID="Spec" Label ="規格" Required="false"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="50% 50%">
                            <Items>
                                <f:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidateForms="SimpleForm1" Text="更改" />
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
        </f:Window>
        <f:Window ID="Window2" runat="server" Hidden="true" Width="800px" Height="300px" Title="明細" BodyPadding="5px" EnableIFrame="true"
            WindowPosition="Center" EnableMaximize="true"/>
    </form>
</body>
</html>
