angular
    .module('app', [
        'ngRoute',
        'ngResource',
        'ui.bootstrap',
        'shared.directives'
    ]);

angular
    .module('app')
    .config(config);

function config($routeProvider, $locationProvider) {
    $routeProvider
        .when('/item', {
            templateUrl: 'app/templates/items.html',
            controller: 'itemsController',
            controllerAs: 'vm'
        })
        .when('/item/update/:itemId', {
            templateUrl: 'app/templates/updateItem.html',
            controller: 'addOrUpdateItemController',
            controllerAs: 'vm'
        })
        .when('/item/add', {
            templateUrl: 'app/templates/addItem.html',
            controller: 'addOrUpdateItemController',
            controllerAs: 'vm'
        })
        .when('/user', {
            templateUrl: 'app/templates/users.html',
            controller: 'addOrUpdateUserController',
            controllerAs: 'vm'
        })
        .when('/user/add', {
            templateUrl: 'app/templates/addUser.html',
            controller: 'addOrUpdateUserController',
            controllerAs: 'vm'
        })
        .when('/user/update/:userId', {
            templateUrl: 'app/templates/updateUser.html',
            controller: 'addOrUpdateUserController',
            controllerAs: 'vm'
        })
        .when('/order', {
            templateUrl: 'app/templates/orders.html',
            controller: 'ordersController',
            controllerAs: 'vm'
        })
        .when('/order/add', {
            templateUrl: 'app/templates/addOrUpdateOrder.html',
            controller: 'addOrUpdateOrderController',
            controllerAs: 'vm'
        })
        .when('/order/update/:orderId', {
            templateUrl: 'app/templates/addOrUpdateOrder.html',
            controller: 'addOrUpdateOrderController',
            controllerAs: 'vm'
        })
        .when('/count', {
            templateUrl: 'app/templates/counts.html',
            controller: 'countsController',
            controllerAs: 'vm'
        })
        .when('/count/create/:itemId', {
            templateUrl: 'app/templates/addOrUpdateCount.html',
            controller: 'addOrUpdateCountController',
            controllerAs: 'vm'
        })
        .when('/count/update/:countId', {
            templateUrl: 'app/templates/addOrUpdateCount.html',
            controller: 'addOrUpdateCountController',
            controllerAs: 'vm'
        })
        .when('/count/create/barcodeAdd/:itemId', {
            templateUrl: 'app/templates/createCountBarcodeAdd.html',
            controller: 'createCountBarcodeAddController',
            controllerAs: 'vm'
        })
        .when('/count/create/barcodeSubtract/:itemId', {
            templateUrl: 'app/templates/createCountBarcodeSubtract.html',
            controller: 'createCountBarcodeSubtractController',
            controllerAs: 'vm'
        })
        .when('/organization/create', {
            templateUrl: 'app/templates/addOrUpdateOrganization.html',
            controller: 'addOrUpdateOrganizationController',
            controllerAs: 'vm'
        })
        .when('/organization/update/:organizationId', {
            templateUrl: 'app/templates/addOrUpdateOrganization.html',
            controller: 'addOrUpdateOrganizationController',
            controllerAs: 'vm'
        })
        .when('/organizations', {
            templateUrl: 'app/templates/organizations.html',
            controller: 'organizationsController',
            controllerAs: 'vm'
        })
        .when('/organization/:organizationId', {
            templateUrl: 'app/templates/organization.html',
            controller: 'organizationController',
            controllerAs: 'vm'
        })
        .when('/itemAttribute/create', {
            templateUrl: 'app/templates/addOrUpdateItemAttribute.html',
            controller: 'addOrUpdateItemAttributesController',
            controllerAs: 'vm'
        })
        .when('/itemAttribute/update/:itemAttributeId', {
            templateUrl: 'app/templates/addOrUpdateItemAttribute.html',
            controller: 'addOrUpdateItemAttributesController',
            controllerAs: 'vm'
        })
        .when('/itemAttributes', {
            templateUrl: 'app/templates/itemAttributes.html',
            controller: 'itemAttributesController',
            controllerAs: 'vm'
        })
        .when('/itemAttribute/:itemAttributeId', {
            templateUrl: 'app/templates/itemAttribute.html',
            controller: 'itemAttributesController',
            controllerAs: 'vm'
        })
        .when('/itemTemplate/add/:organizationId', {
            templateUrl: 'app/templates/addOrUpdateItemTemplate.html',
            controller: 'addOrUpdateItemTemplatesController',
            controllerAs: 'vm'
        })
        .when('/itemTemplate/update/:itemTemplateId', {
            templateUrl: 'app/templates/addOrUpdateItemTemplate.html',
            controller: 'addOrUpdateItemTemplatesController',
            controllerAs: 'vm'
        })
        .when('/itemTemplates', {
            templateUrl: 'app/templates/itemTemplates.html',
            controller: 'itemTemplatesController',
            controllerAs: 'vm'
        })
        .when('/itemTemplate/:itemTemplateId', {
            templateUrl: 'app/templates/itemTemplate.html',
            controller: 'itemTemplatesController',
            controllerAs: 'vm'
        })
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
        })
        .otherwise({ redirectTo: '/' });

}