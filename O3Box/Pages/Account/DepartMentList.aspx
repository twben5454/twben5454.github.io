<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartMentList.aspx.cs" Inherits="DepartMentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:Grid ID="Grid1" Title="部门管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="DepartID"  SortField="DepartID" SortDirection="Desc"  EnableTree="true" TreeColumn="Name" DataIDField="DepartID" DataParentIDField="LinkDepartID" >
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server">
                    <Items>
                        <f:Button runat="server" ID ="btnAdd" Icon="Add" Text="增加" ></f:Button>
                        <f:DropDownList runat="server" ID="DropDownList1" Label="部门"/>
                        <f:DropDownList runat="server" ID="DropDownList2" Label="单位"/>
                        <f:Textbox runat="server" ID ="SDate" Label="模糊查询"></f:Textbox>
                        <f:Button ID="btnSelectItem6" Text="查询" runat="server"  OnClick="btnSelectItem6_Click" Icon="Zoom" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="导出Excel"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:RowNumberField />
                <f:BoundField Width="100px" DataField="DepartID" DataFormatString="{0} " HeaderText="" SortField="DepartID"  ExpandUnusedSpace="true" /> 
                <f:BoundField Width="100px" DataField="DepartName" DataFormatString="{0} " HeaderText="" SortField="DepartName" /> 
            </Columns>
        </f:Grid>
        
    </form>
</body>
</html>
