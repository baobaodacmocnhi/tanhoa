function getGiaBanBinhQuan() {
    CharHelperGiaBanBinhQuan.LoadChart();
}

var ChartManagerGiaBanBinhQuan = {
    GetChart: function () {
        var objLeaveType = "";
        var jsonParam = "";
        var serviceUrl = "../Home/getGiaBanBinhQuan";
        ChartManagerGiaBanBinhQuan.GetJsonResult(serviceUrl, jsonParam, false, false, onSuccess, onFailed);
        function onSuccess(jsonData) {
            objLeaveType = jsonData;
        }
        function onFailed(error) {
            alert(error.statusText);
        }
        return objLeaveType;
    }, GetJsonResult(serviceUrl, jsonParam, isAsync, isCache, successCallback, errorCallback) {
        $.ajax({
            type: "GET",
            async: isAsync,
            cache: isCache,
            url: serviceUrl,
            data: jsonParam,
            contentType: "application/json; chartset=utf-8",
            success: successCallback,
            error: errorCallback
        });
    }
};

var CharHelperGiaBanBinhQuan = {
    LoadChart: function () {
        var data = ChartManagerGiaBanBinhQuan.GetChart();

        am4core.ready(function () {

            // Themes begin

            am4core.useTheme(am4themes_animated);
            // Themes end

            var chart = am4core.create('chartGiaBanBinhQuan', am4charts.XYChart);
            chart.colors.step = 9;

            // Create Legend
            chart.legend = new am4charts.Legend();

            // Create x
            var xAxis = chart.xAxes.push(new am4charts.CategoryAxis());
            xAxis.dataFields.category = 'Ky';

            // Format position of Column
            xAxis.renderer.cellStartLocation = 0.1;
            xAxis.renderer.cellEndLocation = 0.9;
            xAxis.renderer.minGridDistance = 20;
            xAxis.renderer.grid.template.location = 0;

            // Create y
            var yAxis = chart.yAxes.push(new am4charts.ValueAxis());
            yAxis.min = 0;
            yAxis.title.text = 'Giá Bán Bình Quân (vnđ)';

            function createSeries(value, name) {
                var series = chart.series.push(new am4charts.ColumnSeries());
                series.dataFields.valueY = value;
                series.dataFields.categoryX = 'Ky';
                series.name = name;
                series.tooltipText = '{name}: [bold]{valueY}[/]';

                return series;
            }
            chart.data = data;

            createSeries("NamPrevious", "Năm " + (new Date().getFullYear() - 1));
            createSeries("NamPresent", "Năm " + new Date().getFullYear());
            chart.cursor = new am4charts.XYCursor();

        }); // end am4core.ready()
    }
};
