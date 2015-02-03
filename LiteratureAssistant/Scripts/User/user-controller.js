itemModule.controller("userController", function ($scope, $location, $routeParams, $http, userService) {

    // Cache was set to false in previous versions.  Does this still work ok?
    $scope.users = userService.getUsers();

    $scope.user = {};

    $scope.sendUser = function (user) {

        var newUser = userService.saveUser(user);

        newUser.$promise.then(function () {

            // Cache was set to false in previous versions.  Does this still work ok?
            $scope.users = userService.getUsers();

            $location.path("/user");
        });
    }

    // If there is a route parameter of an ItemId then we are editing and get the 
    // item from the web api get method.
    if ($routeParams.userId != null) {

        //var resultPromise = $http.get("api/usersApi/" + $routeParams.userId);

        //resultPromise.success(function (user) {

        //    $scope.user = user;
        //});

        userService.getUser($routeParams.userId).$promise.then(function (user) {
            $scope.user = user;
        });
    }

    $scope.deleteUser = function (userId) {
        userService.deleteUser(userId).$promise.then(function () {
            $scope.users = userService.getUsers();
        });
    }
});