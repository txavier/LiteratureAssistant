(function () {
    angular
        .module('app')
        .controller('barcodesController', barcodesController);

    barcodesController.$inject = ['$scope', '$log', '$routeParams', 'dataService', 'jsPdfBarcodeService'];

    function barcodesController($scope, $log, $routeParams, dataService, jsPdfBarcodeService) {
        var vm = this;

        vm.demoFromHtml = demoFromHtml;
        vm.items = [];
        vm.item = {};
        var linesToPrintArray = [];

        activate();

        function activate() {
            setView();

            return vm;
        }

        function setView() {
            dataService.getBarcodes($routeParams.itemId).then(function (data) {
                vm.items = data;

                vm.item = vm.items[0];
            });
        }

        function demoFromHtml() {
            linesToPrintArray[0] = vm.item.fieldName;
            linesToPrintArray[1] = vm.item.value;

            jsPdfBarcodeService.startRow = 5;

            jsPdfBarcodeService.getPdf(true, vm.item.barcodeBase64DataUri, 10, 3, 21, null, linesToPrintArray, null);
        }

    }
})();