app.controller('cityCtrl',
    function ($scope, $http) {

        $scope.getCities = function () {
            $http({
                method: "GET",
                url: "/admin/City/Index"
            }).then(function (result) {
                console.log(result);
                $scope.cities = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectCity = function (city) {
            $scope.selectedCity = city;
            $scope.getCountries();
        };

        $scope.deleteCity = function (city) {
            $http({
                method: "POST",
                url: "/admin/City/Delete",
                data: city
            }).then(function (result) {
                $scope.getCities();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editCity = function (city) {
            $http({
                method: "POST",
                url: "/admin/City/Edit",
                data: city
            }).then(function (result) {
                $scope.getCities();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addCity = function (city) {
            console.log(city);
            $http({
                method: "POST",
                url: "/admin/City/Add",
                data: city
            }).then(function (result) {
                $scope.getCities();
            }, function (result) {
                console.log(result);
            });
        };

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

        $scope.getCities();

    });