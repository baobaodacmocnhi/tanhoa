<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tb_BienDongDHN.ascx.cs" Inherits="BaoCao_Web.View.tabBieuDo.tb_BienDongDHN" %>
<html>
  <head>
  <p />
  <p />
  <br />
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["columnchart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = google.visualization.arrayToDataTable([
          ['THÁNG', 'GẮN MỚI', 'HỦY DB', 'TÁI LẬP DB'],<%=Session["biendongdhn"] %>
        ]);

            var options = {              
                hAxis: { title: 'THÁNG', titleTextStyle: { color: 'red'} },
                width: 800, 
                height: 480, 
                is3D: true
            };            
            var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>
  </head>
  <body>
    <div id="chart_div"></div><!-- 'columnchart','piechart' "corechart"-->
  </body>
</html>