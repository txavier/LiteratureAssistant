(function () {
    angular
        .module('app')
        .controller('addOrUpdateOrderController', addOrUpdateOrderController);

    addOrUpdateOrderController.$inject = ['$scope', '$location', '$routeParams', '$http', 'dataService'];

    function addOrUpdateOrderController($scope, $location, $routeParams, $http, dataService) {
        var vm = this;

        vm.order = {};
        vm.users = [];
        vm.items = [];
        vm.addOrUpdateOrder = addOrUpdateOrder;
        vm.deleteOrder = deleteOrder;

        activate();

        function activate() {
            getOrder($routeParams.orderId);
            getUsers();
            getItems();
        }

        function getUsers() {
            return dataService.getUsers().$promise.then(function (data) {
                vm.users = data;

                return vm.users;
            });
        }

        function getItems() {
            return dataService.getItems().then(function (data) {
                vm.items = data;

                return vm.items;
            });
        }

        function getOrder(orderId) {
            if (orderId) {
                return dataService.getOrder(orderId).$promise.then(function (data) {
                    vm.order = data;

                    return vm.order;
                });
            }
        }

        function addOrUpdateOrder(order) {
            dataService.addOrUpdateOrder(order).$promise.then(function () {
                vm.orders = dataService.getOrders();

                $location.path("/order");
            });
        }

        function open($event) {
            $event.preventDefault();

            $event.stopPropagation();

            vm.opened = true;
        };

        function deleteOrder(orderId) {
            return dataService.deleteOrder(orderId).$promise.then(function () {
                vm.orders = dataService.getOrders();

                $location.path("/order");
            });
        }
    }
})();