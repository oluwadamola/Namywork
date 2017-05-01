var Stev;
(function (Stev) {
    var Constants;
    (function (Constants) {
        //constant for fetching authorization from local browser keystore
        Constants.OAuthTokenKey = "Stev.Security.OAuth.AuthorizationToken-KEY";
        Constants.UserKey = "Stev.User";
        Constants.LoginUrl = "/account/index";
        Constants.Roles = {
            SystemAdministrator: "SystemAdministrator",
            User: "User",
            Freelancer: "Freelancer"
        };
    })(Constants = Stev.Constants || (Stev.Constants = {}));
})(Stev || (Stev = {}));
//# sourceMappingURL=constants.js.map