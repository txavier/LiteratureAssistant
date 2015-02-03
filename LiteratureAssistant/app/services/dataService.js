(function () {
    'use strict';

    angular
       .module('itemModule')
       .factory('dataService', dataService);

    dataService.$inject = ['$http', '$log', '$resource', '$q'];

    function dataService($http, $log, $resource, $q) {

        var service = {
            getOrganizations: getOrganizations,
            saveOrganization: saveOrganization,
        };

        return service;

        function getOrganizations() {
            return $http.get('/api/organizationApi')
                .then(getOrganizationsComplete)
                .catch(getOrganizationsFailed);

            function getOrganizationsComplete(response) {
                return response.data;
            }

            function getOrganizationsFailed(error) {
                $log.error('XHR Failed for getOrganizations.' + error.data);
            }
        }

        function saveOrganization(organization) {
            return $http.post('/api/organizationApi', organization)
                    .then(saveOrganizationComplete)
                    .catch(saveOrganizationFailed);

            function saveOrganizationComplete(response) {
                return response.data;
            }

            function saveOrganizationFailed(error) {
                $log.error('XHR Failed for getOrganizations.' + error.data);
            }
        }
    }

})();