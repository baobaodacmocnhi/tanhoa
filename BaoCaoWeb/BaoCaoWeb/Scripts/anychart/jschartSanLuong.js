function getSanLuongNam_chart(NamPrevious, NamPresent) {
    CharHelperSanLuongNam.LoadChart(NamPrevious, NamPresent);
}

var CharHelperSanLuongNam = {
    LoadChart: function (NamPrevious, NamPresent) {
        var data = ChartManagerSanLuongNam.GetChart(NamPrevious, NamPresent);

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
            chart.yAxis().title('Sản Lượng (m3)');
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
            chart.container('chartSanLuongNam');

            // initiate chart drawing
            chart.draw();
        });
    }
};

var ChartManagerSanLuongNam = {
    GetChart: function (NamPrevious, NamPresent) {
        var objLeaveType = "";
        var jsonParam = { NamPrevious: NamPrevious, NamPresent: NamPresent };
        var serviceUrl = "../Home/getSanLuongNam_anycharts";
        ChartManagerSanLuongNam.GetJsonResult(serviceUrl, jsonParam, false, false, onSuccess, onFailed);
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

///

function getSanLuongChuanThu_chart(NamPresent) {
    CharHelperSanLuongChuanThu.LoadChart(NamPresent);
}

var CharHelperSanLuongChuanThu = {
    LoadChart: function (NamPresent) {
        var data = ChartManagerSanLuongChuanThu.GetChart(NamPresent);

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
            chart.yAxis().title('Sản Lượng (m3)');
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
            chart.container('chartSanLuongChuanThu');

            // initiate chart drawing
            chart.draw();
        });
    }
};

var ChartManagerSanLuongChuanThu = {
    GetChart: function (NamPresent) {
        var objLeaveType = "";
        var jsonParam = { NamPresent: NamPresent };
        var serviceUrl = "../Home/getSanLuongChuanThu_anycharts";
        ChartManagerSanLuongChuanThu.GetJsonResult(serviceUrl, jsonParam, false, false, onSuccess, onFailed);
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