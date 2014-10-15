itemModule.controller("userController", function ($scope, $location, $routeParams, $http, userService) {

    $scope.users = userService.getUsers.query({ method: 'Get', cache: false }, isArray = true);

    $scope.sendUser = function () {

        var newUser = userService.getUsers.save({ user: $scope.user });

        newUser.$promise.then(function () {

            $scope.users = userService.getUsers.query({ method: 'Get', cache: false }, isArray = true);

            $location.path("/user");
        });
    }

    // If there is a route parameter of an ItemId then we are editing and get the 
    // item from the web api get method.
    if ($routeParams.userId != null) {

        var resultPromise = $http.get("api/usersApi/" + $routeParams.userId);

        resultPromise.success(function (user) {

            $scope.user = user;
        });
    }

    $scope.deleteUser = function (userId) {
        userService.getUsers.delete({ id: userId });

        // Reload the user template with the latest data.
        $scope.users = userService.getUsers.query({ method: 'Get', cache: false }, isArray = true);

        $location.path("/user");
    }
});