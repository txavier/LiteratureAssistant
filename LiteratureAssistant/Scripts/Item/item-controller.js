itemModule.controller("itemController", function ($scope, itemService, $routeParams, $log, $route, $templateCache) {
    $log.log('Parameters: ItemId: ' + $routeParams.itemId);

    // If there is a request for an item get the item from web api.
    if ($routeParams.itemId != null) {
        $log.log('ItemId is not null');

        itemService.getItem($routeParams.itemId).$promise.then(function (item) {
            $scope.item = item;

            $scope.items = itemService.getItems();
        });
    }

    itemService.getItems().$promise.then(function (items) {
        $scope.items = items;
    });

    $scope.deleteItem = function (itemId) {
        itemService.deleteItem(itemId).$promise.then(function () {
            // Reload the item template with the latest data.
            $scope.items = itemService.getItems();
        })
    }
});