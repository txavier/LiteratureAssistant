(function () {
    angular
        .module('app')
        .controller('countsController', countsController);

    countsController.$inject = ['$scope', 'dataService'];

    function countsController($scope, dataService) {
        var vm = this;

        vm.counts = [];
        vm.deleteCount = deleteCount;

        activate();

        function activate() {
            getCounts();

            return vm;
        }

        function getCounts() {
            return dataService.getCounts().then(function (data) {
                vm.counts = data;

                return vm.counts;
            });
        }

        function deleteCount(countId) {
            return dataService.deleteCount(countId).then(function (data) {
                getCounts();
            });
        }
    }
})();