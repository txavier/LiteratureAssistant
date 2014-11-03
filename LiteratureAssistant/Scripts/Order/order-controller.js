itemModule.controller("orderController", function ($scope, $location, $routeParams, $http, orderService, userService, itemService) {

    $scope.orders = orderService.getOrders;

    $scope.users = userService.getUsers.query({ method: 'Get', cache: false }, isArray = true);

    $scope.items = itemService.getItems.query({}, isArray = true);

    if ($routeParams.orderId != null) {

        $scope.order = orderService.getOrder($routeParams.orderId);
    }
    else {
        $scope.order = { orderId: 0 };
    }


    $scope.sendOrder = function (order) {

        var newOrder = orderService.saveOrder(order);

        history.back();
    }

    $scope.open = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.opened = true;
    };

    $scope.deleteOrder = function (orderId) {
        //userService.getOrders.delete({ id: orderId });

        //// Reload the user template with the latest data.
        //$scope.users = userService.getUsers.query({ method: 'Get', cache: false }, isArray = true);

        //$location.path("/user");

        orderService.deleteOrder(orderId);
    }
});
