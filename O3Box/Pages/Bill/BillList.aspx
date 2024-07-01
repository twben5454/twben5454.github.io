<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillList.aspx.cs" Inherits="BillList" %>


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
            DataKeyNames="billno ,StockID"  SortField="billno" SortDirection="Desc"   >
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
                <f:BoundField Width="150px" DataField="BillTypeName" DataFormatString="{0} " HeaderText="類別" SortField="BillTypeName" /> 
                <f:BoundField Width="150px" DataField="billno" DataFormatString="{0} " HeaderText="單號" SortField="billno" /> 
                <f:BoundField Width="100px" DataField="BillDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="日期" SortField="BillDate" /> 
                <f:TemplateField Width="200px" ColumnID="SourceID"  HeaderText="供應商" SortField="SourceID" >
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# GetColumnText(Eval("SourceID").ToString() ,"SourceID") %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
               <%-- <f:TemplateField Width="200px" ColumnID="SourceNo"  HeaderText="來源單號" SortField="SourceNo" >
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# GetColumnText(Eval("SourceNo").ToString() ,"SourceNo") %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>--%>
                <f:TemplateField Width="200px" ColumnID="StockID"  HeaderText="StockID" SortField="StockID" >
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# GetColumnText(Eval("StockID").ToString() ,"StockID") %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                <f:BoundField Width="200px" ColumnID="Amount" DataField="Amount" DataFormatString="{0:N2} " HeaderText="金額" SortField="Amount" TextAlign="Right" /> 
                <f:BoundField Width="250px" ColumnID="HopeDate" DataField="HopeDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="希望完成" SortField="HopeDate" /> 
                <f:BoundField Width="250px" ColumnID="CloseDate" DataField="CloseDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="完成日期" SortField="CloseDate" /> 
                <f:BoundField Width="100px" DataField="Memo" DataFormatString="{0:yyyy-MM-dd} " HeaderText="備註" SortField="Memo" ExpandUnusedSpace="true" /> 
                
                        <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="删除" Icon="ApplicationDelete" ToolTip="删除"  Width="50px" CommandName="Action2" ConfirmText="確定要刪除嗎？" />
               <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="內容" Icon="ApplicationSideList" ToolTip="內容"  Width="100px" CommandName="Action1" />
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
