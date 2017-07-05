var app = angular.module('mainModule', []);

app.controller('cartCtrl',
    function ($scope, $http) {

        $scope.getCart = function () {
            $http({
                method: "GET",
                url: "/Cart/GetCart"
            }).then(
                function (response) {
                    $scope.cart = response.data;
                },
                function (response) {
                    console.log(response);
                }
                );
        };

        $scope.deleteCartDetail = function (cartDetail) {
            $http({
                method: "POST",
                url: "/Cart/DeleteProductFromCart",
                data: cartDetail
            }).then(
                function (response) {
                    toastr.info(response.data);
                    $scope.getCart();
                },
                function (response) {
                    console.log(response);
                }
                );
        };

        $scope.addProductToCart = function (ProductDetailID) {
            $http({
                method: "POST",
                url: "/Cart/AddProductToCart",
                params: { productDetailID: ProductDetailID }
            }).then(
                function (response) {
                    toastr.info(response.data);
                    $scope.getCart();
                },
                function (response) {
                    console.log(response);
                }
                );
        };

        $scope.updateCartDetail = function (cartDetail) {
            $http({
                method: "POST",
                url: "/Cart/UpdateCartDetail",
                data: cartDetail
            }).then(
                function (response) {
                    toastr.info(response.data);
                    $scope.getCart();
                },
                function (response) {
                    console.log(response);
                }
                );
        };

        $scope.applyCouponToCart = function (cartID, couponCode) {
            $http({
                method: "GET",
                url: "/Coupon/ApplyCouponToCart",
                params: {
                    cartID: cartID,
                    couponCode: couponCode
                }
            }).then(
                function (response) {
                    toastr.info(response.data);
                    $scope.getCart();
                },
                function (response) {
                    console.log(response);
                }
                );
        };

        $scope.addProductToCartFromProductsPage = function (ProductDetailID) {
            $http({
                method: "POST",
                url: "/Cart/AddProductToCart",
                params: {
                    productDetailID: ProductDetailID,
                    quantity: $("#input-quantity").val()
                }
            }).then(
                function (response) {
                    toastr.info(response.data);
                    $scope.getCart();
                },
                function (response) {
                    console.log(response);
                }
                );
        };

        $scope.getCountries = function () {
            $http({
                method: "GET",
                url: "/Country/Index"
            }).then(function (result) {
                $scope.countries = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.getCitiesByCountryID = function (countryID) {
            console.log(countryID);
            $http({
                method: "GET",
                url: "/City/GetCitiesByCountryID",
                params: { id: countryID }
            }).then(function (result) {
                $scope.cities = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.getTownsByCityID = function (cityID) {
            $http({
                method: "GET",
                url: "/Town/GetTownByCityID",
                params: { id: cityID }
            }).then(function (result) {
                $scope.towns = result.data;
            }, function (result) {
                console.log(result);
            });
        };



        $scope.getCart();
    });

app.controller("bestSellersCtrl",
    function($scope, $http) {
        $scope.getBestSellers = function () {
            $http({
                method: "GET",
                url: "/Checkout/BestSellers"
            }).then(function (result) {
                $scope.bestSellers = result.data;
            }, function (result) {
                console.log(result);
            });
        };
    }
);