app.controller('colorCtrl',
    function ($scope, $http) {

        $scope.getColors = function () {
            $http({
                method: "GET",
                url: "/admin/Color/Index"
            }).then(function (result) {
                $scope.colors = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectColor = function (color) {
            $scope.selectedColor = color;
        };

        $scope.deleteColor = function (color) {
            $http({
                method: "POST",
                url: "/admin/Color/Delete",
                data: color
            }).then(function (result) {
                $scope.getColors();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editColor = function (color) {
            $http({
                method: "POST",
                url: "/admin/Color/Edit",
                data: color
            }).then(function (result) {
                $scope.getColors();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addColor = function (color) {
            $http({
                method: "POST",
                url: "/admin/Color/Add",
                data: color
            }).then(function (result) {
                $scope.getColors();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.getColors();

    });