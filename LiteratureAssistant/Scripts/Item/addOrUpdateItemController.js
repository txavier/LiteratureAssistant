// This used to be the old template-attribute-controller before the angular was refactored.  This
// may still have remnants for template attribute operations although they no longer are needed 
// and no longer work.
itemModule.controller("addOrUpdateItemController", function ($scope, $routeParams, $http, $route, $templateCache, $location,
    templateAttributeService, itemService, dataService) {
    $scope.templateAttributes = templateAttributeService.getTemplateAttributes();

    $scope.formData = {};

    var log = [];

    // Get single template attribute.
    if ($routeParams.templateAttributeId != null) {

        templateAttributeService.getTemplateAttributeService($routeParams.templateAttributeId).$promise.then(function (templateAttribute) {
            $scope.templateAttribute = templateAttribute;
        });
    }
    else {
        $scope.templateAttribute = { templateAttributeId: 0 };
    }

    if ($routeParams.itemTemplateId != null) {
        var Data = dataService.getTemplateAttributes(null, $routeParams.itemTemplateId)
            .$promise.then(function (data) {
                $scope.templateAttributes = data;
            });
    }

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

    // Save or update a template attribute.
    $scope.sendTemplateAttribute = function (templateAttribute) {

        templateAttributeService.saveTemplateAttribute(templateAttribute).$promise.then(function () {
            $scope.templateAttributes = templateAttributeService.getTemplateAttributes();
        });

        history.back();
    }

    // Save or update an item.
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

    // Delete a template attribute.
    $scope.deleteTemplateAttribute = function (templateAttributeId) {
        templateAttributeService.deleteTemplateAttribute(templateAttributeId).$promise.then(function () {
            $scope.templateAttributes = templateAttributeService.gettemplateAttributes;
        });
    }
});