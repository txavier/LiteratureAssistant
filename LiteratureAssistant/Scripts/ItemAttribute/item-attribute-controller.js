﻿itemModule.controller("itemAttributeController", function ($scope, itemService) {
    $scope.itemAttributes = itemService.getItemAttributes();
});