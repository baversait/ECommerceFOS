app.controller('categoryCtrl',
    function ($scope, $http) {

        $scope.newCategory = {};
        $scope.newCategory.Images = [];

        $scope.getCategories = function () {
            $http({
                method: "GET",
                url: "/admin/Category/Index"
            }).then(function (result) {
               // console.log(result);
                $scope.categories = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectCategory = function (category) {
            $scope.selectedCategory = category;
        };

        $scope.deleteCategory = function (category) {
            $http({
                method: "POST",
                url: "/admin/Category/Delete",
                data: category
            }).then(function (result) {
                $scope.getCategories();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editCategory = function (category) {
            $http({
                method: "POST",
                url: "/admin/Category/Edit",
                data: category
            }).then(function (result) {
                $scope.getCategories();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addCategory = function (category) {
            $http({
                method: "POST",
                url: "/admin/Category/Add",
                data: category
            }).then(function (result) {
                $scope.getCategories();
            }, function (result) {
                console.log(result);
            });
        };

        

        $scope.getCategories();

    });