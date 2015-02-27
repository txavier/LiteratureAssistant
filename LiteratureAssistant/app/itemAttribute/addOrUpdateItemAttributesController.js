(function () {
    angular
        .module('app')
        .controller('addOrUpdateItemAttributesController', addOrUpdateItemAttributesController);

    addOrUpdateItemAttributesController.$inject = ['$scope', '$log', 'dataService'];

    function addOrUpdateItemAttributesController($scope, $log, dataService) {
        var vm = this;

        vm.itemAttributes = [];
        vm.itemAttribute = {};
        vm.getItemAttributes = getItemAttributes;
        vm.saveItemAttribute = addOrUpdateItemAttribute;
        vm.getItems = getItems;
        vm.getTemplateAttributes = getTemplateAttributes;
        vm.items = [];
        vm.templateAttributes = [];

        activate();

        function activate() {
            getItemAttributes();
            getItems();
            getTemplateAttributes();

            return vm;
        }

        function getItemAttributes() {
            return dataService.getItemAttributes().then(function (data) {
                vm.itemAttributes = data;

                return vm.itemAttributes;
            });
        }

        function getItemAttribute(itemAttributeId) {
            return dataService.getItemAttribute(itemAttributeId).then(function (data) {
                vm.itemAttribute = data;

                return vm.itemAttribute;
            });
        }

        function getItems() {
            return dataService.getItems().then(function (data) {
                vm.items = data;

                return vm.items;
            });
        }

        function getTemplateAttributes() {
            return dataService.getTemplateAttributes().then(function (data) {
                vm.templateAttributes = data;

                return vm.templateAttributes;
            });
        }

        function addOrUpdateItemAttribute() {
            return dataService.addOrUpdateItemAttribute(vm.itemAttribute)
                .then()
                .catch();
        }

        function deleteItemAttribute(itemAttributeId) {
            return dataService.deleteItemAttribute(itemAttributeId)
                .then()
                .catch();
        }

    }

})();