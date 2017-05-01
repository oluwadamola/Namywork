﻿module Stev.SystemAdmin {
    export const module = angular.module("Stev", [
        "Stev.Services",
        "Stev.Profile",
        "Stev.Infrastructure",
        "ui.bootstrap",
        "ui.router",
        "ngAnimate"]);

    /// UI Router States
    module.config(($stateProvider: angular.ui.IStateProvider, $urlRouterProvider: angular.ui.IUrlRouterProvider) => {
        $urlRouterProvider.otherwise("/")
         
        $urlRouterProvider.when("/users", "/users/list");
        //$urlRouterProvider.when("/subscription", "/subscription/current")


        $stateProvider
            .state("home", {
                url: "/",
                templateUrl: "/systemadmin/template/home", //<-- /account/signin
                controller: "HomeCtrl",
                controllerAs: "model"
            })

            .state("users", {
                url: "/users",
                template: "<div ui-view class='view-frame'></div>",
            })
            .state("users.list", {
                url: "/list",
                templateUrl: "/systemadmin/template/users",
                controller: "UsersCtrl",
                controllerAs: "model"
            })

            .state("users.profile", {
                url: "/profile/{id}",
                templateUrl: "/systemadmin/template/user",
                controller: "UserCtrl",
                controllerAs: "model"
            })
            .state("services", {
                url: "/services",
                template: "<div ui-view class='view-frame'></div>",
            })
            .state("services.list", {
                url: "/list",
                templateUrl: "/systemadmin/template/services",
                controller: "ServicesCtrl",
                controllerAs: "model"
            })
            .state("services.details", {
                url: "/detail/{id}",
                templateUrl: "/systemadmin/template/service",
                controller: "ServiceCtrl",
                controllerAs: "model"
            })

            //.state("groups", {
            //    url: "/groups",
            //    templateUrl: "<div ui-view class='view-frame'></div>",
                
            //})

            //.state("groups.list", {
            //    url: "/list",
            //    templateUrl:"/systemadmin/template/groups",
            //    controller: "GroupCtrl",
            //    controllerAs: "model"
            //})

            //.state("subscription", {
            //    url: "/subscription",
            //    template: "<div ui-view class='view-frame'></div>",
            //})

            //.state("subscription.current", {
            //    url: "/current",
            //    templateUrl: "/systemadmin/template/subscription",
            //    controller: "SubscriptionCtrl",
            //    controllerAs: "model"
            //})

            //.state("subscription.plans", {
            //    url: "/plans",
            //    templateUrl: "/systemadmin/template/plans",
            //    controller: "PlansCtrl",
            //    controllerAs: "model"
            //})
    });


    /// Configure Authentication
    module.run(function ($rootScope: ng.IRootScopeService, _storage: Services.StorageService) {
        $rootScope.$on('$stateChangeStart',
            function (event, toState, toStateParams) {

                var role = Constants.Roles.SystemAdministrator;

                //Check to see if user has this role 
                var hasRole = _storage.User
                    .Roles
                    .filter(ur => ur.RoleName == role).length;
                if (!hasRole) {
                    document.location.href = "/account/#!/notauthorised";
                }
            });
    });

    /// https://github.com/angular-ui/ui-router/issues/2889
    module.config($qProvider => $qProvider.errorOnUnhandledRejections(false));
}