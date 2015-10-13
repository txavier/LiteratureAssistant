(function () {
    angular
        .module('app')
        .controller('openOrdersController', openOrdersController);

    openOrdersController.$inject = ['$scope', '$location', '$routeParams', '$http', 'dataService'];

    function openOrdersController($scope, $location, $routeParams, $http, dataService) {
        var vm = this;

        vm.openOrders = [];
        vm.deleteOrder = deleteOrder;

        activate();

        function activate() {
            getOrders();

            return vm;
        }

        function getOrders() {
            return dataService.getOpenOrders().then(function (data) {
                vm.openOrders = data;

                return vm.openOrders;
            });
        }

        function deleteOrder(orderId) {
            dataService.deleteOrder(orderId).$promise.then(function () {
                $scope.$apply();

                getOrders();
            });
        }
    }
})();