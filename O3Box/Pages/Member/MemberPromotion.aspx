<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberPromotion.aspx.cs" Inherits="MemberPromotion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CatchaFace</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>        
        <f:Grid ID="Grid1" Title="會員訂單記錄" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"  
            DataKeyNames="PromotionDate "  SortField="PromotionDate" SortDirection="Desc"  >
           
            <Columns>
                <f:BoundField Width="150px" DataField="PromotionDate" DataFormatString="{0:yyyy-MM-dd} " HeaderText="晉升日期" SortField="PromotionDate" /> 
                <f:BoundField Width="150px" DataField="SourceClassName" DataFormatString="{0} " HeaderText="原始等級" SortField="SourceClassName" /> 
                <f:BoundField Width="150px" DataField="TargetClassName" DataFormatString="{0} " HeaderText="晉升等級" SortField="TargetClassName" /> 
            </Columns>
        </f:Grid>
       
    </form>
</body>
</html>
