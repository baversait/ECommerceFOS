app.controller('brandCtrl',
    function ($scope, $http) {

        $scope.newBrand = {};
        $scope.newBrand.Images = [];

        $scope.getBrands = function () {
            $http({
                method: "GET",
                url: "/admin/Brand/Index"
            }).then(function (result) {
                $scope.brands = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectBrand = function (brand) {
            $scope.selectedBrand = brand;
            $scope.getCountries();
        };

        $scope.deleteBrand = function (brand) {
            $http({
                method: "POST",
                url: "/admin/Brand/Delete",
                data: brand
            }).then(function (result) {
                $scope.getBrands();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editBrand = function (brand) {
            $http({
                method: "POST",
                url: "/admin/Brand/Edit",
                data: brand
            }).then(function (result) {
                $scope.getBrands();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addBrand = function (brand) {
            $http({
                method: "POST",
                url: "/admin/Brand/Add",
                data: brand
            }).then(function (result) {
                $scope.getBrands();
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
            $scope.getCitiesByCountryID($scope.selectedBrand.Address.CountryID);
            $scope.getTownsByCityID($scope.selectedBrand.Address.CityID);
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
            console.log(cityID);
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

        $scope.getBrands();

    });