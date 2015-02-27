(function () {
    angular
        .module('app')
        .controller('itemAttributesController', itemAttributesController);

    itemAttributesController.$inject = ['$scope', '$log', 'dataService'];

    function itemAttributesController($scope, $log, dataService) {
        var vm = this;

        vm.itemAttributes = {};
        vm.getItemAttributes = getItemAttributes;
        vm.deleteItemAttribute = deleteItemAttribute;
        vm.totalItems = 0;
        vm.itemsPerPage = 10;
        vm.currentPage = 1;
        vm.pageChanged = pageChanged;

        activate();

        function activate() {
            getItemAttributes();
            getItemAttributesCount();

            return vm;
        }

        function getItemAttributes() {
            return dataService.getItemAttributes().then(function (data) {
                vm.itemAttributes = data;

                return vm.itemAttributes;
            });
        }

        function deleteItemAttribute(itemAttributeId) {
            return dataService.deleteItemAttribute(itemAttributeId)
                .then(function (data) {
                    vm.itemAttributes = dataService.getItemAttributes().then(function (data) {
                        vm.itemAttributes = data;

                        return vm.itemAttributes;
                    });
                })
                .catch();
        }

        function getItemAttributesCount() {
            return dataService.getItemAttributesCount().then(function (data) {
                vm.totalItems = data || 0;

                return vm.totalItems;
            });
        }

        function pageChanged() {

        }

    }

})();