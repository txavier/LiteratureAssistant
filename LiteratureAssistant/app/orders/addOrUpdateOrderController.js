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
        vm.sendOrder = sendOrder;
        vm.deleteOrder = deleteOrder;

        activate();

        function activate() {
            getOrder($routeParams.orderId);
            getUsers();
        }

        function getUsers() {
            return userService.getUsers().$promise.then(function (data) {
                vm.users = data;

                return vm.users;
            });
        }

        function getItems() {
            return itemService.getItems().$promise.then(function (data) {
                vm.items = data;

                return vm.items;
            });
        }

        function getOrder(orderId) {
            return orderService.getOrder(orderId).$promise.then(function (data) {
                vm.order = data;

                return vm.order;
            });
        }

        function sendOrder(order) {
            orderService.saveOrder(order).$promise.then(function () {
                vm.orders = orderService.getOrders();

                $location.path("/order");
            });
        }

        function open($event) {
            $event.preventDefault();

            $event.stopPropagation();

            vm.opened = true;
        };

        function deleteOrder(orderId) {
            return orderService.deleteOrder(orderId).$promise.then(function () {
                vm.orders = orderService.getOrders();

                $location.path("/order");
            });
        }
    }
})();