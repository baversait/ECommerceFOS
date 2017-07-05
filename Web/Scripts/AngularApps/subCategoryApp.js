app.controller('subCategoryCtrl',
    function ($scope, $http) {

        $scope.newSubCategory = {};
        $scope.newSubCategory.Images = [];

        $scope.getSubCategories = function () {
            $http({
                method: "GET",
                url: "/admin/SubCategory/Index"
            }).then(function (result) {
                console.log(result);
                $scope.subCategories = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectSubCategory = function (subCategory) {
            $scope.selectedSubCategory = subCategory;
            $scope.getCategories();
        };

        $scope.deleteSubCategory = function (subCategory) {
            $http({
                method: "POST",
                url: "/admin/SubCategory/Delete",
                data: subCategory
            }).then(function (result) {
                $scope.getSubCategories();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editSubCategory = function (subCategory) {
            $http({
                method: "POST",
                url: "/admin/SubCategory/Edit",
                data: subCategory
            }).then(function (result) {
                $scope.getSubCategories();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addSubCategory = function (subCategory) {
            console.log(subCategory);
            $http({
                method: "POST",
                url: "/admin/SubCategory/Add",
                data: subCategory
            }).then(function (result) {
                $scope.getSubCategories();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.getCategories = function() {
            $http({
                method: "GET",
                url: "/admin/Category/Index"
            }).then(function (result) {
                $scope.categories = result.data;
            }, function (result) {
                console.log(result);
            });
        }
        $scope.getSubCategories();

    });