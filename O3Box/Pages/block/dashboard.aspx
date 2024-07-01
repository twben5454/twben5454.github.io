<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="FineUIPro.Examples.block.dashboard" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
    <meta name="sourcefiles" content="~/res/css/dashboard.css;~/res/js/dashboard_chart.js" />
    <link href="~/res/css/dashboard.css" rel="stylesheet" />
    <link href="~/res/css/index.css" rel="stylesheet" />
</head>
<body class="f-body-bgcolor">
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Panel IsFluid="true" runat="server"
            Layout="Block" BlockConfigSpace="20px" ShowBorder="false" ShowHeader="false">
            <Items>
                <f:ContentPanel CssClass="blockpanel" BlockMD="6" BlockLG="3"
                    runat="server" ShowBorder="true" ShowHeader="false">
                    <div class="mycard">
                        <div class="title">
                            今日浏览量
                            <i class="f-icon f-iconfont f-iconfont-info infoicon"></i>
                        </div>
                        <div class="number">
                            12,000
                        </div>
                        <div class="chart chart1">
                        </div>
                        <div class="footer f-widget-content">
                            日均浏览量 15,000
                        </div>
                    </div>
                    <div class="mycard" style="display: none;">
                        <div class="title">
                            今日浏览量
                            <i class="f-icon f-iconfont f-iconfont-info infoicon"></i>
                        </div>
                        <div class="desc">
                            今日浏览量的详细描述。
                            <br />
                            FineUI 是基于 jQuery 的专业 ASP.NET WebForms/MVC/Core 控件库。
                        </div>
                    </div>
                </f:ContentPanel>
                <f:ContentPanel CssClass="blockpanel" BlockMD="6" BlockLG="3"
                    runat="server" ShowBorder="true" ShowHeader="false">
                    <div class="mycard">
                        <div class="title">
                            今日独立IP
                            <i class="f-icon f-iconfont f-iconfont-info infoicon"></i>
                        </div>
                        <div class="number">
                            800
                        </div>
                        <div class="chart chart2">
                        </div>
                        <div class="footer f-widget-content">
                            日均独立IP 900
                        </div>
                    </div>
                    <div class="mycard" style="display: none;">
                        <div class="title">
                            今日独立IP
                            <i class="f-icon f-iconfont f-iconfont-info infoicon"></i>
                        </div>
                        <div class="desc">
                            今日独立IP的详细描述。
                            <br />
                            FineUI 是基于 jQuery 的专业 ASP.NET WebForms/MVC/Core 控件库。
                        </div>
                    </div>
                </f:ContentPanel>
                <f:ContentPanel CssClass="blockpanel" BlockMD="6" BlockLG="3"
                    runat="server" ShowBorder="true" ShowHeader="false">
                    <div class="mycard">
                        <div class="title">
                            今日用户量
                            <i class="f-icon f-iconfont f-iconfont-info infoicon"></i>
                        </div>
                        <div class="number">
                            900
                        </div>
                        <div class="chart chart3">
                        </div>
                        <div class="footer f-widget-content">
                            周同比 10% <i class="f-icon f-iconfont f-iconfont-triangle-down"></i>
                            &nbsp;
                            日环比 20% <i class="f-icon f-iconfont f-iconfont-triangle-up"></i>
                        </div>
                    </div>
                    <div class="mycard" style="display: none;">
                        <div class="title">
                            今日用户量
                            <i class="f-icon f-iconfont f-iconfont-info infoicon"></i>
                        </div>
                        <div class="desc">
                            今日用户量的详细描述。
                            <br />
                            FineUI 是基于 jQuery 的专业 ASP.NET WebForms/MVC/Core 控件库。
                        </div>
                    </div>
                </f:ContentPanel>
                <f:ContentPanel CssClass="blockpanel" BlockMD="6" BlockLG="3"
                    runat="server" ShowBorder="true" ShowHeader="false">
                    <div class="mycard rank">
                        <div class="title">
                            今日排名
                            <i class="f-icon f-iconfont f-iconfont-info infoicon"></i>
                        </div>
                        <div class="number">
                            <span class="number-subtext">上升</span> 9 <span class="number-subtext">位</span>
                        </div>
                        <div class="chart">
                            <div class="f-progressbar f-widget-content">
                                <div class="f-progressbar-value f-widget-header" style="width: 70%;">
                                </div>
                            </div>
                        </div>
                        <div class="footer f-widget-content">
                            分类排名前 32% <i class="f-icon f-iconfont f-iconfont-triangle-up"></i>
                        </div>
                    </div>
                    <div class="mycard" style="display: none;">
                        <div class="title">
                            今日排名
                            <i class="f-icon f-iconfont f-iconfont-info infoicon"></i>
                        </div>
                        <div class="desc">
                            今日排名的详细描述。
                            <br />
                            FineUI 是基于 jQuery 的专业 ASP.NET WebForms/MVC/Core 控件库。
                        </div>
                    </div>
                </f:ContentPanel>
                <f:TabStrip CssClass="blockpanel mytabstrip" BlockMD="12" ShowInkBar="true"
                    runat="server" ShowBorder="true" ActiveTabIndex="0">
                    <Tabs>
                        <f:Tab runat="server" Layout="Block" BlockConfigSpace="0" Title="浏览量">
                            <Items>
                                <f:ContentPanel BlockMD="6" BlockLG="8"
                                    runat="server" ShowBorder="false" ShowHeader="false">
                                    <div class="tabstrip-chart chart1">
                                    </div>
                                </f:ContentPanel>
                                <f:ContentPanel BlockMD="6" BlockLG="4" BodyPadding="20px"
                                    runat="server" ShowBorder="false" ShowHeader="false">
                                    <table class="mytable">
                                        <thead>
                                            <tr>
                                                <th></th>
                                                <th>Operator</th>
                                                <th>PV</th>
                                                <th>UV</th>
                                                <th>IP</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><span class="mynumber round f-widget-header">1</span></td>
                                                <td>电信</td>
                                                <td>12,000</td>
                                                <td>9,000</td>
                                                <td>6,000</td>
                                            </tr>
                                            <tr>
                                                <td><span class="mynumber round f-widget-header">2</span></td>
                                                <td>联通</td>
                                                <td>10,000</td>
                                                <td>8,000</td>
                                                <td>5,000</td>
                                            </tr>
                                            <tr>
                                                <td><span class="mynumber round f-widget-header">3</span></td>
                                                <td>移动</td>
                                                <td>9,000</td>
                                                <td>6,000</td>
                                                <td>4,000</td>
                                            </tr>
                                            <tr>
                                                <td><span class="mynumber">4</span></td>
                                                <td>长宽</td>
                                                <td>6,000</td>
                                                <td>5,000</td>
                                                <td>3,000</td>
                                            </tr>
                                            <tr>
                                                <td><span class="mynumber">5</span></td>
                                                <td>铁通</td>
                                                <td>4,000</td>
                                                <td>3,000</td>
                                                <td>2,000</td>
                                            </tr>
                                            <tr>
                                                <td><span class="mynumber">6</span></td>
                                                <td>其它</td>
                                                <td>8,000</td>
                                                <td>5,000</td>
                                                <td>2,000</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </f:ContentPanel>
                            </Items>
                        </f:Tab>
                        <f:Tab runat="server" Layout="Block" BlockConfigSpace="0" Title="用户量">
                            <Items>
                                <f:ContentPanel BlockMD="6" BlockLG="8"
                                    runat="server" ShowBorder="false" ShowHeader="false">
                                    <div class="tabstrip-chart chart2">
                                    </div>
                                </f:ContentPanel>
                                <f:ContentPanel BlockMD="6" BlockLG="4" BodyPadding="20px"
                                    runat="server" ShowBorder="false" ShowHeader="false">
                                    <table class="mytable">
                                        <thead>
                                            <tr>
                                                <th></th>
                                                <th>Browser</th>
                                                <th>PV</th>
                                                <th>UV</th>
                                                <th>IP</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1</td>
                                                <td>Chrome</td>
                                                <td>12,600</td>
                                                <td>9,600</td>
                                                <td>6,600</td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                                <td>Firefox</td>
                                                <td>10,600</td>
                                                <td>8,600</td>
                                                <td>5,600</td>
                                            </tr>
                                            <tr>
                                                <td>3</td>
                                                <td>Safari</td>
                                                <td>9,600</td>
                                                <td>6,600</td>
                                                <td>4,600</td>
                                            </tr>
                                            <tr>
                                                <td>4</td>
                                                <td>IE</td>
                                                <td>6,600</td>
                                                <td>5,600</td>
                                                <td>3,600</td>
                                            </tr>
                                            <tr>
                                                <td>5</td>
                                                <td>Edge</td>
                                                <td>4,600</td>
                                                <td>3,600</td>
                                                <td>2,600</td>
                                            </tr>
                                            <tr>
                                                <td>6</td>
                                                <td>Others</td>
                                                <td>8,600</td>
                                                <td>5,600</td>
                                                <td>2,600</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </f:ContentPanel>
                            </Items>
                        </f:Tab>
                    </Tabs>
                    <Tools>
                        <f:Tool runat="server" ToolTip="打开详细数据" IconFont="_More">
                            <Listeners>
                                <f:Listener Event="click" Handler="onTabstripToolClick" />
                            </Listeners>
                        </f:Tool>
                    </Tools>
                </f:TabStrip>
                <f:Panel BlockMD="6" BlockLG="8" Layout="Block" BlockConfigSpace="20px"
                    runat="server" ShowBorder="false" ShowHeader="false">
                    <Items>
                        <f:Grid ID="Grid1" CssClass="blockpanel mygrid" BlockMD="12"
                            ShowBorder="true" ShowHeader="true" Title="表格示例"
                            EnableCheckBoxSelect="true" EnableAlternateRowColor="false" EnableRowLines="false"
                            runat="server" DataIDField="Id">
                            <Columns>
                                <f:RowNumberField></f:RowNumberField>
                                <f:RenderField Width="100px" ColumnID="Name" DataField="Name" HeaderText="姓名">
                                </f:RenderField>
                                <f:RenderCheckField Width="100px" ColumnID="AtSchool" DataField="AtSchool" RenderAsStaticField="true" HeaderText="是否在校" />
                                <f:RenderField ColumnID="Major" DataField="Major" RendererFunction="renderMajor"
                                    ExpandUnusedSpace="true" MinWidth="150px" HeaderText="所学专业">
                                </f:RenderField>
                            </Columns>
                        </f:Grid>
                        <f:Form CssClass="blockpanel myform" BlockMD="12" Layout="Block" BlockConfigSpace="10px" BodyPadding="20px"
                            runat="server" ShowBorder="true" ShowHeader="true" Title="表单示例" LabelAlign="Right">
                            <Items>
                                <f:Label ID="Label1" BlockMD="6" runat="server" Label="标签" Text="标签的值">
                                </f:Label>
                                <f:CheckBox ID="CheckBox1" BlockMD="6" runat="server" Text="复选框" Label="复选框">
                                </f:CheckBox>
                                <f:DropDownList ID="DropDownList1" BlockMD="6" runat="server" Required="true" ShowRedStar="true" AutoSelectFirstItem="false" Label="下拉列表">
                                    <f:ListItem Text="可选项 1" Selected="true" Value="0"></f:ListItem>
                                    <f:ListItem Text="可选项 2" Value="2"></f:ListItem>
                                    <f:ListItem Text="可选项 3" Value="3"></f:ListItem>
                                </f:DropDownList>
                                <f:TextBox ID="TextBox1" BlockMD="6" ShowRedStar="true" runat="server" Label="文本框" Required="true"
                                    Text="">
                                </f:TextBox>
                                <f:DatePicker runat="server" BlockMD="6" EnableEdit="false" Required="true" Label="日期" EmptyText="请选择日期"
                                    ID="DatePicker1" SelectedDate="2014-07-10" ShowRedStar="true">
                                </f:DatePicker>
                                <f:TimePicker ID="TimePicker1" BlockMD="6" EnableEdit="false" ShowRedStar="true" Label="时间" Increment="30"
                                    Required="true" Text="08:30" EmptyText="请选择时间" runat="server">
                                </f:TimePicker>
                                <f:CheckBoxList ID="CheckBoxList1" BlockMD="12" Label="复选框列表" ColumnNumber="3" runat="server">
                                    <f:CheckItem Text="可选项 1" Value="value1" />
                                    <f:CheckItem Text="可选项 2" Value="value2" Selected="true" />
                                    <f:CheckItem Text="可选项 3" Value="value3" Selected="true" />
                                    <f:CheckItem Text="可选项 4" Value="value4" Selected="true" />
                                    <f:CheckItem Text="可选项 5" Value="value5" Selected="true" />
                                </f:CheckBoxList>
                                <f:TextArea ID="TextArea1" BlockMD="12" runat="server" Label="描述" ShowRedStar="true" Required="true">
                                </f:TextArea>
                            </Items>
                        </f:Form>
                    </Items>
                </f:Panel>
                <f:Panel BlockMD="6" BlockLG="4" Layout="Block" BlockConfigSpace="20px"
                    runat="server" ShowBorder="false" ShowHeader="false">
                    <Items>
                        <f:ContentPanel CssClass="blockpanel" BlockMD="12" BodyPadding="20px 20px 0 20px"
                            runat="server" ShowBorder="true" ShowHeader="true" Title="本站统计">
                            <ul class="mysitestats">
                            </ul>
                        </f:ContentPanel>
                        <f:ContentPanel CssClass="blockpanel" BlockMD="12" BodyPadding="20px"
                            runat="server" ShowBorder="true" ShowHeader="true" Title="访问来源">
                            <div class="mychart-pie"></div>
                        </f:ContentPanel>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <div class="f-widget-content" id="emptycontent"></div>
    </form>
    <script src="../res/third-party/echarts/echarts.min.js"></script>
    <script src="../res/js/dashboard_chart.js"></script>
    <script>

        function onTabstripToolClick(event) {
            parent.addExampleTab && parent.addExampleTab({
                id: 'dashboard_iframe_grid',
                iframeUrl: F.baseUrl + 'iframe/grid_iframe.aspx',
                title: '表格与编辑窗体',
                refreshWhenExist: true
            });
        }

        function renderMajor(value) {
            return F.formatString('<a href="http://gsa.ustc.edu.cn/search?q={0}" target="_blank" data-qtip="{1}">{1}</a>', encodeURIComponent(value), value);
        }

        F.ready(function () {

            $('.mycard .infoicon').click(function () {
                var card1 = $(this).parents('.mycard');
                var card2 = card1.siblings('.mycard');
                // 翻转动画
                F.flip(card1, card2);
            });


            // 本站统计
            var siteStats = [];
            function addToSiteStats(title, content) {
                siteStats.push('<li class="f-state-default"><div class="title">' + title + '</div><div class="content">' + content + '</div></li>');
            }
            var examplesCount = parent.getExamplesCount ? parent.getExamplesCount() : '---';
            var examplesCountTitle = '示例数';
            var cookieShowOnlyBase = F.cookie('ShowOnlyBase');
            if (cookieShowOnlyBase == 'true') {
                examplesCountTitle += '（仅基础版）';
            }
            addToSiteStats(examplesCountTitle, examplesCount);

            var cookieSearchText = F.cookie('SearchText');
            if (cookieSearchText) {
                addToSiteStats('搜索关键字', cookieSearchText);
            }

            addToSiteStats('显示模式', F.displayMode);
            addToSiteStats('语言', F.language);
            addToSiteStats('主题', F.theme);
            addToSiteStats('版本', F.version);
            $('.mysitestats').html(siteStats.join(''));

        });

    </script>
</body>
</html>
