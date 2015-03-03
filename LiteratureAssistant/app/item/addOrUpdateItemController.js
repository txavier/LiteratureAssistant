// This used to be the old template-attribute-controller before the angular was refactored.  This
// may still have remnants for template attribute operations although they no longer are needed
// and no longer work.
(function () {
    angular
        .module('app')
        .controller('addOrUpdateItemController', addOrUpdateItemController);

    addOrUpdateItemController.$inject = ['$scope', '$routeParams', '$http', '$route', '$templateCache', '$location', 'dataService'];

    function addOrUpdateItemController($scope, $routeParams, $http, $route, $templateCache, $location, dataService) {
        var vm = this;

        vm.templateAttributes = [];
        vm.formData = {};
        vm.templateAttribute = {};
        vm.addOrUpdateTemplateAttribute = addOrUpdateTemplateAttribute;
        vm.addItem = addItem;
        vm.updateItem = updateItem;
        var log = [];

        activate();

        function activate() {
            getTemplateAttributes();
            setView($routeParams);

            return vm;
        }

        function getTemplateAttributes(itemTemplateId) {
            if (itemTemplateId != null) {
                return dataService.getTemplateAttributes(null, itemTemplateId).$promise.then(function (data) {
                    vm.templateAttributes = data;
                });
            }
        }

        function getTemplateAttributes() {
            return dataService.getTemplateAttributes().$promise.then(function(data) {
                vm.templateAttributes = data;

                return vm;
            });
        }

        function setView($routeParams) {
            if ($routeParams.templateAttributeId != null) {
                getTemplateAttribute($routeParams.templateAttributeId);
            }
            else {
                setNewTemplateAttribute();
            }

            if ($routeParams.itemTemplateId) {
                getTemplateAttributes($routeParams.itemTemplateId);
            }

            if ($routeParams.itemId) {
                getItem($routeParams.itemId);
            }
        }

        // Get single template attribute.
        function getTemplateAttribute(templateAttributeId) {
            if (templateAttributeId != null) {
                dataService.getTemplateAttributeService(templateAttributeId).$promise.then(function (data) {
                    vm.templateAttribute = data;
                });
            }
        }

        function setNewTemplateAttribute() {
            vm.templateAttribute = { templateAttributeId: 0 };
        }

        // If there is a route parameter of an ItemId then we are editing and get the
        // item from the web api get method.
        function getItem(itemId) {
            if (itemId != null) {
                return dataService.getItem(itemId).then(function (data) {
                    vm.item = data;

                    angular.forEach(vm.item.itemAttributes, function (itemAttribute, key) {
                        vm.formData[itemAttribute.templateAttribute.templateAttributeName] = itemAttribute.value;
                    }, log);
                });
            }
        }

        // Save or update a template attribute.
        function addOrUpdateTemplateAttribute(templateAttribute) {
            dataService.addOrUpdateTemplateAttribute(templateAttribute).then(function () {
                history.back();
            });
        }

        // Save or update an item.
        function addItem() {
            var itemAttributes = vm.formData;

            var item = { item: { itemAttributes: itemAttributes } };

            dataService.addOrUpdateItem(item).then(function (data) {
                $location.path("/item");
            });
        }

        function updateItem(item) {
            var itemAttributes = vm.formData;

            var updatedItem = { item: { itemId: vm.item.itemId, itemAttributes: itemAttributes } };

            dataService.addOrUpdateItem(updatedItem).then(function (data) {
                $location.path("/item");
            });
        }

        // Delete a template attribute.
        function deleteTemplateAttribute(templateAttributeId) {
            dataService.deleteTemplateAttribute(templateAttributeId).$promise.then(function () {
                vm.templateAttributes = dataService.getTemplateAttributes();
            });
        }
    }
})();