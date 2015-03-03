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
            return dataService.getOrders().$promise.then(function (data) {
                vm.orders = data;

                return vm.orders;
            });
        }

        function deleteOrder(orderId) {
            dataService.deleteOrder(orderId).$promise.then(function () {
                $scope.orders = dataService.getOrders();

                $location.path("/order");
            });
        }
    }
})();