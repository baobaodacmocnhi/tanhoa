function getDoanhThu() {
    CharHelperDoanhThu.LoadChart();
}

var ChartManagerDoanhThu = {
    GetChart: function () {
        var objLeaveType = "";
        var jsonParam = "";
        var serviceUrl = "../Home/getDoanhThu_anycharts";
        ChartManagerDoanhThu.GetJsonResult(serviceUrl, jsonParam, false, false, onSuccess, onFailed);
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

var CharHelperDoanhThu = {
    LoadChart: function () {
        var data = ChartManagerDoanhThu.GetChart();

        anychart.onDocumentReady(function () {
            // create data set on our data
            //var chartData = {
            //    title:'',
            //    header: ['#', new Date().getFullYear()-1, new Date().getFullYear()],
            //    rows: [
            //      ['1', 6814, 3054],
            //      ['2', 7012, 5067],
            //      ['3', 8814, 9054]
            //    ]
            //};

            // create column chart
            var chart = anychart.column3d();

            // set chart data
            chart.data(data);
            
            // get series
            var series = chart.getSeriesAt(0);
            series.fill("#1E90FF");
            series.name(new Date().getFullYear() - 1);
            var series = chart.getSeriesAt(1);
            series.fill("#FFD700");
            series.name(new Date().getFullYear());

            // turn on chart animation
            chart.animation(true);

            // set axes settings
            chart.yAxis().title('Doanh Thu (vnđ)');
            chart.yAxis().labels().format('{%Value}{groupsSeparator: }');

            // set labels settings
            chart
              .labels()
              .enabled(true)
              .fontColor('#60727b')
              .position('center')
              .anchor('center')
              .format('{%Value}{groupsSeparator: }').rotation(-90);
            chart.hovered().labels(false);

            // turn on legend
            chart.legend().enabled(true).fontSize(13).padding([0, 0, 20, 0]);

            // set interactivity settings
            chart.interactivity().hoverMode('single');

            // set tooltip settings
            chart
              .tooltip()
              .positionMode('point')
              .position('center-top')
              .anchor('center-bottom')
              .offsetX(0)
              .offsetY(5)
              .format('{%SeriesName}: {%Value}{groupsSeparator: }');

            // set container id for the chart
            chart.container('chartDoanhThu');

            // initiate chart drawing
            chart.draw();
        });
    }
};
