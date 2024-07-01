<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BonusList.aspx.cs" Inherits="BonusList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        
        <f:Panel ID="Panel1" IsFluid="true" CssClass="blockpanel" runat="server"
            AutoScroll="true" ShowBorder="true" EnableCollapse="false"
            BodyPadding="10px" Layout="Column" ShowHeader="true" Title="面板">
            <Items>
                <f:Panel ID="Panel24" ColumnWidth="50%" runat="server"
                    ShowBorder="false" ShowHeader="false" Margin="0 5px 0 0">
                    <Items>
                        <f:Panel ID="Panel25" runat="server" BodyPadding="10px" ShowBorder="true" ShowHeader="false" EnableCollapse="true" MarginBottom="5px">
                            <Items>
                                <f:Grid ID="Grid1" Title="獎金計算查詢管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
                                    runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
                                    OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" EnableRowClickEvent="true" OnRowClick="Grid1_RowClick"
                                    DataKeyNames="MemberID ,OrderID ,OrderDate ,Amount" SortField="OrderID" SortDirection="Desc">
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar3" Position="Top" runat="server">
                                            <Items>
                                                <f:TextBox runat="server" ID="txtSearch" Label="訂單ID" EmptyText=""></f:TextBox>
                                                <f:Button ID="btnSelectItem6" Text="查詢" runat="server" OnClick="btnSelectItem6_Click" Icon="Zoom" />
                                                <f:Button ID="btnRefresh" Text="重新整理" runat="server" Icon="Reload" OnClick="btnRefresh_Click" />
                                                <f:Button runat="server" ID="btnExcel" Icon="FolderExplore" Text="導出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                    <Columns>
                                        <f:BoundField Width="150px" DataField="OrderID" DataFormatString="{0} " HeaderText="訂單ID" SortField="OrderID" />
                                        <f:BoundField Width="150px" DataField="OrderDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="訂單日期" SortField="OrderDate" />
                                        <f:BoundField Width="150px" DataField="MemberID" DataFormatString="{0} " HeaderText="訂單人" SortField="MemberID" />
                                        <f:BoundField Width="150px" DataField="Amount" DataFormatString="{0:N0} " HeaderText="訂單金額" SortField="Amount" TextAlign="Right" />
                                    </Columns>
                                </f:Grid>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel28" ColumnWidth="49%" runat="server"   BodyPadding="10px"  ShowBorder="true" ShowHeader="false" Margin="5px">
                    <Items>
                        <f:Grid ID="Grid2" Title="獎金計算結果" EnableFrame="false" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
                                    runat="server" EnableCheckBoxSelect="false" AllowPaging="false" PageSize="20" AllowSorting="false" ShowSelectedCell="true"
                                    DataKeyNames="MemberID ,BonusClassID ,Amount" SortField="OrderID" SortDirection="Desc"> 
                                <Toolbars>
                                        <f:Toolbar ID="Toolbar1" Position="Top" runat="server" >
                                            <Items>
                                                <f:Label runat="server" ID="OrderID" Label="<span style='color:blue;'>訂單ID</span>" LabelAlign="Right" ></f:Label>
                                                <f:Label runat="server" ID="MemberID" Label="<span style='color:blue;'>訂單人</span>" LabelAlign="Right" ></f:Label>
                                                <f:Label runat="server" ID="MemberClassID" Label="<span style='color:blue;'>等級</span>" LabelAlign="Right" ></f:Label>
                                                <f:Label runat="server" ID="Amount" Label="<span style='color:blue;'>訂單金額</span>" LabelAlign="Right" ></f:Label>
                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                    <Columns>
                                        <f:BoundField Width="150px" DataField="MemberID" DataFormatString="{0} " HeaderText="上線ID" SortField="MemberID" />
                                        <f:BoundField Width="150px" DataField="MemberClassID" DataFormatString="{0} " HeaderText="上線等級" SortField="MemberClassID" />
                                        <f:BoundField Width="150px" DataField="lvl" DataFormatString="{0} " HeaderText="階" SortField="lvl" />
                                        <f:BoundField Width="150px" DataField="BonusPercent" DataFormatString="{0:N0} " HeaderText="獎金比率" SortField="BonusPercent" TextAlign="Right" />
                                        <f:BoundField Width="150px" DataField="Bonus" DataFormatString="{0:N0} " HeaderText="獎金" SortField="Bonus"  TextAlign="Right"/>
                                    </Columns>
                                </f:Grid>
                    </Items>
                </f:Panel>
                
            </Items>
        </f:Panel>
    </form>
</body>
</html>
