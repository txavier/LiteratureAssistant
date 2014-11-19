itemModule.factory("templateAttributeService", function ($resource, $http) {

    var baseUrl = "api/templateAttributesApi";

    var resource = $resource(baseUrl);

    return {
        getTemplateAttributes: function () {
            return resource.query({}, isArray = true);
        },
        getTemplateAttribute: function (templateAttributeId) {
            return resource.get({ id: templateAttributeId })
        },
        saveTemplateAttribute: function (templateAttribute) {
            return resource.save(templateAttribute);
        },
        deleteTemplateAttribute: function (templateAttributeId) {
            return resource.delete({ id: templateAttributeId });
        },
    }
});