<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CharDMA.aspx.cs" Inherits="BaoCao_Web.View.tabSanLuong.CharDMA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BIỂU ĐỒ SẢN LƯỢNG</title>
        <script type="text/javascript" src="https://www.google.com/jsapi"></script><!-- linechart "corechart",-->
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["linechart" ] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
        
            var data = google.visualization.arrayToDataTable([
         <%=Session["sldma"] %>
        ]);

            var options = {
                title: 'ĐVT:  m3',
                 width: 1520,
                 height: 680
            };

            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="chart_div" style="width: 1520px; height: 680px;"></div>
    </form>
</body>
</html>
