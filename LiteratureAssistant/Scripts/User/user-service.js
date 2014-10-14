itemModule.factory("userService", function ($resource) {
    return {
        getUsers: $resource("api/usersApi")
    };
});