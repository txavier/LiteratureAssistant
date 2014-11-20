itemModule.controller("orderController", function ($scope, $location, $routeParams, $http, orderService, userService, itemService) {

    $scope.orders = orderService.getOrders();

    // Cache was set to false previously.
    $scope.users = userService.getUsers();

    $scope.items = itemService.getItems();

    if ($routeParams.orderId != null) {

        orderService.getOrder($routeParams.orderId).$promise.then(function (order) {
            $scope.order = order;
        });
    }
    else {
        $scope.order = { orderId: 0 };
    }


    $scope.sendOrder = function (order) {

        orderService.saveOrder(order).$promise.then(function() {
            $scope.orders = orderService.getOrders();

            $location.path("/order");
        });
    }

    $scope.open = function ($event) {
        $event.preventDefault();

        $event.stopPropagation();

        $scope.opened = true;
    };

    $scope.deleteOrder = function (orderId) {
        orderService.deleteOrder(orderId).$promise.then(function () {
            $scope.orders = orderService.getOrders();

            $location.path("/order");
        });
    }
});
