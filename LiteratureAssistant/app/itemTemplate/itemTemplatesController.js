(function () {
    angular
        .module('app')
        .controller('itemTemplatesController', itemTemplatesController);

    itemTemplatesController.$inject = ['$scope', '$log', '$routeParams', 'dataService'];

    function itemTemplatesController($scope, $log, $routeParams, dataService) {
        var vm = this;

        vm.itemTemplates = {};
        vm.organizationId = null;
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
            setOrganizationId($routeParams);

            return vm;
        }

        function setOrganizationId($routeParams) {
            vm.organizationId = $routeParams.organizationId;
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
                    getItemTemplates();
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