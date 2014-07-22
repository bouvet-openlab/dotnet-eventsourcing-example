(function () {

    var applicationFormController = function ($scope, $routeParams, applicationFormService, clerkService, statusHelper) {
        $scope.applicationId = $routeParams.appid;
        
        applicationFormService.getApplication($scope.applicationId)
            .success(function(data) {
                $scope.applicationForm = data;
            });
        
        clerkService.getClerks()
            .success(function(data) {
                $scope.clerks = data;
            });

        //$scope.getLabelForStatus = statusHelper.getLabelForStatus();
        $scope.getLabelForStatus = function(status) {
            return 'label label-defualt';
        };
    };

    angular.module("sponsorMngmtModule").controller("applicationFormController", applicationFormController);
}());