app.controller('contactUsCtrl',
    function ($scope, $http) {

        $scope.getContactUs = function () {
            $http({
                method: "GET",
                url: "/admin/CompanyInfo/Index"
            }).then(function (result) {
                $scope.contactUs = result.data;
            }, function (result) {
                console.log(result);
            });
        
            $scope.getContactUs();
        };

    });