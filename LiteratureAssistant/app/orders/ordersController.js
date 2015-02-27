(function () {
    angular
        .module('app')
        .controller('ordersController', ordersController);

    ordersController.$inject = ['$scope', '$location', '$routeParams', '$http', 'dataService'];

    function ordersController($scope, $location, $routeParams, $http, dataService) {
        var vm = this;

        vm.orders = [];
        vm.deleteOrder = deleteOrder;

        activate();

        function activate() {
            getOrders();

            return vm;
        }

        function getOrders() {
            return orderService.getOrders().$promise.then(function (data) {
                vm.orders = data;

                return vm.orders;
            });
        }

        function deleteOrder(orderId) {
            orderService.deleteOrder(orderId).$promise.then(function () {
                $scope.orders = orderService.getOrders();

                $location.path("/order");
            });
        }
    }
})();