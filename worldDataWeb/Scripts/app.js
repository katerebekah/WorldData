var app = angular.module('worldData', []);
var webaddress = 'http://localhost:61643'
app.controller('profileCtrl', function ($scope, $http) {
    $scope.chart = {
        chartId: chartId,
        cities: []
    }
    $scope.Countries;
    $scope.Cities;
    $scope.GetCountries = function () {
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
    }
});