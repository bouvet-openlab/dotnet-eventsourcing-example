(function () {

    var APPLICATION_STATUS_NOT_STARTED = "Not started";
    var APPLICATION_STATUS_GRANTED = "Granted";
    var APPLICATION_STATUS_DENIED = "Denied";
    var APPLICATION_STATUS_INPROGRESS = "In progress";

    var statusHelper = function() {
        return {
            getLabelForStatus: function(status) {
                if (status === APPLICATION_STATUS_NOT_STARTED)
                    return 'label label-danger';
                if (status === APPLICATION_STATUS_GRANTED)
                    return 'label label-success';
                if (status === APPLICATION_STATUS_DENIED)
                    return 'label label-success';
                if (status === APPLICATION_STATUS_INPROGRESS)
                    return 'label label-info';
                return 'label label-default';
            }
        }
    };

    angular.module("sponsorMngmtModule").factory("statusHelper", statusHelper);
}());