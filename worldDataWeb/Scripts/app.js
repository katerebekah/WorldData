var app = angular.module('worldData', []);
var webaddress = 'http://localhost:61643'
app.controller('profileCtrl', function ($scope, $http) {
    $scope.baseApiAddress = "https://www.quandl.com/data/";
    $scope.apiKey = "&api_key=mWbezmtRyiryCF8GP5sN";
    $scope.chart = {
        chartId: chartId,
        cities: [],
        data: []
    }
    $scope.CreateChart = function () { }
    $scope.GoBack = function () { $scope.Step = $scope.Step - 1;}
    $scope.Step = 1;
    $scope.Countries;
    $scope.Cities;
    $scope.GetCountries = function () {
        $scope.Step = 2;
        console.log("firing");
        $http.get('http://localhost:61643/api/City/GetCountries').success(function (response) {
            $scope.Countries = response;
            $scope.Countries.sort(function compareNumbers(a, b) {
                return a.Name.localeCompare(b.Name);
            });
        }).error(function(e){
            console.log(e);
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
            console.log(e);
        });
    }
    $scope.AddCityToChart = function (city) {
        console.log(city);
        $scope.chart.cities.push(city);
        $scope.Step = 1;
        $http.get($scope.baseApiAddress + city.ApiURL + $scope.apiKey)
            .then(function (response) { console.log(response) })
            .then(function (error) { console.log(error) });
    }
});