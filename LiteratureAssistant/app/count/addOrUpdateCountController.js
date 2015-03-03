(function () {
    angular
        .module('app')
        .controller('addOrUpdateCountController', addOrUpdateCountController);

    addOrUpdateCountController.$inject = ['$scope', '$location', '$routeParams', 'countService', 'dataService'];

    function addOrUpdateCountController($scope, $location, $routeParams, countService, dataService) {
        var vm = this;

        vm.items = [];
        vm.count = {};
        vm.addOrUpdateCount = addOrUpdateCount;
        vm.receivedDateOpen = receivedDateOpen;
        vm.receivedDateOpened = false;
        vm.currentlyOnHandDateOpen = currentlyOnHandDateOpen;
        vm.currentlyOnHandDateOpened = false;

        activate();

        function activate() {
            getItems();
            setView($routeParams);

            return vm;
        }

        function getItems() {
            return dataService.getItems().then(function (data) {
                vm.items = data;

                return vm.items;
            });
        }

        function setView($routeParams) {
            if ($routeParams.countId) {
                getCount($routeParams.countId);
            }
            else {
                setNewCount($routeParams.itemId);
            }
        }

        // Get single count or create a new count to be created by the user.
        function getCount(countId) {
            if (countId != null) {
                return dataService.getCount(countId).then(function (data) {
                    vm.count = data;

                    return vm.count;
                });
            }
        }

        function setNewCount(itemId) {
            if (itemId != null) {
                vm.count = { itemId: itemId, receivedDate: countService.getToday(), currentlyOnHandDate: countService.getToday() };
            }
            else {
                vm.count = { countId: 0, receivedDate: countService.getToday(), currentlyOnHandDate: countService.getToday() };
            }
        }

        function addOrUpdateCount(count) {
            return dataService.addOrUpdateCount(count).then(function (data) {
                $location.path('/counts');
            });
        }

        function receivedDateOpen($event) {
            $event.preventDefault();

            $event.stopPropagation();

            vm.receivedDateOpened = true;
        }

        function currentlyOnHandDateOpen($event) {
            $event.preventDefault();

            $event.stopPropagation();

            vm.currentlyOnHandDateOpened = true;
        }

    }
})();