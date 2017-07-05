app.controller("registerController",
    function ($scope, $http) {

        console.log("Test");

        $scope.getCountries = function () {
            $http({
                method: "GET",
                url: "/admin/Country/Index"
            }).then(function (result) {
                $scope.countries = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.getCitiesByCountryID = function (countryID) {
            $http({
                method: "GET",
                url: "/admin/Country/GetByID",
                params: { id: countryID }
            }).then(function (result) {
                $scope.cities = result.data.Cities;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.getTownsByCityID = function (cityID) {
            $http({
                method: "GET",
                url: "/admin/City/GetByID",
                params: { id: cityID }
            }).then(function (result) {
                $scope.towns = result.data.Towns;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.getCountries();

    });