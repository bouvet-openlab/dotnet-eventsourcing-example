(function() {
    var app = angular.module("sponsorMngmtModule", ['ngRoute']);

    app.config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: "overviewController",
                templateUrl: "overview.html"
            })
            .when('/applicationform', {
                controller: "applicationFormController",
                templateUrl: "applicationForm.html"
            })
            .otherwise({
                redirectTo: "/"
            });
    });
}());