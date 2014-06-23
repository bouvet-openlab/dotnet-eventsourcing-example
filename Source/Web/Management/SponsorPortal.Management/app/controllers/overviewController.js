(function () {

    var APPLICATION_STATUS_NOT_STARTED = "Not started";
    var APPLICATION_STATUS_GRANTED = "Granted";
    var APPLICATION_STATUS_DENIED = "Denied";
    var APPLICATION_STATUS_INPROGRESS = "In progress";

    var overviewController = function ($scope, $location, notifyHelper, overviewService) {
        $scope.applicationForms = [
            { id: '001', title: "Norway cup 2014", createdTimestamp: '20.06.2014 08:15', updatedTimestamp: '20.06.2014 08:15', clerk: { name: "Eirik Årdal" }, status: APPLICATION_STATUS_NOT_STARTED },
            { id: '002', title: "Konferanse", createdTimestamp: '10.06.2014 08:15', updatedTimestamp: '18.06.2014 10:00', clerk: { name: "Ola Normann" }, status: APPLICATION_STATUS_DENIED },
            { id: '003', title: "Utenlandstur", createdTimestamp: '14.06.2014 08:15', updatedTimestamp: '19.06.2014 13:30', clerk: { name: "Eirik Årdal" }, status: APPLICATION_STATUS_INPROGRESS },
            { id: '004', title: "Seminar", createdTimestamp: '15.06.2014 08:15', updatedTimestamp: '20.06.2014 08:15', clerk: { name: "Kari Normann" }, status: APPLICATION_STATUS_GRANTED },
            { id: '005', title: "Prisutdeling", createdTimestamp: '15.06.2014 08:15', updatedTimestamp: '15.06.2014 05:15', clerk: { name: "Eirik Årdal" }, status: APPLICATION_STATUS_NOT_STARTED },
        ];

        $scope.getLabelForStatus = function(status) {
            if (status === APPLICATION_STATUS_NOT_STARTED)
                return 'label label-danger';
            if (status === APPLICATION_STATUS_GRANTED)
                return 'label label-success';
            if (status === APPLICATION_STATUS_DENIED)
                return 'label label-success';
            if (status === APPLICATION_STATUS_INPROGRESS)
                return 'label label-info';
            return 'label label-default';
        };
    };

    angular.module("sponsorMngmtModule").controller("overviewController", overviewController);
}());