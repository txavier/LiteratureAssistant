(function () {
    angular
        .module('app')
        .controller('createCountBarcodeAddController', createCountBarcodeAddController);

    createCountBarcodeAddController.$inject = ['$scope', '$log', '$routeParams', 'dataService'];

    function createCountBarcodeAddController($scope, $log, $routeParams, dataService) {
        var vm = this;

        vm.count = {};
        vm.addOrUpdateCount = addOrUpdateCount;

        activate();

        function activate() {
            getNewCount();

            return vm;
        }

        function getNewCount() {
            var itemId = $routeParams.itemId

            return dataService.getNewCount(itemId).then(function (data) {
                vm.count = data;

                return vm.count;
            });
        }

        function addOrUpdateCount() {
            return dataService.addOrUpdateOrganization(vm.count)
                .then()
                .catch();
        }

    }

})();