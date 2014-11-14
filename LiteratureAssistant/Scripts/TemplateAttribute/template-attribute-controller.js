itemModule.controller("templateAttributeController", function ($scope, $routeParams, $http, $route, $templateCache, $location,
    itemService) {
    $scope.templateAttributes = itemService.getTemplateAttributes();

    $scope.formData = {};

    var log = [];

    // If there is a route parameter of an ItemId then we are editing and get the 
    // item from the web api get method.
    if ($routeParams.itemId != null) {

        var resultPromise = $http.get("api/itemsApi/" + $routeParams.itemId);

        resultPromise.success(function (item) {

            $scope.item = item;

            angular.forEach($scope.item.itemAttributes, function (itemAttribute, key) {

                $scope.formData[itemAttribute.templateAttribute.templateAttributeName] = itemAttribute.value;

            }, log);
        });
    }

    $scope.sendItem = function () {
        var itemAttributes = $scope.formData;

        var item = { itemAttributes: itemAttributes };

        var newItem = itemService.saveItem(item);

        newItem.$promise.then(function () {
            // Reload the item template with the latest data.
            $scope.items = itemService.getItems();

            $location.path("/item");
        });
    }

    $scope.editItem = function (item) {
        var itemAttributes = $scope.formData;

        var updatedItem = { itemId: item.itemId, itemAttributes: itemAttributes };

        updatedItem = itemService.saveItem(updatedItem);

        updatedItem.$promise.then(function () {
            // Reload the item template with the latest data.
            $scope.items = itemService.getItems();

            $location.path("/item");
        });
    }
});