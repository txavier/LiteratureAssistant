var itemModule = angular.module("itemModule", ['ngResource']);

itemModule.factory("itemService", function($resource){
    return {
        getItems: $resource("api/itemsApi"),
        getItemAttributes: $resource("api/itemAttributesApi"),
        getTemplateAttributes: $resource("api/templateAttributesApi")
    };
});

itemModule.controller("itemController", function($scope, itemService) {
    $scope.items = itemService.getItems.query({}, isArray = true);
});

itemModule.controller("itemAttributeController", function ($scope, itemService) {
    $scope.itemAttributes = itemService.getItemAttributes.query({}, isArray = true);
});

itemModule.controller("templateAttributeController", function ($scope, itemService) {
    $scope.templateAttributes = itemService.getTemplateAttributes.query({}, isArray = true);

    $scope.formData = {};

    $scope.sendItem = function () {
        var itemAttributes = $scope.formData;
        var item = { itemAttributes: itemAttributes };
        var newItem = itemService.getItems.save({ item: item });
    }
});

