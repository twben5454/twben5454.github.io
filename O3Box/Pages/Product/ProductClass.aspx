<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductClass.aspx.cs" Inherits="ProductClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=DB.getObject().WebSiteName%></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Tree ID="Tree1"  CssClass="blockpanel" ShowHeader="true" Title="商品分類管理" EnableCollapse="false"
            runat="server" Expanded="true" >
            <Toolbars>
                <f:Toolbar runat="server" ID="Toolbar11">
                    <Items>
                        <f:Button runat="server" ID ="btnAdd" Icon="Add" Text="新增" OnClick="btnAdd_Click" ></f:Button>
                        <f:Button runat="server" ID ="btnEdit" Icon="ApplicationEdit" Text="更改" OnClick="btnEdit_Click" ></f:Button>
                        <f:Button runat="server" ID ="btnDel" Icon="Delete" Text="删除" ></f:Button>
                        <f:Button runat="server" ID ="btnReload" Icon="Reload" Text="重置" ></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            
        </f:Tree>
        <f:Window ID="Window1" runat="server" Title="商品分類管理" IsModal="false" EnableClose="true" EnableResize="true"
            Width="500px" BodyPadding="10px" AutoScroll="true" Hidden="true"  >
            <Items>
                <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="false" LabelWidth="120px"
                    Title="表单" runat="server">
                    <Rows>
                        <f:FormRow ID="FormRow5">
                            <Items>
                                <f:TextBox ID="ProductClassID" runat="server" Label="商品分類ID" ShowRedStar="true" Required="true"></f:TextBox>
                            </Items>
                        </f:FormRow>
                         <f:FormRow ID="FormRow6">
                              <Items>
                                   <f:TextBox ID="ProductClassName" runat="server" Label="商品分類名稱" ShowRedStar="true" Required="true"></f:TextBox>
                              </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="btnSave" IconFont="_Save" Text="保存" ValidateForms="SimpleForm1" ValidateMessageBox="true" runat="server"  OnClick="btnSave_Click" />
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>
    </form>
</body>
</html>
