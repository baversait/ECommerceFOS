app.controller('currencyCtrl',
    function ($scope, $http) {

        $scope.getCurrencies = function () {
            $http({
                method: "GET",
                url: "/admin/Currency/Index"
            }).then(function (result) {
                $scope.currencies = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectCurrency = function (currency) {
            $scope.selectedCurrency = currency;
        };

        $scope.deleteCurrency = function (currency) {
            $http({
                method: "POST",
                url: "/admin/Currency/Delete",
                data: currency
            }).then(function (result) {
                $scope.getCurrencies();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editCurrency = function (currency) {
            $http({
                method: "POST",
                url: "/admin/Currency/Edit",
                data: currency
            }).then(function (result) {
                $scope.getCurrencies();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addCurrency = function (currency) {
            $http({
                method: "POST",
                url: "/admin/Currency/Add",
                data: currency
            }).then(function (result) {
                $scope.getCurrencies();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.parent = {Date: $scope.selectCurrency.Date}

        $scope.getCurrencies();

    });