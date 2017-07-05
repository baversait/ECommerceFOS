app.controller('frontPageBannerCtrl',
    function ($scope, $http) {

        $scope.newFrontPage = {};
        $scope.newFrontPage.Images = [];

        $scope.getFrontPages = function () {
            $http({
                method: "GET",
                url: "/admin/FrontPageBanner/Index"
            }).then(function (result) {
                console.log(result);
                $scope.frontPages = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.selectFrontPage = function (frontPage) {
            $scope.selectedFrontPage = frontPage;
            
        };

        $scope.deleteFrontPage = function (frontPage) {
            $http({
                method: "POST",
                url: "/admin/FrontPageBanner/Delete",
                data: frontPage
            }).then(function (result) {
                $scope.getFrontPages();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.editFrontPage = function (frontPage) {
            $http({
                method: "POST",
                url: "/admin/FrontPageBanner/Edit",
                data: frontPage
            }).then(function (result) {
                $scope.getFrontPages();
            }, function (result) {
                console.log(result);
            });
        };

        $scope.addFrontPage = function (frontPage) {
            $http({
                method: "POST",
                url: "/admin/FrontPageBanner/Add",
                data: frontPage
            }).then(function (result) {
                $scope.getFrontPages();
            }, function (result) {
                console.log(result);
            });
        };

        

        $scope.getFrontPages();

    });