(function () {

    var applicationFormService = function ($http) {
        return {
            getApplication: function(applicationFormId) {
                return $http.get("http://localhost:8300/sponsorportal/applicationform");
            }
        }
    };

    angular.module("sponsorMngmtModule").controller("applicationFormService", applicationFormService);
}());