(function () {

    var applicationFormService = function ($http) {
        return {
            saveApplicationForm: function (applicationForm) {
                return $http.post("http://localhost:8200/sponsorportal/receival/applicationform", applicationForm);
            }
        }
    };

    angular.module("sponsorFormModule").factory("applicationFormService", applicationFormService);
}());