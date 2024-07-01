<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillPOList.aspx.cs" Inherits="BillPOList" %>


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
        <f:Grid ID="Grid1" Title="採購單管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"  
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"  EnableTextSelection="true"  
            DataKeyNames="BillNo"  SortField="billno" SortDirection="Desc"   >
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
                <f:BoundField Width="150px" DataField="BillDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="日期" SortField="BillDate" TextAlign="Center" /> 
                <f:BoundField Width="200px" DataField="VendorName" DataFormatString="{0} " HeaderText="供應商" SortField="VendorName" /> 
                <f:BoundField Width="150px" DataField="PID" DataFormatString="{0} " HeaderText="商品代號" SortField="VendorName" /> 
                <f:BoundField Width="150px" DataField="PName" DataFormatString="{0} " HeaderText="商品名稱" SortField="PName" /> 
                <f:BoundField Width="100px" DataField="PNum" DataFormatString="{0:N0} " HeaderText="請購數量" SortField="PNum" TextAlign="Right" /> 
                <f:BoundField Width="150px" DataField="Amount" DataFormatString="{0:N2} " HeaderText="金額" SortField="Amount" TextAlign="Right" /> 
                <f:BoundField Width="100px" DataField="SINum" DataFormatString="{0:N0} " HeaderText="進貨數量" SortField="SINum" TextAlign="Right" /> 
                <f:BoundField Width="150px" DataField="HopeDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="希望完成" SortField="HopeDate"  TextAlign="Center"/> 
                <f:BoundField Width="150px" DataField="CloseDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="完成日期" SortField="CloseDate"  TextAlign="Center"/> 
                <f:CheckBoxField TrueStrings="false,False" Width="100px" RenderAsStaticField="true" DataField="IsClose" HeaderText="是否完案"  TextAlign="Center"/>                
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="明細" Icon="ApplicationViewList" ToolTip="明細"  Width="60px" CommandName="Action1" />
            </Columns>
        </f:Grid>
        
        <f:Window ID="Window1" runat="server" Hidden="true" Width="1600px" Height="800px" Title="明細" BodyPadding="5px" EnableIFrame="true"
            WindowPosition="Center" EnableMaximize="true"/>
    </form>
</body>
</html>
