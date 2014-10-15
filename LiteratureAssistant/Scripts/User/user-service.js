itemModule.factory("userService", function ($resource, $http) {

    var baseUrl = "api/usersApi/";

    return {
        getUsers: $resource("api/usersApi"),
    };
});