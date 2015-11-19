//(function () {
//    let products = [
//        { id: 1, name: 'Milk', price: 5.00 },
//        { id: 2, name: 'Cheese', price: 17.00 },
//        { id: 3, name: 'Apples', price: 3.40 }
//    ];
//    angular.module('MovieApp')
//        .controller('ProductListController', function () {
//            this.products = products;
//        });
//    angular.module('MovieApp')
//        .controller('ProductDetailsController', function ($routeParams) {
//            this.product = products.filter((p) => p.id == $routeParams['id'])[0];
//        });
//})();
var MyApp;
(function (MyApp) {
    var products = [
        { id: 1, name: 'Milk', price: 5.00 },
        { id: 2, name: 'Cheese', price: 17.00 },
        { id: 3, name: 'Apples', price: 3.40 }
    ];
    var ProductListController = (function () {
        function ProductListController() {
            this.products = products;
        }
        return ProductListController;
    })();
    MyApp.ProductListController = ProductListController;
    var ProductDetailsController = (function () {
        function ProductDetailsController($routeParams) {
            this.product = products.filter(function (p) { return p.id == $routeParams['id']; })[0];
        }
        return ProductDetailsController;
    })();
    MyApp.ProductDetailsController = ProductDetailsController;
})(MyApp || (MyApp = {}));
