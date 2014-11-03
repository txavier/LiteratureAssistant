var itemModule = angular.module("itemModule", ['ngRoute', 'ngResource', 'ui.bootstrap']).
    config(function($routeProvider, $locationProvider) {
        $routeProvider
            .when('/item', { templateUrl: 'templates/items.html', controller: 'itemController' })
            .when('/item/edit/:itemId', { templateUrl: 'templates/editItem.html', controller: 'templateAttributeController' })
            .when('/item/create', { templateUrl: 'templates/createItem.html', controller: 'templateAttributeController' })
            .when('/user', { templateUrl: 'templates/users.html', controller: 'userController' })
            .when('/user/create', { templateUrl: 'templates/createUser.html', controller: 'userController' })
            .when('/user/edit/:userId', { templateUrl: 'templates/editUser.html', controller: 'userController' })
            .when('/order', { templateUrl: 'templates/orders.html', controller: 'orderController' })
            .when('/order/create', { templateUrl: 'templates/createOrder.html', controller: 'orderController' })
            .when('/order/edit/:orderId', { templateUrl: 'templates/createOrder.html', controller: 'orderController' });;
        //$locationProvider.html5Mode(true);
    });