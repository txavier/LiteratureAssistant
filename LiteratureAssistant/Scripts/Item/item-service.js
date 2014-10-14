itemModule.factory("itemService", function ($resource) {
    return {
        getItems: $resource("api/itemsApi"),
        getItem: $resource("api/itemsApi/:id", {id:"@id"}),
        getItemAttributes: $resource("api/itemAttributesApi"),
        getTemplateAttributes: $resource("api/templateAttributesApi")
    };
});