(function () {
    angular
        .module('app')
        .controller('addOrUpdateUserController', addOrUpdateUserController);

    addOrUpdateUserController.$inject = ['$scope', '$location', '$routeParams', '$http', 'dataService'];

    function addOrUpdateUserController($scope, $location, $routeParams, $http, dataService) {
        var vm = this;

        vm.users = [];
        vm.user = {};
        vm.sendUser = sendUser;
        vm.deleteUser = deleteUser;

        activate();

        function activate() {
            getUsers();
            getUser();

            return vm;
        }

        function getUsers() {
            return dataService.getUsers().$promise.then(function (data) {
                vm.users = data;

                return vm.users;
            });
        }

        function sendUser(user) {
            return dataService.saveUser(user).$promise.then(function () {
                $location.path("/user");
            });
        }

        // If there is a route parameter of an ItemId then we are editing and get the
        // item from the web api get method.
        function getUser() {
            if ($routeParams.userId != null) {
                dataService.getUser($routeParams.userId).$promise.then(function (user) {
                    vm.user = user;
                });
            }
        }

        function deleteUser(userId) {
            userService.deleteUser(userId).$promise.then(function () {
                vm.users = userService.getUsers();
            });
        }
    }
})();