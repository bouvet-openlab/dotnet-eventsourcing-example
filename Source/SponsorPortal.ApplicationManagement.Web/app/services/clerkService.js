(function () {

    var clerkService = function ($http) {
        return {
            getClerks: function () {
                return $http.get("../../clerks");
            }
        }
    };

    angular.module("sponsorMngmtModule").factory("clerkService", clerkService);
}());