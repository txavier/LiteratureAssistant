(function () {
    angular
        .module('app')
        .controller('addOrUpdateOrganizationController', addOrUpdateOrganizationController);

    addOrUpdateOrganizationController.$inject = ['$scope', '$log', 'dataService'];

    function addOrUpdateOrganizationController($scope, $log, dataService) {
        var vm = this;

        vm.organizations = [];
        vm.organization = {};
        vm.getOrganizations = getOrganizations;
        vm.addOrUpdateOrganization = addOrUpdateOrganization;

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

        function getOrganization(organizationId) {
            return dataService.getOrganization(organizationId).then(function (data) {
                vm.organization = data;

                return vm.organization;
            });
        }

        function addOrUpdateOrganization() {
            return dataService.addOrUpdateOrganization(vm.organization)
                .then()
                .catch();
        }

        function deleteOrganization(organizationId) {
            return dataService.deleteOrganization(organizationId)
                .then()
                .catch();
        }

    }

})();