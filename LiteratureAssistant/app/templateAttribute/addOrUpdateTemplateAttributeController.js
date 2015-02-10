﻿(function () {
    angular
        .module('itemModule')
        .controller('addOrUpdateTemplateAttributeController', addOrUpdateTemplateAttributeController);

    addOrUpdateTemplateAttributeController.$inject = ['$scope', '$log', '$routeParams', 'dataService'];

    function addOrUpdateTemplateAttributeController($scope, $log, $routeParams, dataService) {
        var vm = this;

        vm.templateAttributes = [];
        vm.templateAttribute = {};
        vm.getTemplateAttribute = getTemplateAttribute;
        vm.addOrUpdateTemplateAttribute = addOrUpdateTemplateAttribute;

        activate();

        function activate() {
            getTemplateAttribute($routeParams.templateAttributeId);
            setNewTemplateAttribute($routeParams.itemTemplateId);

            return vm;
        }

        function setNewTemplateAttribute(itemTemplateId) {
            if (itemTemplateId) {
                vm.templateAttribute.itemTemplateId = itemTemplateId;
            }
        }

        function getTemplateAttribute(templateAttributeId) {
            if (templateAttributeId) {
                return dataService.getTemplateAttribute(templateAttributeId).then(function (data) {
                    vm.templateAttribute = data;

                    return vm.templateAttribute;
                });
            }
        }

        function addOrUpdateTemplateAttribute() {
            return dataService.addOrUpdateTemplateAttribute(vm.templateAttribute)
                .then($location.path('/templateAttributes'))
                .catch();
        }

        function deleteTemplateAttribute(templateAttributeId) {
            return dataService.deleteTemplateAttribute(templateAttributeId)
                .then()
                .catch();
        }

    }

})();