(function () {
    'use strict';

    angular
       .module('app')
       .factory('jsPdfBarcodeService', jsPdfBarcodeService);

    jsPdfBarcodeService.$inject = ['$log'];

    function jsPdfBarcodeService($log) {
        var firstLineFactor = 7.142;
        var spaceBetweenRowsFactor = 9.785;
        var leftMostMargin = 25;
        var fontSize = 9;
        var barcodeOnTheSide = true;
        var startRow = null;

        var service = {
            leftMostMargin: leftMostMargin,
            firstLineFactor: firstLineFactor,
            spaceBetweenRowsFactor: spaceBetweenRowsFactor,
            fontSize: fontSize,
            startRow: startRow,
            getPdf: getPdf
        };

        return service;

        function getFirstLine(numberOfRowsPerPage) {
            var result = (10 * numberOfRowsPerPage) / firstLineFactor;

            return result;
        }

        function getSpaceBetweenRows(numberOfRowsPerPage) {
            var result = (80 * numberOfRowsPerPage) / (3 * spaceBetweenRowsFactor);

            return result;
        }

        function getPdf(
            getDataUri,
            barcodeImageData,
            rowsPerPage,
            columnsPerPage,
            numberOfTimesToPrint,
            header,
            linesToPrintArray,
            footer) {
            // You'll need to make your image into a Data URL
            // Use http://dataurl.net/#dataurlmaker
            var doc = new jsPDF("portrait", "mm", "letter");

            for (var i = 0; i < numberOfTimesToPrint; i++) {
                var column = i % columnsPerPage;

                var row = Math.floor(i / columnsPerPage) % rowsPerPage;

                var page = Math.floor(i / rowsPerPage);

                // If we are on the first item of a new page add the new page
                // javascript method call.
                if (i > columnsPerPage && row == 0 && column == 0) {
                    doc.addPage();
                }

                //var spaceBetweenMajorRows = 80;
                var spaceBetweenMajorRows = getSpaceBetweenRows(rowsPerPage);

                //var startRow = 30;
                var startRow = startRow ? startRow : getFirstLine(rowsPerPage);

                var rowFactor = row * spaceBetweenMajorRows;

                if (columnsPerPage == 2) {
                    if (column == 0) {
                        leftMostMargin = 15;
                    }
                    else if (column == 1) {
                        leftMostMargin = 115;
                    }
                }
                else if (columnsPerPage == 3) {
                    if (column == 0) {
                        leftMostMargin = 20;
                    }
                    else if (column == 1) {
                        leftMostMargin = 90;
                    }
                    else if (column == 2) {
                        leftMostMargin = 160;
                    }
                }

                doc.setFontSize(fontSize);

                doc.setLineWidth(75);

                //rowFactor = rowFactor + startRow;

                var firstLine = startRow;

                var firstRow = firstLine + rowFactor;

                var secondRow = firstLine + 5 + rowFactor;

                var thirdRow = firstLine + 10 + rowFactor;

                var fourthRow = firstLine + 15 + rowFactor;

                var fifthRow = firstLine + 25 + rowFactor;

                var sixthRow = firstLine + 30 + rowFactor;

                var seventhRow = firstLine + 35 + rowFactor;

                var eigthRow = firstLine + 40 + rowFactor;

                var ninthRow = firstLine + 45 + rowFactor;

                var tenthRow = firstLine + 50 + rowFactor;

                doc.text(leftMostMargin, firstRow, header || '');

                doc.text(leftMostMargin, secondRow, linesToPrintArray[0] || '');

                doc.text(leftMostMargin, fourthRow, linesToPrintArray[1] || '');

                doc.text(leftMostMargin, fifthRow, linesToPrintArray[2] || '');

                doc.text(leftMostMargin, sixthRow, linesToPrintArray[3] || '');

                doc.setFontSize(11);

                doc.text(leftMostMargin, eigthRow, footer || '');

                doc.setFontSize(10);

                if (barcodeOnTheSide) {
                    doc.addImage(barcodeImageData, 'JPEG', leftMostMargin + 30, firstRow - 10, 18, 35);
                }
                else {
                    doc.addImage(barcodeImageData, 'JPEG', leftMostMargin, firstRow, 18, 35);
                }
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