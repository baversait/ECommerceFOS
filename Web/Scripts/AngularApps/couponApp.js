app.controller('couponCtrl',
    function ($scope, $http) {

        $scope.getCoupons = function () {
            $http({
                method: "GET",
                url: "/admin/Coupon/Index"
            }).then(function (result) {
                $scope.coupons = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectCoupon = function (coupon) {
            $scope.selectedCoupon = coupon;
            
        };
       

        $scope.deleteCoupon = function (coupon) {
            $http({
                method: "POST",
                url: "/admin/Coupon/Delete",
                data: coupon
            }).then(function (result) {
                $scope.getCoupons();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editCoupon = function (coupon) {
            $http({
                method: "POST",
                url: "/admin/Coupon/Edit",
                data: coupon
            }).then(function (result) {
                $scope.getCoupons();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addCoupon = function (coupon) {
            $http({
                method: "POST",
                url: "/admin/Coupon/Add",
                data: coupon
            }).then(function (result) {
                $scope.getCoupons();
            }, function (result) {
                console.log(result);
            });
        };

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

        
        $scope.getCoupons();

    });

app.controller('couponCheckoutCtrl',
    function($scope, $http) {


    }
);