(function () {
    angular
        .module('itemModule')
        .controller('organizationController', organizationController);

    organizationController.$inject = ['$scope', '$log', 'dataService'];

    function organizationController($scope, $log, dataService) {
        var vm = this;

        vm.organizations = [];
        vm.organization = {};
        vm.getOrganizations = getOrganizations;
        vm.saveOrganization = saveOrganization;

        activate();

        function activate() {
            getOrganizations();

            return vm;
        }

        function getOrganizations() {
            return dataService.getOrganizations().then(function (data) {
                vm.organizations = data;

                return vm.organizations;
            });
        }

        function saveOrganization() {
            dataService.saveOrganization(vm.organization)
                .then()
                .catch();
        }

    }

})();