﻿itemModule.controller("itemController", function ($scope, itemService, $routeParams, $log, $route, $templateCache) {
    $log.log('Parameters: ItemId: ' + $routeParams.itemId);

    if ($routeParams.itemId != null) {
        $log.log('ItemId is not null');
        $scope.item = itemService.getItem.get({ id: $routeParams.itemId });
    }

    $scope.items = itemService.getItems.query({}, isArray = true);

    $scope.deleteItem = function (itemId) {
        itemService.getItem.delete({ id: itemId });

        var currentPageTemplate = $route.current.templateUrl;
        $templateCache.remove(currentPageTemplate);
        $route.reload();
    }
});