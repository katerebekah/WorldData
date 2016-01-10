var app = angular.module('worldData', ['googlechart']);
var webaddress = 'http://localhost:61643'

app.controller('profileCtrl', function ($scope, $http) {
    $scope.chartExists = true;

    $scope.chartObject = {};
    
    $scope.chartObject.type = "BarChart";
    $scope.chartObject.data = {
        "cols": [
            { id: "t", label: "City", type: "string" },
            { id: "s", label: "Population", type: "number" }
        ], "rows": []
 
    };

    $scope.chartObject.options = {
        title: "City Populations"
    }

    $scope.GetChart = function () {
        $http.get("http://localhost:61643/api/ChartItem/?chartId=" + chartId)
            .then(function (response) {
                console.log(response);
                if (response.data.length == 0) { $scope.chartExists = false; }
                for (var i = 0; i < response.data.length; i++) {
                    $scope.GetApiResult(response.data[i]);
                }
            },
            function (error) { console.log(error) });
    }
    $scope.GetChart();
    $scope.Chart = [];
    $scope.GetApiResult = function (city) {
        $http.get($scope.baseApiAddress + city.ApiURL + ".json?api_key=mWbezmtRyiryCF8GP5sN")
            .then(function (response) {
                var res = response.data.dataset.data[0];
                var chartDatum = {
                    c: [
                        { v: city.Name },
                        { v: res[1] }
                    ]
                };
                var chartBackupDatum = {
                    Name: city.Name,
                    CityId: city.CityId
                }
                $scope.chartObject.data.rows.push(chartDatum);
                $scope.chart.push(chartBackupDatum);
                return;
            }, function (error) { console.log("error: " + error) });
    }

    $scope.baseApiAddress = "https://www.quandl.com/api/v3/datasets/";

    $scope.chartId = chartId;
    $scope.chart = [];
    $scope.CreateChart = function () { }
    $scope.GoBack = function () { $scope.Step = $scope.Step - 1; }
    $scope.BackToChart = function () { $scope.Step = 1; }
    $scope.Step = 1;
    $scope.Countries;
    $scope.Cities;
    $scope.GetCountries = function () {
        $scope.Step = 2;
        $http.get('http://localhost:61643/api/City/GetCountries').success(function (response) {
            $scope.Countries = response;
            $scope.Countries.sort(function compareNumbers(a, b) {
                return a.Name.localeCompare(b.Name);
            });
        }).error(function(e){
            console.log("error: " +e);
        });
    }

    $scope.GetCitiesinCountry = function (id) {
        $scope.Step = 3;
        $http.get('http://localhost:61643/api/City/GetCitiesInCountry/?cityId=' + id).success(function (response) {
            $scope.Cities = response;
            $scope.Cities.sort(function compareNumbers(a, b) {
                return a.Name.localeCompare(b.Name);
            });
        }).error(function (e) {
            console.log("error: " + e);
        });
    }

    $scope.AddCityToChart = function (city) {
        $scope.Step = 1;
        $scope.AddCityToChartDB(city.CityId);
        $scope.GetApiResult(city);
        $scope.chartExists = true;
    }

    $scope.AddCityToChartDB = function (cityId) {
        $http.post("http://localhost:61643/api/Chart/Add/?chartid=" + chartId + "&cityId=" + cityId)
            .then(function (response) {},
            function (error) { console.log(error) });
    }

    $scope.Remove = function (cityId, position) {
        $http.delete("http://localhost:61643/api/Chart?chartId=" + chartId + "&itemId=" + cityId)
            .then(function (response) { $scope.chartObject.data.rows.splice(position, 1); $scope.chart.splice(position, 1); $scope.Step = 1; },
            function (error) { console.log("error: " + error )});
    };
    $scope.MoveUp = function (cityId, position) {
        if (position != 0) {
            $scope.Move(cityId, position - 1);
        
        var temp = $scope.chartObject.data.rows[position - 1]
        $scope.chartObject.data.rows.splice(position-1, 1);
        $scope.chartObject.data.rows.splice(position, 0, temp);


        var temp3 = $scope.chart[position - 1]
        $scope.chart.splice(position - 1, 1);
        $scope.chart.splice(position, 0, temp3);
        }
    }
    $scope.MoveDown = function (cityId, position) {
        if (position < $scope.chartObject.data.rows.length - 1) {
            $scope.Move(cityId, position + 1);
        
        var temp = $scope.chartObject.data.rows[position];
        $scope.chartObject.data.rows.splice(position, 1);
        $scope.chartObject.data.rows.splice(position + 1, 0, temp);

        var temp2 = $scope.chart[position]
        $scope.chart.splice(position, 1);
        $scope.chart.splice(position + 1, 0, temp2);
        }
    };

    $scope.Move = function (cityId, newPosition) {
        $http.post("http://localhost:61643/api/Chart/Reorder/?chartId" + chartId + "&cityId=" + cityId + "&newPosition=" + newPosition)
            .then(function (response) {return }, function (error) { console.log("error: " + error)})
    }
});