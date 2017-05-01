var Stev;
(function (Stev) {
    var SystemAdmin;
    (function (SystemAdmin) {
        var Controllers;
        (function (Controllers) {
            var HomeCtrl = (function () {
                function HomeCtrl(_user) {
                    var _this = this;
                    this.user = _user;
                    this.user.getUsers().then(function (u) { return _this.Users = u; });
                }
                return HomeCtrl;
            }());
            var UsersCtrl = (function () {
                function UsersCtrl(_user, _notify, $uibModal, $state) {
                    this.user = _user;
                    this.notify = _notify;
                    this.modal = $uibModal;
                    this.state = $state;
                    this.getUsers();
                }
                UsersCtrl.prototype.getUsers = function () {
                    var _this = this;
                    this.user.getUsers().then(function (u) { return _this.Users = u; });
                };
                UsersCtrl.prototype.Add = function () {
                    var _this = this;
                    var instance = this.modal.open({
                        templateUrl: "addUser.html",
                        controller: "AddUserCtrl as model",
                    });
                    instance.result.then(function () { return _this.getUsers(); });
                };
                UsersCtrl.prototype.Select = function (user) {
                    this.state.go("users.profile", { id: user.UserId });
                };
                return UsersCtrl;
            }());
            var AddUserCtrl = (function () {
                function AddUserCtrl($uibModalInstance, _user, _notify) {
                    this.instance = $uibModalInstance;
                    this.user = _user;
                    this.notify = _notify;
                }
                AddUserCtrl.prototype.Ok = function (form, user) {
                    var _this = this;
                    if (form.$valid) {
                        this.user.addUser(user).then(function () {
                            _this.notify.success("User is successfully created");
                            _this.instance.close();
                        });
                    }
                    else {
                        this.notify.warning("Invalid Data Received");
                    }
                };
                AddUserCtrl.prototype.Cancel = function () {
                    this.instance.dismiss("User closed dialog");
                };
                return AddUserCtrl;
            }());
            var UserCtrl = (function () {
                function UserCtrl(_user, $stateParams, $uibModal) {
                    this.user = _user;
                    this.modal = $uibModal;
                    this.GetRoles($stateParams["id"]);
                }
                UserCtrl.prototype.GetRoles = function (userId) {
                    var _this = this;
                    this.user.getUserRoles(userId).then(function (r) { return _this.Roles = r.map(function (ur) { return _this.user.getRole(ur.RoleName); }); });
                };
                UserCtrl.prototype.AddRole = function () {
                    var _this = this;
                    var instance = this.modal.open({
                        templateUrl: "role.html",
                        controller: "AddRoleCtrl as model",
                        resolve: {
                            user: function () { return _this.User; }
                        }
                    });
                    instance.result.then(function () { return _this.GetRoles(_this.User.UserId); });
                };
                UserCtrl.prototype.RemoveRole = function (role) {
                    var _this = this;
                    var instance = this.modal.open({
                        templateUrl: "remove-role.html",
                        controller: "RemoveRoleCtrl as model",
                        resolve: { user: function () { return _this.User; }, role: function () { return role; } }
                    });
                    instance.result.then(function () {
                        _this.user.removeRole(_this.User, role);
                        var rIndex = _this.Roles.indexOf(role);
                        if (rIndex != -1)
                            _this.Roles.splice(rIndex, 1);
                    });
                };
                return UserCtrl;
            }());
            var AddRoleCtrl = (function () {
                function AddRoleCtrl(_user, _notify, $uibModalInstance, user) {
                    this.user = _user;
                    this.notify = _notify;
                    this.instance = $uibModalInstance;
                    this.Roles = this.user.getAllRoles();
                    this.User = user;
                }
                AddRoleCtrl.prototype.Ok = function (form, role) {
                    var _this = this;
                    if (form.$valid) {
                        this.user.assignRole(this.User.UserId, role.RoleName).then(function () {
                            _this.notify.success("Role added successfully");
                            _this.instance.close();
                        });
                    }
                    else {
                        this.notify.warning("Fill all required field");
                    }
                };
                AddRoleCtrl.prototype.Cancel = function () {
                    this.instance.dismiss("User close dialog");
                };
                return AddRoleCtrl;
            }());
            var RemoveRoleCtrl = (function () {
                function RemoveRoleCtrl($uibModalInstance, role, user) {
                    this.instance = $uibModalInstance;
                    this.Role = role;
                    this.User = user;
                }
                RemoveRoleCtrl.prototype.Ok = function (role) {
                    this.instance.close();
                };
                RemoveRoleCtrl.prototype.Cancel = function () {
                    this.instance.dismiss();
                };
                return RemoveRoleCtrl;
            }());
            SystemAdmin.module.controller("HomeCtrl", HomeCtrl);
            SystemAdmin.module.controller("UsersCtrl", UsersCtrl);
            SystemAdmin.module.controller("AddUserCtrl", AddUserCtrl);
            SystemAdmin.module.controller("UserCtrl", UserCtrl);
            SystemAdmin.module.controller("AddRoleCtrl", AddRoleCtrl);
            SystemAdmin.module.controller("RemoveRoleCtrl", RemoveRoleCtrl);
        })(Controllers = SystemAdmin.Controllers || (SystemAdmin.Controllers = {}));
    })(SystemAdmin = Stev.SystemAdmin || (Stev.SystemAdmin = {}));
})(Stev || (Stev = {}));
var Stev;
(function (Stev) {
    var SystemAdmin;
    (function (SystemAdmin) {
        var Controllers;
        (function (Controllers) {
            var ServicesCtrl = (function () {
                function ServicesCtrl(_service, _notify, $uibModal) {
                    this.service = _service;
                    this.notify = _notify;
                    this.modal = $uibModal;
                    this.getServices();
                }
                ServicesCtrl.prototype.getServices = function () {
                    var _this = this;
                    this.service.GetServices().then(function (s) { return _this.Services = s; });
                };
                ServicesCtrl.prototype.addService = function () {
                    var _this = this;
                    debugger;
                    var instance = this.modal.open({
                        templateUrl: "addService.html",
                        controller: "AddServiceCtrl as model"
                    });
                    instance.result.then(function () { return _this.getServices(); });
                };
                return ServicesCtrl;
            }());
            var AddServiceCtrl = (function () {
                function AddServiceCtrl($uibModalInstance, _service, _notify, _storage) {
                    this.instance = $uibModalInstance;
                    this.service = _service;
                    this.notify = _notify;
                    this.storage = _storage;
                    this.getCategories();
                    this.getCities();
                    this.User = this.storage.User;
                }
                AddServiceCtrl.prototype.getCategories = function () {
                    var _this = this;
                    this.service.getCategories().then(function (c) { return _this.Categories = c; });
                };
                AddServiceCtrl.prototype.getCities = function () {
                    var _this = this;
                    this.service.getCities().then(function (c) { return _this.Cities = c; });
                };
                AddServiceCtrl.prototype.Ok = function (form, service) {
                    var _this = this;
                    if (form.$valid) {
                        service.CategoryId = this.Category.CategoryId;
                        service.CityId = this.City.CityId;
                        service.UserId = this.User.UserId;
                        this.service.addService(service).then(function () {
                            _this.notify.success("Service is successfully created");
                            _this.instance.close();
                        });
                    }
                    else {
                        this.notify.warning("Invalid Data Received");
                    }
                };
                AddServiceCtrl.prototype.Cancel = function () {
                    this.instance.dismiss("Service closed dialog");
                };
                return AddServiceCtrl;
            }());
            var ServiceCtrl = (function () {
                function ServiceCtrl(_service, _user, $stateParams) {
                    var _this = this;
                    this.service = _service;
                    this.user = _user;
                    this.service.getService($stateParams["id"]).then(function (s) {
                        _this.Service = s;
                        _this.user.getUser(_this.Service.UserId).then(function (u) {
                            _this.User = u;
                        });
                    });
                }
                return ServiceCtrl;
            }());
            SystemAdmin.module.controller("ServicesCtrl", ServicesCtrl);
            SystemAdmin.module.controller("ServiceCtrl", ServiceCtrl);
            SystemAdmin.module.controller("AddServiceCtrl", AddServiceCtrl);
        })(Controllers = SystemAdmin.Controllers || (SystemAdmin.Controllers = {}));
    })(SystemAdmin = Stev.SystemAdmin || (Stev.SystemAdmin = {}));
})(Stev || (Stev = {}));
//# sourceMappingURL=controllers.js.map