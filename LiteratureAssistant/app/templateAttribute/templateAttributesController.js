(function () {
    angular
        .module('itemModule')
        .controller('templateAttributesController', templateAttributesController);

    templateAttributesController.$inject = ['$scope', '$log', '$routeParams', '$location', 'dataService'];

    function templateAttributesController($scope, $log, $routeParams, $location, dataService) {
        var vm = this;

        vm.templateAttributes = {};
        vm.getTemplateAttributes = getTemplateAttributes;
        vm.deleteTemplateAttribute = deleteTemplateAttribute;
        vm.totalItems = 0;
        vm.itemsPerPage = 10;
        vm.currentPage = 1;
        vm.pageChanged = pageChanged;
        vm.goToCreate = goToCreate;

        activate();

        function activate() {
            getTemplateAttributes();
            getTemplateAttributesCount();

            return vm;
        }

        // The $resource was used here because we need to pass multiple arguments
        // easily.
        function getTemplateAttributes() {
            return dataService.getTemplateAttributes($routeParams.templateAttributeId, $routeParams.itemTemplateId)
                        .$promise.then(function (data) {
                            vm.templateAttributes = data;

                            return vm.templateAttributes;
                        });
        }

        // The $resource was used here because we need to pass multiple arguments
        // easily.
        function getTemplateAttributesCount() {
            vm.totalItems = dataService.getTemplateAttributesCount($routeParams.templateAttributeId, $routeParams.itemTemplateId)
                    .$promise.then(function (result) {
                            vm.totalItems = result[0] || 0;

                            return vm.totalItems;
            });
        }

        function deleteTemplateAttribute(templateAttributeId) {
            return dataService.deleteTemplateAttribute(templateAttributeId)
                .then(function (data) {
                    vm.templateAttributes = dataService.getTemplateAttributes().then(function (data) {
                        vm.templateAttributes = data;

                        return vm.templateAttributes;
                    });
                })
                .catch();
        }

        function pageChanged() {

        }

        function goToCreate() {
            $location.path('/templateAttribute/create').search('templateAttributeId', $routeParams.templateAttributeId)
                .search('itemTemplateId', $routeParams.itemTemplateId);
        }

    }

})();