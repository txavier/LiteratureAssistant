(function () {
    angular
        .module('itemModule')
        .controller('organizationsController', organizationsController);

    organizationsController.$inject = ['$scope', '$log', 'dataService'];

    function organizationsController($scope, $log, dataService) {
        var vm = this;

        vm.organizations = {};
        vm.getOrganizations = getOrganizations;
        vm.deleteOrganization = deleteOrganization;
        vm.totalItems = 0;
        vm.itemsPerPage = 10;
        vm.currentPage = 1;
        vm.pageChanged = pageChanged;

        activate();

        function activate() {
            getOrganizations();
            getOrganizationsCount();

            return vm;
        }

        function getOrganizations() {
            return dataService.getOrganizations().then(function (data) {
                vm.organizations = data;

                return vm.organizations;
            });
        }

        function deleteOrganization(organizationId) {
            return dataService.deleteOrganization(organizationId)
                .then(function (data) {
                    vm.organizations = dataService.getOrganizations().then(function (data) {
                        vm.organizations = data;

                        return vm.organizations;
                    });
                })
                .catch();
        }

        function getOrganizationsCount() {
            return dataService.getOrganizationsCount().then(function (data) {
                vm.totalItems = data || 0;

                return vm.totalItems;
            });
        }

        function pageChanged() {

        }

    }

})();