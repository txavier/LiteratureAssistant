itemModule.controller("countController", function ($scope, $location, $routeParams, $http, countService, itemService) {
    $scope.counts = countService.getCounts();

    $scope.items = itemService.getItems();

    // Get single count or create a new count to be created by the user.
    if ($routeParams.countId != null) {
        countService.getCount($routeParams.countId).$promise.then(function (count) {
            $scope.count = count;
        });
    }
    else {
        $scope.count = { countId: 0, receivedDate: countService.getToday(), currentlyOnHandDate: countService.getToday() };
    }

    $scope.sendCount = function (count) {
        countService.saveCount(count).$promise.then(function () {
            $scope.counts = countService.getCounts();
        });

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
        countService.deleteCount(countId).$promise.then(function () {
            $scope.counts = countService.getCounts();
        });
    }
});