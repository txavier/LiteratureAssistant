(function () {
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
            getItemTemplates: getItemTemplates,
            getItemTemplatesCount: getItemTemplatesCount,
            addOrUpdateItemTemplate: addOrUpdateItemTemplate,
            getTemplateAttributes: getTemplateAttributes,
            getTemplateAttributesCount: getTemplateAttributesCount,
            addOrUpdateTemplateAttribute: addOrUpdateTemplateAttribute,
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

        function addOrUpdateItemTemplate(itemTemplate) {
            return $http.post(itemTemplateApiUrl, itemTemplate)
                    .then(addOrUpdateItemTemplateComplete)
                    .catch(addOrUpdateItemTemplateFailed);

            function addOrUpdateItemTemplateComplete(response) {
                return response.data;
            }

            function addOrUpdateItemTemplateFailed(error) {
                $log.error('XHR Failed for getOrganizations.' + error.data);
            }
        }

        function getTemplateAttributes(templateAttributeId, itemTemplateId) {
            return $resource(templateAttributeApiUrl).query({ templateAttributeId: templateAttributeId || '-1', itemTemplateId: itemTemplateId || '-1' });
        }

        function getTemplateAttributesCount(templateAttributeId, itemTemplateId) {
            return $resource(templateAttributeApiUrl + '/count').query({ templateAttributeId: templateAttributeId || '-1', itemTemplateId: itemTemplateId || '-1' });
        }

        function addOrUpdateTemplateAttribute(templateAttribute) {
            return $http.post(templateAttributeApiUrl, templateAttribute)
                    .then(addOrUpdateTemplateAttributeComplete)
                    .catch(addOrUpdateTemplateAttributeFailed);

            function addOrUpdateTemplateAttributeComplete(response) {
                return response.data;
            }

            function addOrUpdateTemplateAttributeFailed(error) {
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