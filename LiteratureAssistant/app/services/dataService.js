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
        var userApiUrl = 'api/usersApi';
        var orderApiUrl = 'api/ordersApi';

        var service = {
            getOrganizations: getOrganizations,
            getOrganizationsCount: getOrganizationsCount,
            addOrUpdateOrganization: addOrUpdateOrganization,
            getItemAttributes: getItemAttributes,
            getItemAttributesCount: getItemAttributesCount,
            addOrUpdateItemAttribute: addOrUpdateItemAttribute,
            getItems: getItems,
            getItem: getItem,
            addOrUpdateItem: addOrUpdateItem,
            deleteItem: deleteItem,
            getItemTemplate: getItemTemplate,
            getItemTemplates: getItemTemplates,
            getItemTemplatesCount: getItemTemplatesCount,
            addOrUpdateItemTemplate: addOrUpdateItemTemplate,
            deleteItemTemplate: deleteItemTemplate,
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
            deleteOrder: deleteOrder,
            getOpenOrders: getOpenOrders
        };

        return service;

        function getOpenOrders() {
            return $http.get(orderApiUrl + '/openOrders')
                        .then(getOpenOrdersComplete)
                        .catch(getOpenOrdersFailed);

            function getOpenOrdersComplete(response) {
                return response.data;
            }

            function getOpenOrdersFailed(error) {
                $log.error('XHR failed for getOpenOrders.' + error.data.message + ': ' + (error.data.messageDetail || error.data.exceptionMessage));
            }
        }

        function getOrders() {
            return $http.get(orderApiUrl)
                    .then(getOrdersComplete)
                    .catch(getOrdersFailed);

            function getOrdersComplete(response) {
                return response.data;
            }

            function getOrdersFailed(error) {
                $log.error('XHR failed for getOrders.' + error.data.message + ': ' + (error.data.messageDetail || error.data.exceptionMessage));
            }
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

        function getItemTemplate(itemTemplateId) {
            return $http.get(itemTemplateApiUrl + '/' + itemTemplateId)
                .then(getItemTemplateComplete)
                .catch(getItemTemplateFailed);

            function getItemTemplateComplete(response) {
                return response.data;
            }

            function getItemTemplateFailed(error) {
                $log.error('XHR Failed for getItemTemplate.' + error.data.message + ': ' + error.data.messageDetail);
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

        function getItemTemplatesCount(organizationId) {
            return $http.get(itemTemplateApiUrl + '/count/' + (organizationId || -1))
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

        function deleteItemTemplate(itemTemplateId) {
            return $http.delete(itemTemplateApiUrl + '/' + itemTemplateId)
                .then(deleteItemComplete)
                .catch(deleteItemFailed);

            function deleteItemComplete(response) {
                return response.data;
            }

            function deleteItemFailed(error) {
                $log.error('XHR Failed for deleteItem.' + error.data.message + ': ' + error.data.messageDetail);
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

        function getCounts() {
            return $http.get(countApiUrl)
                .then(getCountsComplete)
                .catch(getCountsFailed);

            function getCountsComplete(response) {
                return response.data;
            }

            function getCountsFailed(error) {
                $log.error('XHR Failed for getCounts.' + error.data.message + ': ' + error.data.messageDetail);
            }
        }

        function getCount(countId) {
            return $http.get(countApiUrl + '/' + countId)
                .then(getCountComplete)
                .catch(getCountFailed);

            function getCountComplete(response) {
                return response.data;
            }

            function getCountFailed(error) {
                $log.error('XHR Failed for getCount.' + error.data.message + ': ' + error.data.messageDetail);
            }
        }

        function addOrUpdateCount(count) {
            return $http.get(countApiUrl, count)
                .then(addOrUpdateCountComplete)
                .catch(addOrUpdateCountFailed);

            function addOrUpdateCountComplete(response) {
                return response.data;
            }

            function addOrUpdateCountFailed(error) {
                $log.error('XHR Failed for addOrUpdateCount.' + error.data.message + ': ' + error.data.messageDetail);
            }
        }

        function deleteCount(countId) {
            return $http.delete(countApiUrl + '/' + countId)
                .then(deleteCountComplete)
                .catch(deleteCountFailed);

            function deleteCountComplete(response) {
                return response.data;
            }

            function deleteCountFailed(error) {
                $log.error('XHR Failed for deleteCount.' + error.data.message + ': ' + error.data.messageDetail);
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

        function deleteTemplateAttribute(templateAttributeId) {
            return $resource(templateAttributeApiUrl).delete({ id: templateAttributeId });
        }

        function getItem(itemId) {
            return $http.get(itemApiUrl + '/' + itemId)
                .then(getItemComplete)
                .catch(getItemFailed);

            function getItemComplete(response) {
                return response.data;
            }

            function getItemFailed(error) {
                $log.error('XHR Failed for getItem.' + error.data.message + ': ' + error.data.messageDetail);
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

        function addOrUpdateItem(item) {
            return $http.post(itemApiUrl, item)
                .then(addOrUpdateItemComplete)
                .catch(addOrUpdateItemFailed);

            function addOrUpdateItemComplete(response) {
                return response.data;
            }

            function addOrUpdateItemFailed(error) {
                $log.error('XHR Failed for addOrUpdateItem.' + error.data.message + ': ' + error.data.messageDetail);
            }
        }

        function deleteItem(itemId) {
            return $http.delete(itemApiUrl + '/' + itemId)
                .then(deleteItemComplete)
                .catch(deleteItemFailed);

            function deleteItemComplete(response) {
                return response.data;
            }

            function deleteItemFailed(error) {
                $log.error('XHR Failed for deleteItem.' + error.data.message + ': ' + error.data.messageDetail);
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