var app = angular.module('adminModule', ['ngRoute']);

app.config(['$locationProvider',
    function ($locationProvider) {
        $locationProvider.hashPrefix('');
    }]);

app.config(
    function ($routeProvider) {
        $routeProvider.when('/Currencies',
            {
                templateUrl: '/Templates/Currency.html',
                controller: "currencyCtrl"
            });

        $routeProvider.when('/Countries',
            {
                templateUrl: '/Templates/Country.html',
                controller: "countryCtrl"
            });

        $routeProvider.when('/Cities',
            {
                templateUrl: '/Templates/City.html',
                controller: "cityCtrl"
            });

        $routeProvider.when('/Towns',
            {
                templateUrl: '/Templates/Town.html',
                controller: "townCtrl"
            });

        $routeProvider.when('/CompanyInfos',
            {
                templateUrl: '/Templates/CompanyInfo.html',
                controller: "companyInfoCtrl"
            });

        $routeProvider.when('/Brands',
            {
                templateUrl: '/Templates/Brand.html',
                controller: "brandCtrl"
            });
        $routeProvider.when('/Colors',
            {
                templateUrl: '/Templates/Color.html',
                controller: "colorCtrl"
            });
        $routeProvider.when('/Companies',
            {
                templateUrl: '/Templates/Company.html',
                controller: "companyCtrl"
            });
        $routeProvider.when('/Categories',
            {
                templateUrl: '/Templates/Category.html',
                controller: "categoryCtrl"
            });
        $routeProvider.when('/SubCategories',
            {
                templateUrl: '/Templates/SubCategory.html',
                controller: "subCategoryCtrl"
            });
        $routeProvider.when('/Products',
            {
                templateUrl: '/Templates/Product.html',
                controller: "productCtrl"
            });
        $routeProvider.when('/ShippingTypes',
            {
                templateUrl: '/Templates/ShippingType.html',
                controller: "shippingTypeCtrl"
            });
        $routeProvider.when('/FrontPageBanners',
            {
                templateUrl: '/Templates/FrontPageBanner.html',
                controller: "frontPageBannerCtrl"
            });
        $routeProvider.when('/Users',
            {
                templateUrl: '/Templates/User.html',
                controller: "userCtrl"
            });
        $routeProvider.when('/Coupons',
            {
                templateUrl: '/Templates/Coupon.html',
                controller: "couponCtrl"
            });
        $routeProvider.when('/FeaturedProducts',
            {
                templateUrl: '/Templates/FeaturedProduct.html',
                controller: "featuredProductCtrl"
            });
        $routeProvider.when('/Orders',
            {
                templateUrl: '/Templates/Order.html',
                controller: "orderCtrl"
            });

        $routeProvider.otherwise(
            {
                redirectTo: "/"
            });
    });