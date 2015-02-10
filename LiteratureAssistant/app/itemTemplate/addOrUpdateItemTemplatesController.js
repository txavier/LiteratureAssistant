(function () {
    angular
        .module('itemModule')
        .controller('addOrUpdateItemTemplatesController', addOrUpdateItemTemplatesController);

    addOrUpdateItemTemplatesController.$inject = ['$scope', '$log', '$location', 'dataService'];

    function addOrUpdateItemTemplatesController($scope, $log, $location, dataService) {
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
                .then(
                $location.path('/itemTemplates')
                )
                .catch();
        }

        function deleteItemTemplate(itemTemplateId) {
            return dataService.deleteItemTemplate(itemTemplateId)
                .then()
                .catch();
        }

    }

})();