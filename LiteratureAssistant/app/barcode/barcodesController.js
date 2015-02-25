(function () {
    angular
        .module('itemModule')
        .controller('barcodesController', barcodesController);

    barcodesController.$inject = ['$scope', '$log', '$routeParams', 'dataService'];

    function barcodesController($scope, $log, $routeParams, dataService) {
        var vm = this;

        vm.demoFromHtml = demoFromHtml;
        vm.items = [];
        vm.item = {};

        activate();

        function activate() {
            setView();

            return vm;
        }

        function setView() {
            dataService.getBarcodes($routeParams.itemId).then(function (data) {
                vm.items = data;

                vm.item = vm.items[0];

                demoFromHtml();
            });
        }

        function demoFromHtml() {
            GetPdf(true);
        }

        function GetPdf(getDataUri) {

            var item = vm.item;

            var barcodeFieldName = '';

            var bottleIdDisplay = '';

            var imgData = '';

            var draw = 1;

            // You'll need to make your image into a Data URL
            // Use http://dataurl.net/#dataurlmaker
            var doc = new jsPDF("portrait", "mm", "letter");

        
        for(var i = 0; i < 20; i++) {

            var rowsPerPage = 10;

            var columnsPerPage = 3;

            var column = i % columnsPerPage;

            var row = Math.floor(i / columnsPerPage) % rowsPerPage;

            var page = Math.floor(i / rowsPerPage);

            // If we are on the first item of a new page add the new page
            // javascript method call.
            if(i > columnsPerPage && row == 0 && column == 0)
            {
                doc.addPage();
            }

            var spaceBetweenMajorRows = 80;

            var startRow = 30;

            var rowFactor = row * spaceBetweenMajorRows;

            barcodeFieldName = item.fieldName;

            barcodeValue = item.value;

            imgData = item.barcodeBase64DataUri;

            if(column == 0)
            {
                 leftMostMargin = 15;
            }
            else if (column == 1)
            {
                 leftMostMargin = 115;
            }

            doc.setFontSize(10);

            doc.setLineWidth(75);

            rowFactor = rowFactor + startRow;

            var firstRow = 10 + rowFactor;

            var secondRow = 15 + rowFactor;

            var thirdRow = 20 + rowFactor;

            var fourthRow = 25 + rowFactor;

            var fifthRow = 30 + rowFactor;

            var sixthRow = 35 + rowFactor;

            var seventhRow = 40 + rowFactor;

            var eigthRow = 45 + rowFactor;

            var ninthRow = 50 + rowFactor;

            var tenthRow = 55 + rowFactor;

            doc.text(leftMostMargin, firstRow, 'Bottle#');

            doc.text(leftMostMargin, secondRow, ' draw');

            doc.text(leftMostMargin, fourthRow, 'BWS NYC DEP');

            doc.text(leftMostMargin, fifthRow, '59-17 Junction Blvd, 20th Floor High Rise');

            doc.text(leftMostMargin, sixthRow, 'Flushing, NY 11373');

            doc.setFontSize(11);
            
            doc.text(leftMostMargin, eigthRow, barcodeFieldName);

            doc.setFontSize(10);
            
            doc.addImage(imgData, 'JPEG', leftMostMargin + 70, thirdRow - 10, 18, 35);
        }

            if (getDataUri) {
                doc.output('dataurl');
            }
            else {
                return doc.output();
            }

        }

    }

})();