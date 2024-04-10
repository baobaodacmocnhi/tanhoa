function getNhanDon(SoNgay) {
    CharHelperNhanDon.LoadChart(SoNgay);
}

var ChartManagerNhanDon = {
    GetChart: function (SoNgay) {
        var objLeaveType = "";
        var jsonParam = { SoNgay: SoNgay };
        var serviceUrl = "../Home/getNhanDon_anycharts";
        ChartManagerNhanDon.GetJsonResult(serviceUrl, jsonParam, false, false, onSuccess, onFailed);
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

var CharHelperNhanDon = {
    LoadChart: function (SoNgay) {
        var data = ChartManagerNhanDon.GetChart(SoNgay);
        anychart.onDocumentReady(function () {
            // set the data
            //var data = [
            //  { x: 'White', value: 223553265 },
            //  { x: 'Black or African American', value: 38929319 },
            //  { x: 'Asian', value: 14674252 },
            //  { x: 'Some Other Race', value: 19107368 }
            //];
            // create the chart
            var chart = anychart.pie();
            // set the chart title
            chart.title('');
            // add the data
            chart.data(data);
            // sort elements
            chart.sort('desc');
            // set legend position
            chart.legend().position('right');
            // set items layout
            chart.legend().itemsLayout('vertical');
            chart.labels().fontSize('15');
            // display the chart in the container
            chart.container('vNhanDon');
            chart.draw();
        });
    }
};

function getNhanDons(TuNgay, DenNgay) {
    CharHelperNhanDons.LoadChart(TuNgay, DenNgay);
};

var ChartManagerNhanDons = {
    GetChart: function (TuNgay, DenNgay) {
        var objLeaveType = "";
        var jsonParam = { TuNgay: TuNgay, DenNgay: DenNgay };
        var serviceUrl = "../Home/getNhanDon_anychartss";
        ChartManagerNhanDons.GetJsonResult(serviceUrl, jsonParam, false, false, onSuccess, onFailed);
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

var CharHelperNhanDons = {
    LoadChart: function (TuNgay, DenNgay) {
        var data = ChartManagerNhanDons.GetChart(TuNgay, DenNgay);
        anychart.onDocumentReady(function () {
            // set the data
            //var data = [
            //  { x: 'White', value: 223553265 },
            //  { x: 'Black or African American', value: 38929319 },
            //  { x: 'Asian', value: 14674252 },
            //  { x: 'Some Other Race', value: 19107368 }
            //];
            // create the chart
            var chart = anychart.pie();
            // set the chart title
            chart.title('');
            // add the data
            chart.data(data);
            // sort elements
            chart.sort('desc');
            // set legend position
            chart.legend().position('right');
            // set items layout
            chart.legend().itemsLayout('vertical');
            chart.labels().fontSize('15');
            // display the chart in the container
            chart.container('vNhanDon');
            chart.draw();
        });
    }
};

