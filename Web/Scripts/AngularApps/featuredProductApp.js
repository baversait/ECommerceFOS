app.controller('featuredProductCtrl',
    function ($scope, $http) {

        

        $scope.getFeaturedProducts = function () {
            $http({
                method: "GET",
                url: "/admin/FeaturedProduct/Index"
            }).then(function (result) {
                // console.log(result);
                $scope.featuredProducts = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectFeaturedProduct = function (featuredProduct) {
            $scope.selectedFeaturedProduct = featuredProduct;            
        };

        $scope.deleteFeaturedProduct = function (featuredProduct) {
            $http({
                method: "POST",
                url: "/admin/FeaturedProduct/Delete",
                data: featuredProduct
            }).then(function (result) {
                $scope.getFeaturedProducts();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editFeaturedProduct = function (featuredProduct) {
            $http({
                method: "POST",
                url: "/admin/FeaturedProduct/Edit",
                data: featuredProduct
            }).then(function (result) {
                $scope.getFeaturedProducts();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addFeaturedProduct = function (featuredProduct) {
            $http({
                method: "POST",
                url: "/admin/FeaturedProduct/Add",
                data: featuredProduct
            }).then(function (result) {
                $scope.getFeaturedProducts();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.getProducts = function () {
            $http({
                method: "GET",
                url: "/admin/ProductDetail/Index"
            }).then(function (result) {
                // console.log(result);
                $scope.Products = result.data;
            }, function (result) {
                console.log(result);
            });
        };
        $scope.cancel = function () {
            $scope.dismiss();
        };

        $scope.getFeaturedProducts();

    });