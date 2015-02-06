(function () {
    angular
        .module('itemModule')
        .controller('addOrUpdateItemTemplatesController', addOrUpdateItemTemplatesController);

    addOrUpdateItemTemplatesController.$inject = ['$scope', '$log', 'dataService'];

    function addOrUpdateItemTemplatesController($scope, $log, dataService) {
        var vm = this;

        vm.itemTemplates = [];
        vm.itemTemplate = {};
        vm.getItemTemplates = getItemTemplates;
        vm.saveItemTemplate = addOrUpdateItemTemplate;

        activate();

        function activate() {
            getItemTemplates();

            return vm;
        }

        function getItemTemplates() {
            return dataService.getItemTemplates().then(function (data) {
                vm.itemTemplates = data;

                return vm.itemTemplates;
            });
        }

        function getItemTemplate(itemTemplateId) {
            return dataService.getItemTemplate(itemTemplateId).then(function (data) {
                vm.itemTemplate = data;

                return vm.itemTemplate;
            });
        }

        function addOrUpdateItemTemplate() {
            return dataService.addOrUpdateItemTemplate(vm.itemTemplate)
                .then()
                .catch();
        }

        function deleteItemTemplate(itemTemplateId) {
            return dataService.deleteItemTemplate(itemTemplateId)
                .then()
                .catch();
        }

    }

})();