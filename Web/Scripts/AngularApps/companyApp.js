app.controller('companyCtrl',
    function ($scope, $http) {

        $scope.getCompanies = function () {
            $http({
                method: "GET",
                url: "/admin/Company/Index"
            }).then(function (result) {
                $scope.companies = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectCompany = function (company) {
            $scope.selectedCompany = company;
            $scope.getCountries();
        };

        $scope.deleteCompany = function (company) {
            $http({
                method: "POST",
                url: "/admin/Company/Delete",
                data: company
            }).then(function (result) {
                $scope.getCompanies();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editCompany = function (company) {
            $http({
                method: "POST",
                url: "/admin/Company/Edit",
                data: company
            }).then(function (result) {
                $scope.getCompanies();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addCompany = function (company) {
            $http({
                method: "POST",
                url: "/admin/Company/Add",
                data: company
            }).then(function (result) {
                $scope.getCompanies();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.getCountries = function () {
            $http({
                method: "GET",
                url: "/admin/Country/Index"
            }).then(function (result) {
                console.log(result);
                $scope.countries = result.data;
            }, function (result) {
                console.log(result);
            });
            $scope.getCitiesByCountryID($scope.selectedCompany.Address.CountryID);
            $scope.getTownsByCityID($scope.selectedCompany.Address.CityID);
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
        

        $scope.getCompanies();

    });