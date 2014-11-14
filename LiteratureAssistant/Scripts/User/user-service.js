itemModule.factory("userService", function ($resource, $http) {

    var baseUrl = "api/usersApi/";

    var resource = $resource(baseUrl);

    return {
        getUsers: function () {
            return resource.query({}, isArray = true);
        },
        getUser: function (userId) {
            return resource.get({ id: userId });
        },
        saveUser: function (user) {
            return resource.save({ user: user });
        },
        deleteUser: function (userId) {
            return resource.delete({ id: userId });
        },
    };
});