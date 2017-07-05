app.controller('orderCtrl',
    function ($scope, $http) {

        $scope.getOrders = function () {
            $http({
                method: "POST",
                url: "/admin/Order/Index"
            }).then(function (result) {
                $scope.orders = result.data;
            }, function (result) {
                console.log(result);
            });
        }

        $scope.updateShippedStatus = function (order) {
            $http({
                method: "POST",
                url: "/admin/Order/UpdateShippedStatus",
                data: order
            }).then(function (result) {
                $scope.getOrders();
            }, function (result) {
                console.log(result);
            });
        }

        $scope.selectOrder = function (order) {
            $scope.selectedOrder = order;
        }

        $scope.getOrders();
    })