<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tabstrip.aspx.cs" Inherits="FineUIPro.Examples.third_party.echarts.tabstrip" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
    <link rel="stylesheet" href="../../res/third-party/openlayers/ol.css" />
    <style>
        .mycontentpanel .f-panel-body > div {
            width: 100%;
            height: 100%;
        }

        #chart, #olmap {
            height: 100%;
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager2" AutoSizePanelID="TabStrip1" runat="server" />
        <f:TabStrip ID="TabStrip1" CssClass="mytabstrip" ShowInkBar="true" runat="server" ShowBorder="true" ActiveTabIndex="0">
            <Tabs>
                <f:Tab runat="server" Title="统计图" Layout="Fit" BodyPadding="10px">
                    <Items>
                        <f:ContentPanel runat="server" CssClass="mycontentpanel" ShowBorder="false" ShowHeader="false">
                            <div id="chart">
                            </div>
                        </f:ContentPanel>
                    </Items>
                </f:Tab>
                <f:Tab runat="server" Title="地图" Layout="Fit" BodyPadding="10px">
                    <Items>
                        <f:ContentPanel runat="server" CssClass="mycontentpanel" ShowBorder="false" ShowHeader="false">
                            <div id="olmap">
                            </div>
                        </f:ContentPanel>
                    </Items>
                </f:Tab>
            </Tabs>
        </f:TabStrip>
        <div class="f-widget-content" id="emptycontent"></div>
    </form>
    <script src="../../res/third-party/echarts/echarts.min.js"></script>
    <script src="../../res/third-party/openlayers/ol.js"></script>
    <script type="text/javascript">
        var TabStrip1ClientID = '<%= TabStrip1.ClientID %>';

        var myChart;
        var myMap;

        function emptyContentColor() {
            return $('#emptycontent').css('color');
        }
        function randomColors() {
            var colors = ['#c23531', '#2f4554', '#61a0a8', '#d48265', '#91c7ae', '#749f83', '#ca8622', '#bda29a', '#6e7074', '#546570', '#c4ccd3'];
            var randomIndex = Math.random() * colors.length;
            return $.merge(colors.slice(randomIndex), colors.slice(0, randomIndex));
        }

        // 更新选项卡中的图表
        function updateChartInTabStrip() {
            var tabIndex = F(TabStrip1ClientID).getActiveTabIndex();
            if (tabIndex === 0) {
                myChart.resize();
            } else {
                myMap.updateSize();
            }
        }

        F.ready(function () {
            // 初始化ECharts
            var contentColor = emptyContentColor();
            var option = {
                color: randomColors(),
                title: {
                    text: '用户访问来源',
                    subtext: '这是说明文字',
                    x: 'center',
                    textStyle: {
                        color: contentColor
                    }
                },
                tooltip: {
                    trigger: 'item',
                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                },
                legend: {
                    orient: 'vertical',
                    left: 'left',
                    textStyle: {
                        color: contentColor
                    },
                    data: ['直接访问', '邮件营销', '联盟广告', '视频广告', '搜索引擎']
                },
                series: [{
                    name: '访问来源',
                    type: 'pie',
                    radius: '55%',
                    center: ['50%', '60%'],
                    data: [
                        { value: 335, name: '直接访问' },
                        { value: 310, name: '邮件营销' },
                        { value: 234, name: '联盟广告' },
                        { value: 135, name: '视频广告' },
                        { value: 1548, name: '搜索引擎' }
                    ],
                    itemStyle: {
                        emphasis: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                }]
            };
            myChart = echarts.init($('#chart')[0]);
            myChart.setOption(option);

            // 初始化OpenLayers
            myMap = new ol.Map({
                target: 'olmap',
                layers: [
                    new ol.layer.Tile({
                        source: new ol.source.OSM()
                    })
                ],
                view: new ol.View({
                    center: ol.proj.fromLonLat([104.114129, 34.550339]),
                    zoom: 4
                })
            });


            // 选项卡切换或者窗体大小改变时，更新当前选项卡内的图表
            F(TabStrip1ClientID).on('tabchange', function (event, tab) {
                updateChartInTabStrip();
            });
            F.windowResize(function () {
                updateChartInTabStrip();
            });

        });


    </script>
</body>
</html>
