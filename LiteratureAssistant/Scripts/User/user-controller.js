itemModule.controller("userController", function ($scope, userService) {

    $scope.users = userService.getUsers.query({}, isArray = true);

    $scope.sendUser = function () {

        var newUser = userService.getUsers.save({ user: $scope.user });

        $location.path("/user");
    }
});