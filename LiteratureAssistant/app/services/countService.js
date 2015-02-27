(function () {
    'use strict';

    angular
       .module('app')
       .factory('countService', countService);

    countService.$inject = [];

    function countService() {

        var service = {
            getToday: getToday,
        };

        return service;

        function getToday() {
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
    }

})();