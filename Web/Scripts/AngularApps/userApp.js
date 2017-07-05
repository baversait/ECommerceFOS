app.controller('userCtrl',
    function ($scope, $http) {

        $scope.getUsers = function () {
            $http({
                method: "GET",
                url: "/admin/User/Index"
            }).then(function (result) {
                $scope.users = result.data;
            }, function (result) {
                console.log(result);
            });
        }
        
        $scope.makeUserAdmin = function (user) {
            $http({
                method: "POST",
                url: "/admin/User/MakeUserAdmin",
                data: user
            }).then(function (result) {
                $scope.getUsers();
            }, function (result) {
                console.log(result);
            });
        }

        $scope.getUsers();
    })