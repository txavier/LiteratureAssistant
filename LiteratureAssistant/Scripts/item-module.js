﻿var itemModule = angular.module("itemModule", ['ngRoute', 'ngResource', 'ui.bootstrap']).
    config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/item', { templateUrl: 'templates/items.html', controller: 'itemController' })
            .when('/item/edit/:itemId', { templateUrl: 'templates/editItem.html', controller: 'templateAttributeController' })
            .when('/item/create', { templateUrl: 'templates/createItem.html', controller: 'templateAttributeController' })
            .when('/user', { templateUrl: 'templates/users.html', controller: 'userController' })
            .when('/user/create', { templateUrl: 'templates/createUser.html', controller: 'userController' })
            .when('/user/edit/:userId', { templateUrl: 'templates/editUser.html', controller: 'userController' })
            .when('/order', { templateUrl: 'templates/orders.html', controller: 'orderController' })
            .when('/order/create', { templateUrl: 'templates/createOrder.html', controller: 'orderController' })
            .when('/order/edit/:orderId', { templateUrl: 'templates/createOrder.html', controller: 'orderController' })
            .when('/count', { templateUrl: 'templates/counts.html', controller: 'countController' })
            .when('/count/create', { templateUrl: 'templates/createCount.html', controller: 'countController' })
            .when('/count/edit/:countId', { templateUrl: 'templates/createCount.html', controller: 'countController' })
            .when('/templateAttribute', { templateUrl: 'templates/templateAttributes.html', controller: 'templateAttributeController' })
            .when('/templateAttribute/create', { templateUrl: 'templates/createTemplateAttribute.html', controller: 'templateAttributeController' })
            .when('/templateAttribute/edit/:templateAttributeId', { templateUrl: 'templates/createTemplateAttribute.html', controller: 'templateAttributeController' })
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
            .when('/itemTemplate/:itemTemplateId', { templateUrl: 'app/templates/itemTemplate.html', controller: 'itemTemplatesController', controllerAs: 'vm' });
        //$locationProvider.html5Mode(true);
    });