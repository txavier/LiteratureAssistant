// http://stackoverflow.com/questions/14070285/how-to-implement-history-back-in-angular-js
// http://jsfiddle.net/asgoth/WaRKv/
itemModule.directive('backButton', function () {
    return {
        restrict: 'E',
        template: "<input type='submit' value='Back' class='btn btn-default' />",
        scope: {
            back: '@back',
        },
        link: function (scope, element, attrs) {
            $(element[0]).on('click', function () {
                history.back();
                scope.$apply();
            });
        }
    };
});