angular.module('MovieApp')
    .controller('CalculatorController', function () {
        this.add = function (n1, n2) {
            this.result = parseFloat(n1) + parseFloat(n2);
        }
    })