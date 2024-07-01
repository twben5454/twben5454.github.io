<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="Pages_Order_OrderDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="false" LabelWidth="120px"
            Title="新加入訂單" runat="server">
           
            <Rows>
                 <f:FormRow  ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:TextBox runat="server" ID="OrderID" Label="訂單ID" Readonly ="true" ShowRedStar="true" />
                        <f:DatePicker runat="server" ID="OrderDate" Label="訂單日期" Readonly ="true" ShowRedStar="true" />
                        <f:TextBox runat="server" ID="Amount" Label="訂單金額" Readonly ="true" ShowRedStar="true" />
                    </Items>
                </f:FormRow>
                <f:FormRow ID="FormRow5" ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:TextBox runat="server" ID="MemberName" Label="會員名稱" Readonly="true" ShowRedStar="true" />
                        <f:TextBox runat="server" ID="PersonID" Label="身分證字號" Readonly="true"  ShowRedStar="true"/>
                        <f:TextBox runat="server" ID="CellPhone" Label="行動電話" Readonly="false"  ShowRedStar="false"/>
                    </Items>
                </f:FormRow>
                <f:FormRow  ColumnWidths="33% 33% 34%">
                    <Items>
                        <f:TextBox runat="server" ID="UpMemberID" ShowLabel="true" Readonly="false"  Label="上線會員ID"  ShowRedStar="true" />
                        <f:TextBox runat="server" ID="UpMemberName" Label="上線會員名稱" Readonly="true"  ShowRedStar="true"/>
                        <f:TextBox runat="server" ID="UpMemberClassID" Label="上線會員等級" Readonly="true"  ShowRedStar="true"/>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
        <f:Grid ID="Grid2" Title="產品列表" EnableFrame="true" EnableCollapse="false" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
                    runat="server" EnableCheckBoxSelect="false" AllowPaging="false" AllowSorting="false" ShowSelectedCell="true" 
                     EnableTextSelection="true" 
                    DataKeyNames="PID" SortField="PID" SortDirection="Asc">
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField Width="150px" DataField="PID" DataFormatString="{0} " HeaderText="產品ID" SortField="PID" />
                        <f:BoundField Width="250px" DataField="PName" DataFormatString="{0} " HeaderText="產品名稱" SortField="PName"  MinWidth="150px" HtmlEncode="true" ExpandUnusedSpace="true" />
                        <f:BoundField Width="200px" DataField="Price" DataFormatString="{0:N2} " HeaderText="單價" SortField="Price" TextAlign="Right" />
                        <f:BoundField Width="150px" DataField="Num" DataFormatString="{0} " HeaderText="數量" SortField="Num"  TextAlign="Right"/>
                        <f:BoundField Width="150px" DataField="Amount" DataFormatString="{0:N2} " HeaderText="小計" SortField="Amount"  TextAlign="Right"/>
                    </Columns>
                </f:Grid>
    </form>
</body>
</html>
