itemModule.controller("templateAttributeController", function ($scope, $routeParams, $http, $route, $templateCache, $location,
    itemService) {
    $scope.templateAttributes = itemService.getTemplateAttributes.query({}, isArray = true);

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

        var newItem = itemService.getItems.save({ item: item });

        $location.path("/item");

        // Reload the item template with the latest data.
        $scope.items = new itemService().getItems.query({}, isArray = true);
    }

    $scope.editItem = function (item) {
        var itemAttributes = $scope.formData;

        var updatedItem = { itemId: item.itemId, itemAttributes: itemAttributes };

        updatedItem = itemService.getItems.save({ item: updatedItem });

        $location.path("/item");

        // Reload the item template with the latest data.
        $scope.items = new itemService().getItems.query({}, isArray = true);
    }
});