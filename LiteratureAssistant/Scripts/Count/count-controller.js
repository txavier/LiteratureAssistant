itemModule.controller("countController", function ($scope, $location, $routeParams, $http, countService, itemService) {

    $scope.counts = countService.getCounts;

    $scope.items = itemService.getItems.query({}, isArray = true);

    if ($routeParams.countId != null) {

        $scope.count = countService.getCount($routeParams.countId);
    }
    else {
        $scope.count = { countId: 0, receivedDate: countService.getToday(), currentlyOnHandDate: countService.getToday() };
    }


    $scope.sendCount = function (count) {

        var newCount = countService.saveCount(count);

        $scope.count = {};
    }

    $scope.receivedDateOpen = function ($event) {
        $event.preventDefault();

        $event.stopPropagation();

        $scope.receivedDateOpened = true;
    };

    $scope.currentlyOnHandDateOpen = function ($event) {
        $event.preventDefault();

        $event.stopPropagation();

        $scope.currentlyOnHandDateOpened = true;
    };

    $scope.deleteCount = function (countId) {

        countService.deleteCount(countId);
    }
});
