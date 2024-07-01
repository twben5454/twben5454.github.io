<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberA.aspx.cs" Inherits="MemberA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>天津车到食有限公司</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" Theme="Metro_Green"></f:PageManager>
        <f:Grid ID="Grid1" Title="会员管理" EnableFrame="true" EnableCollapse="true" ShowBorder="true" ShowHeader="true" CssClass="blockpanel"
            runat="server" EnableCheckBoxSelect="false" AllowPaging="true" PageSize="20" AllowSorting="true" ShowSelectedCell="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" 
            DataKeyNames="MemberID,MemberName,Password,Birthday,Sex,JoinDate,Tel,Email,IsHaveCar,WXID,Address,MemberClassID,Balance,Nation,Married,IDNu,Nativeplace,UserState,Lvl,Score,CarType,Model,FirstUseDate,CarClass,LimitDate,CarNo"  SortField="MemberID" SortDirection="Desc"  >
            <Toolbars>
                <f:Toolbar ID="Toolbar3" Position="Top" runat="server" >
                    <Items>
                        <f:Button runat="server" ID ="btnAdd" Icon="Add" Text="增加" OnClick="btnAdd_Click" ></f:Button>
                        <f:Textbox runat="server" ID ="txtSearch" Label="模糊查询" EmptyText="请输入编号或名称查询"></f:Textbox>
                        <f:Button ID="btnSelectItem6" Text="查询" runat="server"  OnClick="btnSelectItem6_Click" Icon="Zoom" />
                        <f:Button ID="btnRefresh" Text="重置" runat="server"   Icon="Reload" OnClick="btnRefresh_Click" />
                        <f:Button runat="server" ID ="btnExcel" Icon="FolderExplore" Text="导出Excel" EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnExcel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
               <f:BoundField Width="100px" DataField="MemberID" DataFormatString="{0} " HeaderText="会员ID" SortField="MemberID" /> 
             <f:BoundField Width="100px" DataField="MemberName" DataFormatString="{0} " HeaderText="会员姓名" SortField="MemberName" />
             
                <f:BoundField Width="150px" DataField="Birthday" DataFormatString="{0} " HeaderText="生日" SortField="Birthday" />
                <f:BoundField Width="50px" DataField="Sex" DataFormatString="{0} " HeaderText="性别" SortField="Sex" />
                <f:BoundField Width="150px" DataField="JoinDate" DataFormatString="{0} " HeaderText="加入日期" SortField="JoinDate" />
                <f:BoundField Width="100px" DataField="Tel" DataFormatString="{0} " HeaderText="手机号码" SortField="Tel" />
                <f:BoundField Width="200px" DataField="Email" DataFormatString="{0} " HeaderText="邮箱" SortField="Email" />
                <f:BoundField Width="100px" DataField="IsHaveCar" DataFormatString="{0} " HeaderText="是否有车" SortField="IsHaveCar" />
                <f:BoundField Width="200px" DataField="MemberClassName" DataFormatString="{0} " HeaderText="会员分类" SortField="MemberClassName" />
                <f:BoundField Width="100px" DataField="Balance" DataFormatString="{0} " HeaderText="余额" SortField="Balance" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction1" HeaderText="修改" Icon="ApplicationEdit" ToolTip="修改"  Width="60px" CommandName="Action1" />
                <f:LinkButtonField TextAlign="Center"  Text="" ColumnID="lbfAction2" HeaderText="删除" Icon="ApplicationDelete" ToolTip="删除"  Width="60px" CommandName="Action2" ConfirmText="确定要删除吗？" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true" Width="800px" Height="600px" Title="维护" BodyPadding="5px" EnableIFrame="false"
            WindowPosition="GoldenSection" EnableMaximize="true" AutoScroll="true">
            <Items>
                <f:Form ID="SimpleForm1" CssClass="blockpanel" BodyPadding="5 5 0 5" LabelAlign="right" ShowHeader="false" LabelWidth="120px"
                    Title="表单" runat="server">
                    <Rows>
                        <f:FormRow ID="FormRow5">
                            <Items>
                                <f:TextBox ID="MemberID" runat="server" Label="会员ID" ShowRedStar="true" Required="true"></f:TextBox>
                                <f:TextBox ID="MemberName" runat="server" Label="会员姓名" ShowRedStar="true" Required="true"></f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow6" runat="server">
                            <Items>
                                <f:RadioButtonList ID="Sex" Label="性别" runat="server" ShowRedStar="true" Required="true">
                                    <f:RadioItem Text="男" Value="1" Selected="true" />
                                    <f:RadioItem Text="女" Value="0" />
                                </f:RadioButtonList>
                                <f:DatePicker ID="Birthday" Label="出生日期" EmptyText="请选择日期" runat="server" EnableEdit="false" ShowRedStar="true" Required="true"></f:DatePicker>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow7" runat="server">
                            <Items>
                                <f:DatePicker ID="JoinDate" Label="加入日期" EmptyText="请选择日期" runat="server" EnableEdit="false" ShowRedStar="true" Required="true"></f:DatePicker>
                                <f:DropDownList ID="MemberClassID" Label="会员级别" AutoPostBack="false" CompareMessage="类型不能为空！" runat="server">
                                    <f:ListItem Text="普通会员" Value="0" Selected="true" />
                                    <f:ListItem Text="银牌会员" Value="1" />
                                    <f:ListItem Text="金牌会员" Value="2" />
                                    <f:ListItem Text="钻石会员" Value="3" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow3" runat="server">
                            <Items>
                                <f:TextBox ID="IDNu" Label="身分证号码" runat="server"></f:TextBox>
                                <f:RadioButtonList ID="Married" Label="婚姻状况" ShowRedStar="true" Required="true" runat="server">
                                    <f:RadioItem Text="未婚" Value="0" Selected="true" />
                                    <f:RadioItem Text="已婚" Value="1" />
                                    <f:RadioItem Text="离异" Value="2" />
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow8" runat="server">
                            <Items>
                                <f:TextBox ID="Tel" Label="手机号" runat="server"></f:TextBox>
                                <f:TextBox ID="Email" runat="server" Label="邮箱"></f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow1" runat="server">
                            <Items>
                                <f:TextBox ID="Address" runat="server" Label="地址"></f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow2" runat="server">
                            <Items>
                                <f:RadioButtonList ID="IsHaveCar" Label="是否有车" runat="server" ShowRedStar="true" Required="true" AutoPostBack="true" OnSelectedIndexChanged="IsHaveCar_SelectedIndexChanged">
                                    <f:RadioItem Text="有" Value="True" />
                                    <f:RadioItem Text="无" Value="False" Selected="true" />
                                </f:RadioButtonList>
                                <f:RadioButtonList ID="UserState" Label="是否有效" runat="server" ShowRedStar="true" Required="true">
                                    <f:RadioItem Text="有" Value="Y" Selected="true" />
                                    <f:RadioItem Text="无" Value="N" />
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow10" runat="server" Hidden="true">
                            <Items>
                                <f:TextBox ID="CarNo" runat="server" Label="车牌号码"></f:TextBox>
                                <f:DropDownList ID="CarType" Label="车辆类型" AutoPostBack="false" CompareMessage="类型不能为空！" runat="server">
                                    <f:ListItem Text="小型轿车" Value="小型轿车" Selected="true" />
                                    <f:ListItem Text="重型普通货车" Value="重型普通货车" />
                                    <f:ListItem Text="小型越野客车" Value="小型越野客车" />
                                    <f:ListItem Text="大型普通客车" Value="大型普通客车" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow11" runat="server" Hidden="true">
                            <Items>
                                <f:TextBox ID="Model" runat="server" Label="品牌型号"></f:TextBox>
                                <f:DatePicker ID="FirstUseDate" runat="server" Label="行驶证发证日期"></f:DatePicker>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow12" runat="server" Hidden="true">
                            <Items>
                                <f:RadioButtonList ID="CarClass" runat="server" Label="准驾车型" ColumnNumber="4">
                                    <f:RadioItem Text="小型汽车 C1" Value="C1" Selected="true" />
                                    <f:RadioItem Text="小型自动挡汽车 C2" Value="C2" />
                                    <f:RadioItem Text="低速载货汽车 C3" Value="C3" />
                                    <f:RadioItem Text="三轮汽车 C4" Value="C4" />
                                    <f:RadioItem Text="大型货车 B2" Value="B2" />
                                    <f:RadioItem Text="中型客车 B1" Value="B1" />
                                    <f:RadioItem Text="大型客车 A1" Value="A1" />
                                    <f:RadioItem Text="牵引车 A2" Value="A2" />
                                    <f:RadioItem Text="城市公交车 A3" Value="A3" />
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow14" runat="server" Hidden="true">
                            <Items>
                                <f:RadioButtonList ID="RadioButtonList1" runat="server" Label="准驾车型" ColumnNumber="4">
                                    <f:RadioItem Text="普通三轮摩托车" Value="D" />
                                    <f:RadioItem Text="普通二轮摩托车" Value="E" />
                                    <f:RadioItem Text="轻便摩托车" Value="F" />
                                    <f:RadioItem Text="轮式自行机械车" Value="M" />
                                    <f:RadioItem Text="无轨电车" Value="N" />
                                    <f:RadioItem Text="有轨电车" Value="P" />
                                </f:RadioButtonList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow13" runat="server" Hidden="true">
                            <Items>
                                <f:DatePicker ID="LimitDate" runat="server" Label="驾驶证有效期"></f:DatePicker>
                                <f:Label ID="DatePicker1" runat="server" Label=""></f:Label>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow15" runat="server" Hidden="true">
                            <Items>
                                <f:FileUpload runat="server" ID="FileUpload1" Label="驾驶证" Required="false" ButtonIcon="Add">
                                </f:FileUpload>
                                <f:Label ID="Label1" runat="server" Label=""></f:Label>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow16" runat="server" Hidden="true">
                            <Items>
                                <f:FileUpload runat="server" ID="FileUpload2" Label="行驶证" Required="false" ButtonIcon="Add">
                                </f:FileUpload>
                                <f:Label ID="Label2" runat="server" Label=""></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>

                </f:Form>
                <f:Button ID="Button5" IconFont="_Save" Text="保存" ValidateForms="SimpleForm1" runat="server" OnClick="btnSubmit_Click" />
            </Items>
        </f:Window>
    </form>
</body>
</html>
