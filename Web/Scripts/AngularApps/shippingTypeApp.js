app.controller('shippingTypeCtrl',
    function ($scope, $http) {

        $scope.getShippingTypes = function () {
            $http({
                method: "GET",
                url: "/admin/shippingType/Index"
            }).then(function (result) {
                $scope.shippingTypes = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectShippingType = function (shippingType) {
            $scope.selectedShippingType = shippingType;
        };

        $scope.deleteShippingType = function (shippingType) {
            $http({
                method: "POST",
                url: "/admin/ShippingType/Delete",
                data: shippingType
            }).then(function (result) {
                $scope.getShippingTypes();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editShippingType = function (shippingType) {
            $http({
                method: "POST",
                url: "/admin/ShippingType/Edit",
                data: shippingType
            }).then(function (result) {
                $scope.getShippingTypes();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addShippingType = function (shippingType) {
            $http({
                method: "POST",
                url: "/admin/ShippingType/Add",
                data: shippingType
            }).then(function (result) {
                $scope.getShippingTypes();
            }, function (result) {
                console.log(result);
            });
        };



        $scope.getShippingTypes();

    });