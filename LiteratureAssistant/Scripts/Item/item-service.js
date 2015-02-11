itemModule.factory("itemService", function ($resource) {

    var baseUrl = "api/itemsApi/:id";

    var resource = $resource(baseUrl);

    var itemAttributeUrl = "api/itemAttributesApi";

    var itemAttributeResource = $resource(itemAttributeUrl);

    var templateAttributeUrl = "api/templateAttributesApi";

    var templateAttributeResource = $resource(templateAttributeUrl);

    return {
        getItems: function () {
            return resource.query({}, isArray = true);
        },
        getItem: function (id) {
            return resource.get({id:"@id"});
        },
        getItemAttributes: function () {
            return itemAttributeResource.query({}, isArray = true);
        },
        getTemplateAttributes: function () {
            return templateAttributeResource.query({}, isArray = true);
        },
        saveItem: function (item) {
            return resource.save({ item: item });
        },
        deleteItem: function (itemId) {
            return resource.delete({ id: itemId });
        },
        getTemplateAttribute: function (templateAttributeId) {
            return templateAttributeResource.get({ id: templateAttributeId })
        },
        saveTemplateAttribute: function (templateAttribute) {
            return templateAttributeResource.save(templateAttribute);
        },
        deleteTemplateAttribute: function (templateAttributeId) {
            return templateAttributeResource.delete({ id: templateAttributeId });
        },
    };
});