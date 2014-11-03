itemModule.factory("orderService", function ($resource, $http) {

    var baseUrl = "api/ordersApi";

    return {
        getOrders: $resource(baseUrl).query({}, isArray = true),
        getOrder: function (orderId) {
            return $resource(baseUrl).get({ id: orderId })
        },
        saveOrder: function (order) {
            return $resource(baseUrl).save(order);
        },
        deleteOrder: function (orderId) {
            return $resource(baseUrl).delete({ id: orderId });
        },
    }
});