(function () {

    var notifyHelper = function () {

        var helper = {};

        var settings = {
            opacity: 1.0,
            history: {
                menu: true
            }
        };

        helper.info = function (message) {
            settings.title = 'Information';
            settings.text = formatMessage(message);
            settings.type = 'info';
            return $(function () {
                new PNotify(settings);
            });

        };

        helper.success = function (message) {
            settings.title = 'Success';
            settings.text = formatMessage(message);
            settings.type = 'success';
            return $(function () {
                new PNotify(settings);
            });

        };

        helper.error = function (message) {
            settings.title = 'Error';
            settings.text = formatMessage(message);
            settings.type = 'error';
            return $(function () {
                new PNotify(settings);
            });
        };

        return helper;
    };

    var formatMessage = function (message) {
        if (angular.isArray(message)) {
            var formatted = '<ul>';
            angular.forEach(message, function (feil) {
                formatted += "<li>" + feil + "</li>";
            });
            return formatted += "</ul>";
        } else {
            return message;
        }
    };

    angular.module('sponsorFormModule').factory('notifyHelper', notifyHelper);
}());
