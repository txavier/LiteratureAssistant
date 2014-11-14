itemModule.factory("countService", function ($resource, $http) {

    var baseUrl = "api/countsApi";

    var resource = $resource(baseUrl);

    var getToday = function () {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();

        if (dd < 10) {
            dd = '0' + dd
        }

        if (mm < 10) {
            mm = '0' + mm
        }

        today = mm + '/' + dd + '/' + yyyy;

        return today;
    }

    return {
        getToday: getToday,
        getCounts: function () {
            return resource.query({}, isArray = true);
        },
        getCount: function (countId) {
            return resource.get({ id: countId })
        },
        saveCount: function (count) {
            return resource.save(count);
        },
        deleteCount: function (countId) {
            return resource.delete({ id: countId });
        },
    }
});