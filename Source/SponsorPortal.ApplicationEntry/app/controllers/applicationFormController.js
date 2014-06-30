(function () {

    var applicationFormController = function ($scope, notifyHelper, applicationFormService) {
        $scope.applicationForm = {
            organization: '',
            email: '',
            amount: 0,
            title: '',
            text: ''
        };

        $scope.submitApplication = function () {
            applicationFormService.saveApplicationForm($scope.applicationForm)
                .success(function (data) {
                    notifyHelper.info("Application " + $scope.applicationForm.title + " was registered");
                });
        };
    };

    angular.module("sponsorFormModule").controller("applicationFormController", applicationFormController);
}());