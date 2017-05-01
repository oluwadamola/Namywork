var Stev;
(function (Stev) {
    var Service;
    (function (Service) {
        Service.module = angular.module("Stev", ["Stev.Services", "Stev.Infrastructure", "ui.router", "ngAnimate"]);
        /// UI Router States
        Service.module.config(function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise("/");
            $urlRouterProvider
                .when("/notauthorised", function (_notify) {
                _notify.warning("You are not Authorised to perform this Action");
                return "/signin";
            })
                .when("/signout", function (_notify, _storage) {
                _notify.success("You have successfully logged out");
                _storage.Clear();
                return "/signin";
            });
            $stateProvider
                .state("services", {
                url: "/",
                templateUrl: "/home/template/index",
                controller: "ServicesCtrl",
                controllerAs: "model"
            });
        });
    })(Service = Stev.Service || (Stev.Service = {}));
})(Stev || (Stev = {}));
//# sourceMappingURL=app.js.map