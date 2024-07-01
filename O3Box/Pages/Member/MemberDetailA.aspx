<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberDetailA.aspx.cs" Inherits="Admin_Page_Member_MemberDetailA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CatchaFace </title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="false" LabelWidth="120px"
                    Title="" runat="server">
            <Toolbars>
                <f:Toolbar runat="server" ID="Toolbar1">
                    <Items>
                        <f:Button runat="server" ID="btnSave" Text="存檔" OnClick="btnSave_Click" ></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
                   <Rows>
                        <f:FormRow ID="FormRow5" ColumnWidths="50% 50%">
                            <Items>
                               <f:TextBox runat="server" ID="MemberID" Label ="會員ID" Required="true" Readonly="true"/>
                                <f:TextBox runat="server" ID="MemberName" Label ="會員姓名" Required="true" ShowRedStar="true" Readonly="true"/>                                
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="50% 50%">
                            <Items>
                                <f:TextBox runat="server" ID="CellPhone" Label ="手機" Required="false"/> 
                                <f:DatePicker runat="server" ID="JoinDate" Label ="加入日期" Required="false" Readonly="true"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="50% 50%">
                            <Items>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="50% 50%">
                            <Items>
                               <f:TextBox runat="server" ID="MemberClassID" Label ="會員等級" Required="true" ShowRedStar="true" Readonly="true"/> 
                                <f:DatePicker runat="server" ID="Birthday" Label ="生日" Required="false"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow7" ColumnWidths="50% 50%">
                            <Items>
                               <f:TextBox runat="server" ID="Email" Label ="Email" Required="false"/> 
                               <f:TextBox runat="server" ID="MemberUrl" Label ="個人網址" Required="false"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="30% 70%">
                            <Items>
                               <f:TextBox runat="server" ID="Zip" Label ="郵遞區號" Required="false"/> 
                               <f:TextBox runat="server" ID="Address" Label ="地址" Required="false"/> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="30% 70%">
                            <Items>
                               <f:DropDownList runat="server" ID="BankID" Label ="銀行" Required="false"/> 
                               <f:TextBox runat="server" ID="BankAccount" Label ="銀行帳號" Required="false"/> 
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
    </form>
</body>
</html>
