namespace MyApp {

    angular.module('MyApp', ['ngRoute']).config(($routeProvider: ng.route.IRouteProvider, $locationProvider: ng.ILocationProvider) => {
        $routeProvider
            .when('/', {
                templateUrl: "ngViews/page1.html",
                controller: MyApp.Controllers.Page1Controller,
                controllerAs: 'controller'
            })
            .when('/page1', {
                templateUrl: "ngViews/page1.html",
                controller: MyApp.Controllers.Page1Controller,
                controllerAs: 'controller'
            })
            .when('/page2', {
                templateUrl: "ngViews/page2.html",
                controller: MyApp.Controllers.Page2Controller,
                controllerAs: 'controller'
            })
            .otherwise({ redirectTo: '/' });

        $locationProvider.html5Mode(false);
    });


}

namespace MyApp.Controllers {

    export class MainController {
        constructor(public $route: ng.route.IRouteService) { }
    }
    angular.module('MyApp').controller('MainController', MainController);

    export class Page1Controller {
        public message = 'Hello from Page1!!!';
    }

    export class Page2Controller {
        public message = 'Hello from Page2!!!';

        doSomething() {
            this.$location.path('/page1');
        }

        constructor(private $location: ng.ILocationService) { }
    }

}