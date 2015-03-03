(function () {
    angular
        .module('app')
        .controller('addOrUpdateItemTemplatesController', addOrUpdateItemTemplatesController);

    addOrUpdateItemTemplatesController.$inject = ['$scope', '$log', '$location', '$routeParams', 'dataService'];

    function addOrUpdateItemTemplatesController($scope, $log, $location, $routeParams, dataService) {
        var vm = this;

        vm.itemTemplates = [];
        vm.itemTemplate = {};
        vm.getItemTemplates = getItemTemplates;
        vm.addOrUpdateItemTemplate = addOrUpdateItemTemplate;
        vm.organizationId = null;

        activate();

        function activate() {
            getItemTemplates();
            setView($routeParams);

            return vm;
        }

        function getItemTemplates() {
            return dataService.getItemTemplates().then(function (data) {
                vm.itemTemplates = data;

                return vm.itemTemplates;
            });
        }

        function setView($routeParams) {
            if ($routeParams.itemTemplateId) {
                getItemTemplate($routeParams.itemTemplateId);
            }
            
            if ($routeParams.organizationId) {
                vm.organizationId = $routeParams.organizationId;
            }
        }

        function getItemTemplate(itemTemplateId) {
            return dataService.getItemTemplate(itemTemplateId).then(function (data) {
                vm.itemTemplate = data;

                return vm.itemTemplate;
            });
        }

        function addOrUpdateItemTemplate() {
            if (vm.organizationId) {
                vm.itemTemplate.organizationId = vm.organizationId;
            }
            return dataService.addOrUpdateItemTemplate(vm.itemTemplate).then(function () {
                    $location.path('/itemTemplates');
                })
                .catch();
        }

        function deleteItemTemplate(itemTemplateId) {
            return dataService.deleteItemTemplate(itemTemplateId)
                .then()
                .catch();
        }
    }
})();