(function () {

    var applicationFormService = function ($http) {
        return {
            getApplication: function(applicationFormId) {
                return $http.get("../../applicationforms/" + applicationFormId);
            },
            getApplications: function() {
                return $http.get("../../applicationforms");
            }
        }
    };

    angular.module("sponsorMngmtModule").factory("applicationFormService", applicationFormService);
}());