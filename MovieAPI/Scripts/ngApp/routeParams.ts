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

namespace MyApp {

    let products = [
        { id: 1, name: 'Milk', price: 5.00 },
        { id: 2, name: 'Cheese', price: 17.00 },
        { id: 3, name: 'Apples', price: 3.40 }
    ];

    export class ProductListController {
        public products;

        constructor() {
            this.products = products;
        }
    }

    new ProductListController();


    export class ProductDetailsController {
        public product;

        constructor($routeParams) {
            this.product = products.filter((p) => p.id == $routeParams['id'])[0];
        }
    }
   
