(function () {
    'use strict';

    angular
       .module('app')
       .factory('dataService', dataService);

    dataService.$inject = ['$http', '$log', '$resource', '$q'];

    function dataService($http, $log, $resource, $q) {

        var organizationApiUrl = '/api/organizationApi';
        var itemAttributeApiUrl = '/api/itemAttributesApi';
        var itemApiUrl = '/api/itemsApi';
        var templateAttributeApiUrl = '/api/templateAttributesApi';
        var itemTemplateApiUrl = '/api/itemTemplatesApi';
        var countApiUrl = '/api/countsApi';
        var userApiUrl = 'api/usersApi/';
        var orderApiUrl = 'api/ordersApi/';

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
            getTemplateAttribute: getTemplateAttribute,
            getTemplateAttributes: getTemplateAttributes,
            getTemplateAttributesCount: getTemplateAttributesCount,
            addOrUpdateTemplateAttribute: addOrUpdateTemplateAttribute,
            getNewCount: getNewCount,
            getBarcodes: getBarcodes,
            getUsers: getUsers,
            addOrUpdateUser: addOrUpdateUser,
            getUser: getUser,
            deleteUser: deleteUser,
            getOrder: getOrder,
            getOrders: getOrders,
            addOrUpdateOrder: addOrUpdateOrder,
            deleteOrder: deleteOrder
        };

        return service;

        function getOrders() {
            return $resource(orderApiUrl).query({});
        }

        function getOrder(orderId) {
            return $resource(orderApiUrl).get({ id: orderId });
        }

        function addOrUpdateOrder(order) {
            return $resource(orderApiUrl).save(order);
        }

        function deleteOrder(orderId) {
            return $resource(orderApiUrl).delete({ id: orderId });
        }

        function getUsers() {
            return $resource(userApiUrl).query({ });
        }

        function getUser(userId) {
            return $resource(userApiUrl).get({ id: userId });
        }

        function addOrUpdateUser(user) {
            return $resource(userApiUrl).save(user);
        }

        function deleteUser(userid) {
            return $resource(userApiUrl).delete({ id: userId });
        }

        function getBarcodes(itemId) {
            return $http.get(itemApiUrl + '/getbarcodes/' + itemId)
                        .then(getBarcodesComplete)
                        .catch(getBarcodesFailed);

            function getBarcodesComplete(response) {
                return response.data;
            }

            function getBarcodesFailed(error) {
                $log.error('XHR failed for getBarcodes.' + error.data.message + ': ' + error.data.messageDetail);
            }
        }

        function getItemTemplates() {
            return $http.get(itemTemplateApiUrl)
                .then(getItemTemplatesComplete)
                .catch(getItemTemplatesFailed);

            function getItemTemplatesComplete(response) {
                return response.data;
            }

            function getItemTemplatesFailed(error) {
                $log.error('XHR Failed for getItemTemplates.' + error.data.message + ': ' + error.data.messageDetail);
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
                $log.error('XHR Failed for getOrganizationsCount.' + error.data.message + ': ' + error.data.messageDetail);
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
                $log.error('XHR Failed for getOrganizations.' + error.data.message + ': ' + error.data.messageDetail);
            }
        }

        function getNewCount(itemId) {
            return $http.get(countApiUrl + '/newCount/' + itemId)
                .then(getNewCountComplete)
                .catch(getNewCountFailed);

            function getNewCountComplete(response) {
                return response.data;
            }

            function getNewCountFailed(error) {
                $log.error('XHR Failed for getNewCount.' + error.data.message + ': ' + error.data.messageDetail);
            }
        }

        function getTemplateAttribute(templateAttributeId) {
            return $resource(templateAttributeApiUrl).get({ id: templateAttributeId });
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
                $log.error('XHR Failed for getTemplateAttributes.' + error.data.message + ': ' + error.data.messageDetail);
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
                $log.error('XHR Failed for getItems.' + error.data.message + ': ' + error.data.messageDetail);
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
                $log.error('XHR Failed for getOrganizations.' + error.data.message + ': ' + error.data.messageDetail);
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
                $log.error('XHR Failed for getOrganizationsCount.' + error.data.message + ': ' + error.data.messageDetail);
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
                $log.error('XHR Failed for getOrganizations.' + error.data.message + ': ' + error.data.messageDetail);
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
                $log.error('XHR Failed for getItemAttributes.' + error.data.message + ': ' + error.data.messageDetail);
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
                $log.error('XHR Failed for getItemAttributesCount.' + error.data.message + ': ' + error.data.messageDetail);
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
                $log.error('XHR Failed for getItemAttributes.' + error.data.message + ': ' + error.data.messageDetail);
            }
        }
    }

})();