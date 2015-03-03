(function () {
    angular
        .module('app')
        .controller('itemsController', itemsController);

    itemsController.$inject = ['$scope', '$routeParams', '$log', '$route', '$templateCache', 'dataService'];

    function itemsController($scope, $routeParams, $log, $route, $templateCache, dataService) {
        var vm = this;

        vm.item = {};
        vm.items = [];
        vm.deleteItem = deleteItem;

        activate();

        function activate() {
            setView($routeParams);
            getItems();

            return vm;
        }

        // If there is a request for an item get the item from web api.
        function setView($routeParams) {
            if ($routeParams.itemId) {
                getItem($routeParams.itemId)
            }
        }

        function getItem(itemId) {
            if ($routeParams.itemId != null) {
                return dataService.getItem(itemId).then(function (data) {
                    vm.item = data;

                    return vm.item;
                });
            }
        }

        function getItems() {
            return dataService.getItems().then(function (data) {
                vm.items = data;

                return vm.items;
            });
        }

        function deleteItem(itemId) {
            return dataService.deleteItem(itemId).then(function () {
                // Reload the item template with the latest data.
                getItems();
            });
        }

    }
})();