var itemModule = angular.module("itemModule", ['ngRoute', 'ngResource', 'ui.bootstrap']).
    config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/item', { templateUrl: 'templates/items.html', controller: 'itemController' })
            .when('/item/edit/:itemId', { templateUrl: 'templates/editItem.html', controller: 'addOrUpdateItemController' })
            .when('/item/create', { templateUrl: 'templates/createItem.html', controller: 'addOrUpdateItemController' })
            .when('/user', { templateUrl: 'templates/users.html', controller: 'userController' })
            .when('/user/create', { templateUrl: 'templates/createUser.html', controller: 'userController' })
            .when('/user/edit/:userId', { templateUrl: 'templates/editUser.html', controller: 'userController' })
            .when('/order', { templateUrl: 'templates/orders.html', controller: 'orderController' })
            .when('/order/create', { templateUrl: 'templates/createOrder.html', controller: 'orderController' })
            .when('/order/edit/:orderId', { templateUrl: 'templates/createOrder.html', controller: 'orderController' })
            .when('/count', { templateUrl: 'templates/counts.html', controller: 'countController' })
            .when('/count/create/:itemId', { templateUrl: 'templates/createCount.html', controller: 'countController' })
            .when('/count/edit/:countId', { templateUrl: 'templates/createCount.html', controller: 'countController' })
            .when('/count/create/barcodeAdd/:itemId', { templateUrl: 'app/templates/createCountBarcodeAdd.html', controller: 'createCountBarcodeAddController', controllerAs: 'vm' })
            .when('/count/create/barcodeSubtract/:itemId', { templateUrl: 'app/templates/createCountBarcodeSubtract.html', controller: 'createCountBarcodeSubtractController', controllerAs: 'vm' })
            .when('/organization/create', { templateUrl: 'app/templates/addOrUpdateOrganization.html', controller: 'addOrUpdateOrganizationController', controllerAs: 'vm' })
            .when('/organization/update/:organizationId', { templateUrl: 'app/templates/addOrUpdateOrganization.html', controller: 'addOrUpdateOrganizationController', controllerAs: 'vm' })
            .when('/organizations', { templateUrl: 'app/templates/organizations.html', controller: 'organizationsController', controllerAs: 'vm' })
            .when('/organization/:organizationId', { templateUrl: 'app/templates/organization.html', controller: 'organizationController', controllerAs: 'vm' })
            .when('/itemAttribute/create', { templateUrl: 'app/templates/addOrUpdateItemAttribute.html', controller: 'addOrUpdateItemAttributesController', controllerAs: 'vm' })
            .when('/itemAttribute/update/:itemAttributeId', { templateUrl: 'app/templates/addOrUpdateItemAttribute.html', controller: 'addOrUpdateItemAttributesController', controllerAs: 'vm' })
            .when('/itemAttributes', { templateUrl: 'app/templates/itemAttributes.html', controller: 'itemAttributesController', controllerAs: 'vm' })
            .when('/itemAttribute/:itemAttributeId', { templateUrl: 'app/templates/itemAttribute.html', controller: 'itemAttributesController', controllerAs: 'vm' })
            .when('/itemTemplate/create', { templateUrl: 'app/templates/addOrUpdateItemTemplate.html', controller: 'addOrUpdateItemTemplatesController', controllerAs: 'vm' })
            .when('/itemTemplate/update/:itemTemplateId', { templateUrl: 'app/templates/addOrUpdateItemTemplate.html', controller: 'addOrUpdateItemTemplatesController', controllerAs: 'vm' })
            .when('/itemTemplates', { templateUrl: 'app/templates/itemTemplates.html', controller: 'itemTemplatesController', controllerAs: 'vm' })
            .when('/itemTemplate/:itemTemplateId', { templateUrl: 'app/templates/itemTemplate.html', controller: 'itemTemplatesController', controllerAs: 'vm' })
            .when('/templateAttribute', {
                templateUrl: 'app/templates/templateAttributes.html',
                controller: 'templateAttributesController',
                controllerAs: 'vm'
            })
            .when('/templateAttribute/create', {
                templateUrl: 'app/templates/addOrUpdateTemplateAttribute.html',
                controller: 'addOrUpdateTemplateAttributeController',
                controllerAs: 'vm'
            })
            .when('/templateAttribute/update/:templateAttributeId', {
                templateUrl: 'app/templates/addOrUpdateTemplateAttribute.html',
                controller: 'addOrUpdateTemplateAttributeController',
                controllerAs: 'vm'
            })
            .when('/count/barcodes/:itemId', {
                templateUrl: 'app/templates/barcodes.html', 
                controller: 'barcodesController',
                controllerAs: 'vm'
            });
        //$locationProvider.html5Mode(true);
    });