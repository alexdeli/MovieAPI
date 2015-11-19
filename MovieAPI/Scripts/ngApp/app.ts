angular.module('MovieApp', ['ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/petshop.html', {
                templateUrl: '/ngViews/petShop.html',
                //controller: 'PetShopController',
                //controllerAs: 'petShop'
                controller: MyApp.ProductListController 
            })
            .when('/calc', {
                templateUrl: '/ngViews/calc.html',
                controller: 'CalculatorController',
                controllerAs: 'calc'
            })
    })
