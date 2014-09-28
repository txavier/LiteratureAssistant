var itemModule = angular.module("itemModule", []);

itemModule.factory("itemService", function($http){
    return {
        getItems : function()
        {
            return $http.get("api/itemsApi");
        }
}
});


itemModule.controller("itemController", function($scope, itemService) {
    var resultPromise = itemService.getItems();

    resultPromise.success(function (data){
        $scope.items = data;
    })
});

var indexController = function ($scope)
{
    $scope.items = [
        { itemId: 1, itemTemplateId: 4},
        { itemId: 2, itemTemplateId: 5}];
}

