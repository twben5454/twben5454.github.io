<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberTree.aspx.cs" Inherits="Admin_Page_Member_MemberTree" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CatchaFace</title>
    <link href="../../../OrgChart/css/jquery.orgchart.css" rel="stylesheet" />
    <link href="../../../OrgChart/css/style.css" rel="stylesheet" />
    <style>
        #chart-container {
          position: relative;
          display: inline-block;
          top: 10px;
          left: 10px;
          height: 620px;
          width: calc(100% - 24px);
          border: 2px dashed #aaa;
          border-radius: 5px;
          overflow: auto;
          text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:ContentPanel runat="server" ID="ContentPanel1" Title="會員組織圖" ShowHeader="false">
              <div id="chart-container"></div>
        </f:ContentPanel>

    </form>
    <script src="../../../OrgChart/js/jquery.orgchart.js"></script>
    <script src="../../../OrgChart/js/jquery.orgchart.min.js"></script>
    <script type="text/javascript">
    $(function() {

    var datasource = <%=strDataSource%>

    var nodeTemplate = function(data) {
      return `
        <span class="office">${data.office}</span>
        <div class="title">${data.name}</div>
        <div class="content">${data.title}</div>
      `;
    };

    var oc = $('#chart-container').orgchart({
      'data' : datasource,
      'nodeTemplate': nodeTemplate
    });

  });
    </script>
</body>
</html>
