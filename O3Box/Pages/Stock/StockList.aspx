<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockList.aspx.cs" Inherits="StockList" %>


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
        <f:Grid ID="Grid1" Title="庫存瀏覽管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"  EnableRowDoubleClickEvent="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"  EnableTextSelection="true"  OnRowDoubleClick="Grid1_RowDoubleClick"
            DataKeyNames="billno"  SortField="billno" SortDirection="Desc"   >
            <Toolbars>
                <f:Toolbar ID="Toolbar2" Position="Top" runat="server" >
                    <Items>        
                        <f:DatePicker runat="server" ID="SDate" Label="日期起" LabelAlign="Right"></f:DatePicker>
                        <f:DatePicker runat="server" ID="EDate" Label="日期迄" LabelAlign="Right"></f:DatePicker>
                        
                        
                        <f:Button ID="btnSearch" Text="查詢" runat="server"  OnClick="btnSearch_Click" Icon="Zoom" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="導出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server" >
                    <Items>        
                       <f:CheckBoxList runat="server" ID="StockID" Label="倉庫" LabelAlign="Right"   Width="800"></f:CheckBoxList>
                       <f:CheckBoxList runat="server" ID="PID" Label="產品" LabelAlign="Right"  Width="800" ColumnNumber="4" Hidden="true"></f:CheckBoxList>
                    </Items>
                </f:Toolbar>
             </Toolbars>
            <Columns>
                <f:BoundField Width="150px" DataField="BillTypeName" DataFormatString="{0} " HeaderText="類別" SortField="BillTypeName" /> 
                <f:BoundField Width="150px" DataField="billno" DataFormatString="{0} " HeaderText="單號" SortField="billno" /> 
                <f:BoundField Width="100px" DataField="BillDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="日期" SortField="BillDate" /> 
                
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="1600px" Height="750px" Title="單據明細" BodyPadding="0 5px"  AutoScroll="true"  WindowPosition="Center" EnableMaximize="true" EnableIFrame="true"  >
            <Items>
            </Items>
        </f:Window>
        <f:Window ID="Window2" runat="server" Hidden="true" Width="800px" Height="300px" Title="明細" BodyPadding="5px" EnableIFrame="true"
            WindowPosition="Center" EnableMaximize="true"/>
    </form>
</body>
</html>
