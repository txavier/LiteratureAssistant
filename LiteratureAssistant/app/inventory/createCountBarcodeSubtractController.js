(function () {
    angular
        .module('itemModule')
        .controller('createCountBarcodeSubtractController', createCountBarcodeSubtractController);

    createCountBarcodeSubtractController.$inject = ['$scope', '$log', 'dataService'];

    function createCountBarcodeSubtractController($scope, $log, dataService) {
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