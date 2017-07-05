app.controller('townCtrl',
    function ($scope, $http) {

        $scope.getTowns = function () {
            $http({
                method: "GET",
                url: "/admin/Town/Index"
            }).then(function (result) {
                console.log(result);
                $scope.towns = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectTown = function (town) {
            $scope.selectedTown = town;
            $scope.getCities();
        };

        $scope.deleteTown = function (town) {
            $http({
                method: "POST",
                url: "/admin/Town/Delete",
                data: town
            }).then(function (result) {
                $scope.getTowns();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editTown = function (town) {
            $http({
                method: "POST",
                url: "/admin/Town/Edit",
                data: town
            }).then(function (result) {
                $scope.getTowns();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addTown = function (town) {
            $http({
                method: "POST",
                url: "/admin/Town/Add",
                data: town
            }).then(function (result) {
                $scope.getTowns();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.getCities = function () {
            $http({
                method: "GET",
                url: "/admin/City/Index"
            }).then(function (result) {
                $scope.cities = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.getTowns();

    });