var MyApp;
(function (MyApp) {
    angular.module('MyApp', ['ngRoute']).config(function ($routeProvider, $locationProvider) {
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
})(MyApp || (MyApp = {}));
var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var MainController = (function () {
            function MainController($route) {
                this.$route = $route;
            }
            return MainController;
        })();
        Controllers.MainController = MainController;
        angular.module('MyApp').controller('MainController', MainController);
        var Page1Controller = (function () {
            function Page1Controller() {
                this.message = 'Hello from Page1!!!';
            }
            return Page1Controller;
        })();
        Controllers.Page1Controller = Page1Controller;
        var Page2Controller = (function () {
            function Page2Controller($location) {
                this.$location = $location;
                this.message = 'Hello from Page2!!!';
            }
            Page2Controller.prototype.doSomething = function () {
                this.$location.path('/page1');
            };
            return Page2Controller;
        })();
        Controllers.Page2Controller = Page2Controller;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
