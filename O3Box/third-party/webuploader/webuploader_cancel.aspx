<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webuploader_cancel.aspx.cs" Inherits="FineUIPro.Examples.thirdparty.webuploader_cancel" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=DB.getObject().WebSiteName%></title>
    <meta name="sourcefiles" content="~/third-party/webuploader/fileupload.ashx" />
    <style>
        
        .webuploader-element-invisible {
            position: absolute !important;
            clip: rect(1px,1px,1px,1px);
        }

        .webuploader-pick-disable {
            opacity: 0.6;
            pointer-events: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Grid ID="Grid1" IsFluid="true" CssClass="blockpanel" runat="server" ShowHeader="true" ShowBorder="true" Title="文件上传（上传过程中可以取消上传）"
            Height="350px"
            EnableCollapse="false" EnableCheckBoxSelect="false" EmptyText="尚未上传文件"
            DataIDField="id" OnRowCommand="Grid1_RowCommand">
            <Toolbars>
                <f:Toolbar runat="server">
                    <Items>
                        <f:Button ID="btnSelectFiles" Text="选择文件上传" IconFont="_Plus" runat="server" EnablePostBack="false">
                        </f:Button>
                        <f:ToolbarSeparator runat="server"></f:ToolbarSeparator>
                        <f:Button ID="btnDelete" Text="删除选中文件" IconFont="_Close" runat="server" OnClick="btnDelete_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField ColumnID="FileName" DataField="name" HeaderText="文件名" ExpandUnusedSpace="true" MinWidth="150px" />
                <f:BoundField ColumnID="FileType" DataField="type" HeaderText="类型" Width="100px" />
                <f:RenderField ColumnID="FileSize" DataField="size" HeaderText="大小" Renderer="FileSize" Width="100px" />
                <f:BoundField ColumnID='FileStatus' DataField="status" NullDisplayText="已完成" HeaderText="状态" Width="100px" />
                <f:LinkButtonField ColumnID='FileDelete' Width="100px" ConfirmText="你确定要删除这个文件吗？" ConfirmTarget="Top"
                    CommandName="Delete" IconUrl="~/res/icon/delete.png" />
            </Columns>
        </f:Grid>
        <br />
        <br />
        注：由于第三方组件WebUploader限制，本示例支持的浏览器版本为：Chrome、Firefox、Safari、IE10+ 。
    </form>
    <script src="../../res/third-party/webuploader/webuploader.nolog.js" type="text/javascript"></script>
    <script type="text/javascript">
        var btnDeleteClientID = '<%= btnDelete.ClientID %>';
        var btnSelectFilesClientID = '<%= btnSelectFiles.ClientID %>';
        var gridClientID = '<%= Grid1.ClientID %>';

        var BASE_URL = '<%= PageContext.ResolveUrl("~/") %>';
        var SERVER_URL = BASE_URL + 'third-party/webuploader/fileupload.ashx';

        F.ready(function () {
            var grid1 = F(gridClientID);

            var uploader = WebUploader.create({

                // swf文件路径
                swf: BASE_URL + 'res/third-party/webuploader/Uploader.swf',

                // 文件接收服务端。
                server: SERVER_URL,

                // 选择文件的按钮。可选。
                // 内部根据当前运行是创建，可能是input元素，也可能是flash.
                pick: '#' + btnSelectFilesClientID,

                // 不压缩image, 默认如果是jpeg，文件上传前会压缩一把再上传！
                resize: false,

                // 自动上传
                auto: true,

                // 文件上传参数表，用来标记文件的所有者（如果是一篇文章的附件，就是文章的ID）
                formData: {
                    owner: 'webuploader.webuploader_cancel'
                },

                // 单个文件大小限制（单位：byte），这里限制为 10M
                fileSingleSizeLimit: 10 * 1024 * 1024

            });

            //// 添加到上传队列
            //uploader.on('fileQueued', function (file) {
            //    grid1.addNewRecord(file.id, {
            //        'FileName': file.name,
            //        'FileType': file.ext,
            //        'FileSize': file.size,
            //        'FileStatus': '等待上传',
            //        'FileDelete': '<a href="javascript:;" class="thecanceluploadbutton">取消上传</a>'
            //    }, true);
            //});

            // 当一批文件添加进队列以后触发
            uploader.on('filesQueued', function (files) {
                var records = [];
                $.each(files, function (index, file) {
                    records.push({
                        id: file.id,
                        values: {
                            'FileName': file.name,
                            'FileType': file.ext,
                            'FileSize': file.size,
                            'FileStatus': '等待上传',
                            'FileDelete': '<a href="javascript:;" class="thecanceluploadbutton">取消上传</a>'
                        }
                    });
                });
                grid1.addNewRecords(records, true);
            });

            uploader.on('uploadProgress', function (file, percentage) {
                var cellEl = grid1.getCellEl(file.id, 'FileStatus').find('.f-grid-cell-inner');
                
                var barEl = cellEl.find('.f-progressbar-value');

                // 避免重复创建
                if (!barEl.length) {
                    cellEl.html('<div class="f-progressbar f-widget-content" style="height:12px;">' +
                      '<div class="f-progressbar-value f-widget-header" style="width:0%">' +
                      '</div></div>');
                    barEl = cellEl.find('.f-progressbar-value');
                }

                barEl.css('width', percentage * 100 + '%');
            });

            uploader.on('uploadSuccess', function (file) {
                var cellEl = grid1.getCellEl(file.id, 'FileStatus').find('.f-grid-cell-inner');
                cellEl.text('上传成功');
            });

            uploader.on('uploadError', function (file) {
                var cellEl = grid1.getCellEl(file.id, 'FileStatus').find('.f-grid-cell-inner');
                cellEl.text('上传出错');
            });

            // 不管上传成功还是失败，都会触发 uploadComplete 事件
            uploader.on('uploadComplete', function (file) {
                uploader.removeFile(file, true);

                // 上传结束，删除 [取消上传] 按钮
                var cellEl = grid1.getCellEl(file.id, 'FileDelete').find('.f-grid-cell-inner');
                cellEl.text('');
            });

            // 当开始上传流程时触发
            uploader.on('startUpload', function () {
                // 禁用删除按钮
                F(btnDeleteClientID).disable();
            });

            // 当所有文件上传结束时触发
            uploader.on('uploadFinished', function () {
                // 启用删除按钮
                F(btnDeleteClientID).enable();

                // 回发页面，重新绑定表格数据
                __doPostBack('', 'RebindGrid');
            });


            uploader.on('error', function (type, arg, file) {
                if (type === 'F_EXCEED_SIZE') {
                    F.alert('文件[' + file.name + ']大小超出限制值（' + F.format.fileSize(arg) + '）');
                }
            });



            // 表格中的 取消上传 按钮
            grid1.el.on('click', 'a.thecanceluploadbutton', function (event) {
                var targetEl = $(this);
                var rowEl = targetEl.parents('.f-grid-row');
                var rowData = grid1.getRowData(rowEl);

                // 表格的 rowId 就是上传文件对象的id，取消上传并删除当前行
                uploader.cancelFile(rowData.id);
                grid1.deleteRow(rowData.id);
            });



            

        });
    </script>
</body>
</html>
