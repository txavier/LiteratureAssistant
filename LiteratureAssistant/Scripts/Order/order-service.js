itemModule.factory("orderService", function ($resource, $http) {

    var baseUrl = "api/ordersApi";

    var resource = $resource(baseUrl);

    return {
        getOrders: function () {
            return resource.query({}, isArray = true);
        },
        getOrder: function (orderId) {
            return resource.get({ id: orderId })
        },
        saveOrder: function (order) {
            return resource.save(order);
        },
        deleteOrder: function (orderId) {
            return resource.delete({ id: orderId });
        },
    }
});