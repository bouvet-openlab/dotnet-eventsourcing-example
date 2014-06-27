(function () {

    var overviewService = function ($http) {

        var service = {};

        service.getApplicationForms = function() {
            return $http.get("http://localhost:8300/sponsorportal/api/applicationforms");
        };

        return service;

    };

    angular.module("sponsorMngmtModule").factory("overviewService", overviewService);
}());