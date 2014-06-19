(function() {
    var app = angular.module("sponsorFormModule", ['ngRoute']);

    app.config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: "applicationFormController",
                templateUrl: "applicationForm.html"
            })
            .otherwise({
                redirectTo: "/"
            });
    });
}());