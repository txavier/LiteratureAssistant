(function () {
    angular
        .module('app')
        .controller('itemTemplatesController', itemTemplatesController);

    itemTemplatesController.$inject = ['$scope', '$log', 'dataService'];

    function itemTemplatesController($scope, $log, dataService) {
        var vm = this;

        vm.itemTemplates = {};
        vm.getItemTemplates = getItemTemplates;
        vm.deleteItemTemplate = deleteItemTemplate;
        vm.totalItems = 0;
        vm.itemsPerPage = 10;
        vm.currentPage = 1;
        vm.pageChanged = pageChanged;

        activate();

        function activate() {
            getItemTemplates();
            getItemTemplatesCount();

            return vm;
        }

        function getItemTemplates() {
            return dataService.getItemTemplates().then(function (data) {
                vm.itemTemplates = data;

                return vm.itemTemplates;
            });
        }

        function deleteItemTemplate(itemTemplateId) {
            return dataService.deleteItemTemplate(itemTemplateId)
                .then(function (data) {
                    vm.itemTemplates = dataService.getItemTemplates().then(function (data) {
                        vm.itemTemplates = data;

                        return vm.itemTemplates;
                    });
                })
                .catch();
        }

        function getItemTemplatesCount() {
            return dataService.getItemTemplatesCount().then(function (data) {
                vm.totalItems = data || 0;

                return vm.totalItems;
            });
        }

        function pageChanged() {

        }

    }

})();