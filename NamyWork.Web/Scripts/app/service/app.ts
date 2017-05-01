module Stev.Service {

    export const module = angular.module("Stev", ["Stev.Services", "Stev.Infrastructure", "ui.router", "ngAnimate"]);

    /// UI Router States
    module.config(($stateProvider: angular.ui.IStateProvider, $urlRouterProvider: angular.ui.IUrlRouterProvider) => {

        $urlRouterProvider.otherwise("/")


        $urlRouterProvider
            .when("/notauthorised", function (_notify: Services.NotifyService) {
                _notify.warning("You are not Authorised to perform this Action");
                return "/signin";
            })
            .when("/signout", function (_notify: Services.NotifyService, _storage: Services.StorageService) {
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
            })
    });


}