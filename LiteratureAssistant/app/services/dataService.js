﻿(function () {
    'use strict';

    angular
       .module('itemModule')
       .factory('dataService', dataService);

    dataService.$inject = ['$http', '$log', '$resource', '$q'];

    function dataService($http, $log, $resource, $q) {

        var organizationApiUrl = '/api/organizationApi';
        var itemAttributeApiUrl = '/api/itemAttributesApi';
        var itemApiUrl = '/api/itemsApi';
        var templateAttributeApiUrl = '/api/templateAttributesApi';
        var itemTemplateApiUrl = '/api/itemTemplatesApi';

        var service = {
            getOrganizations: getOrganizations,
            getOrganizationsCount: getOrganizationsCount,
            addOrUpdateOrganization: addOrUpdateOrganization,
            getItemAttributes: getItemAttributes,
            getItemAttributesCount: getItemAttributesCount,
            addOrUpdateItemAttribute: addOrUpdateItemAttribute,
            getItems: getItems,
            getTemplateAttributes: getTemplateAttributes,
            getItemTemplates: getItemTemplates,
            getItemTemplatesCount: getItemTemplatesCount,
        };

        return service;

        function getItemTemplates() {
            return $http.get(itemTemplateApiUrl)
                .then(getItemTemplatesComplete)
                .catch(getItemTemplatesFailed);

            function getItemTemplatesComplete(response) {
                return response.data;
            }

            function getItemTemplatesFailed(error) {
                $log.error('XHR Failed for getItemTemplates.' + error.data);
            }
        }

        function getItemTemplatesCount() {
            return $http.get(itemTemplateApiUrl + '/count')
                .then(getItemTemplatesCountComplete)
                .catch(getItemTemplatesCountFailed);

            function getItemTemplatesCountComplete(response) {
                return response.data;
            }

            function getItemTemplatesCountFailed(error) {
                $log.error('XHR Failed for getOrganizationsCount.' + error.data);
            }
        }

        function getTemplateAttributes() {
            return $http.get(templateAttributeApiUrl)
                .then(getTemplateAttributesComplete)
                .catch(getTemplateAttributesFailed);

            function getTemplateAttributesComplete(response) {
                return response.data;
            }

            function getTemplateAttributesFailed(error) {
                $log.error('XHR Failed for getTemplateAttributes.' + error.data);
            }
        }

        function getItems() {
            return $http.get(itemApiUrl)
                .then(getItemsComplete)
                .catch(getItemsFailed);

            function getItemsComplete(response) {
                return response.data;
            }

            function getItemsFailed(error) {
                $log.error('XHR Failed for getItems.' + error.data);
            }
        }

        function getOrganizations() {
            return $http.get(organizationApiUrl)
                .then(getOrganizationsComplete)
                .catch(getOrganizationsFailed);

            function getOrganizationsComplete(response) {
                return response.data;
            }

            function getOrganizationsFailed(error) {
                $log.error('XHR Failed for getOrganizations.' + error.data);
            }
        }

        function getOrganizationsCount() {
            return $http.get(organizationApiUrl + '/count')
                .then(getOrganizationsCountComplete)
                .catch(getOrganizationsCountFailed);

            function getOrganizationsCountComplete(response) {
                return response.data;
            }

            function getOrganizationsCountFailed(error) {
                $log.error('XHR Failed for getOrganizationsCount.' + error.data);
            }
        }

        function addOrUpdateOrganization(organization) {
            return $http.post(organizationApiUrl, organization)
                    .then(addOrUpdateOrganizationComplete)
                    .catch(addOrUpdateOrganizationFailed);

            function addOrUpdateOrganizationComplete(response) {
                return response.data;
            }

            function addOrUpdateOrganizationFailed(error) {
                $log.error('XHR Failed for getOrganizations.' + error.data);
            }
        }

        function getItemAttributes() {
            return $http.get(itemAttributeApiUrl)
                .then(getItemAttributesComplete)
                .catch(getItemAttributesFailed);

            function getItemAttributesComplete(response) {
                return response.data;
            }

            function getItemAttributesFailed(error) {
                $log.error('XHR Failed for getItemAttributes.' + error.data);
            }
        }

        function getItemAttributesCount() {
            return $http.get(itemAttributeApiUrl + '/count')
                .then(getItemAttributesCountComplete)
                .catch(getItemAttributesCountFailed);

            function getItemAttributesCountComplete(response) {
                return response.data;
            }

            function getItemAttributesCountFailed(error) {
                $log.error('XHR Failed for getItemAttributesCount.' + error.data);
            }
        }

        function addOrUpdateItemAttribute(itemAttribute) {
            return $http.post(itemAttributeApiUrl, itemAttribute)
                    .then(addOrUpdateItemAttributeComplete)
                    .catch(addOrUpdateItemAttributeFailed);

            function addOrUpdateItemAttributeComplete(response) {
                return response.data;
            }

            function addOrUpdateItemAttributeFailed(error) {
                $log.error('XHR Failed for getItemAttributes.' + error.data);
            }
        }
    }

})();