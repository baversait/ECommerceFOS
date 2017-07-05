app.controller('countryCtrl',
    function ($scope, $http) {

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

        $scope.selectCountry = function (country) {
            $scope.selectedCountry = country;
        };

        $scope.deleteCountry = function (country) {
            $http({
                method: "POST",
                url: "/admin/Country/Delete",
                data: country
            }).then(function (result) {
                $scope.getCountries();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editCountry = function (country) {
            $http({
                method: "POST",
                url: "/admin/Country/Edit",
                data: country
            }).then(function (result) {
                $scope.getCountries();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addCountry = function (country) {
            $http({
                method: "POST",
                url: "/admin/Country/Add",
                data: country
            }).then(function (result) {
                $scope.getCountries();
            }, function (result) {
                console.log(result);
            });
        };
        
        $scope.getCountries();

    });