(function () {

    var APPLICATION_STATUS_NOT_STARTED = "Not started";
    var APPLICATION_STATUS_GRANTED = "Granted";
    var APPLICATION_STATUS_DENIED = "Denied";
    var APPLICATION_STATUS_INPROGRESS = "In progress";

    var applicationFormController = function ($scope, $routeParams) {
        $scope.applicationId = $routeParams.appid;
 
        $scope.applicationForm = {
            organization: 'The organization',
            email: 'org@company.com',
            amount: 123000,
            title: 'Need money for stuff',
            text: 'Because of this...',
            status: APPLICATION_STATUS_INPROGRESS,
            clerk: { name: 'Eirik Årdal' },
            createdTimestamp: '20.06.2014',
            updatedTimestamp: '23.06.2014',
            history: [
                { user: 'Sponsor Portal', date: '20.06.2014', message: 'Application received' },
                { user: 'Eirik Årdal', date: '23.06.2014', message: 'Assigned clerk changed to \"Eirik Årdal\"' }
            ]
        };

        $scope.getLabelForStatus = function (status) {
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

    angular.module("sponsorMngmtModule").controller("applicationFormController", applicationFormController);
}());