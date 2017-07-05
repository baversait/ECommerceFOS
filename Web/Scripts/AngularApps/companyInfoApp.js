app.controller('companyInfoCtrl',
    function ($scope, $http) {

        $scope.getCompanyInfos = function () {
            $http({
                method: "GET",
                url: "/admin/CompanyInfo/Index"
            }).then(function (result) {
                console.log(result);
                $scope.companyInfos = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectCompanyInfo = function (companyInfo) {
            $scope.selectedCompanyInfo = companyInfo;
            $scope.getCountries();
        };

        $scope.deleteCompanyInfo = function (companyInfo) {
            $http({
                method: "POST",
                url: "/admin/CompanyInfo/Delete",
                data: companyInfo
            }).then(function (result) {
                $scope.getCompanyInfos();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editCompanyInfo = function (companyInfo) {
            console.log(companyInfo);
            $http({
                method: "POST",
                url: "/admin/CompanyInfo/Edit",
                data: companyInfo
            }).then(function (result) {
                $scope.getCompanyInfos();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addCompanyInfo = function (companyInfo) {
            console.log(companyInfo);
            $http({
                method: "POST",
                url: "/admin/CompanyInfo/Add",
                data: companyInfo
            }).then(function (result) {
                $scope.getCompanyInfos();
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
            $scope.getCitiesByCountryID($scope.selectedCompanyInfo.Address.CountryID);
            $scope.getTownsByCityID($scope.selectedCompanyInfo.Address.CityID);
        };

        $scope.getCitiesByCountryID = function (countryID) {
            $http({
                method: "GET",
                url: "/admin/Country/GetByID",
                params: {id: countryID}
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

        $scope.getCompanyInfos();

    });