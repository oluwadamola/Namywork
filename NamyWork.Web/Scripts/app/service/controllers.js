var Stev;
(function (Stev) {
    var Services;
    (function (Services) {
        var Controllers;
        (function (Controllers) {
            var ServicesCtrl = (function () {
                function ServicesCtrl(_service, _notify) {
                    this.service = _service;
                    this.notify = _notify;
                    this.getCities();
                    this.getCategories();
                    this.getServices();
                }
                ServicesCtrl.prototype.getServices = function () {
                    var _this = this;
                    this.service.GetServices().then(function (s) { return _this.Services = s; });
                };
                ServicesCtrl.prototype.getCities = function () {
                    var _this = this;
                    this.service.getCities().then(function (l) {
                        _this.Cities = l;
                        _this.City = _this.Cities[0];
                        _this.citySelected(_this.City);
                    });
                };
                ServicesCtrl.prototype.getCategories = function () {
                    var _this = this;
                    this.service.getCategories().then(function (c) {
                        _this.Categories = c;
                        _this.Category = _this.Categories[0];
                        _this.catSelected(_this.Category);
                    });
                };
                ServicesCtrl.prototype.getServiceByCity = function (cityId) {
                    var _this = this;
                    this.service.getServiceByCity(cityId).then(function (c) { return _this.Services = c; });
                };
                ServicesCtrl.prototype.getServiceByCategory = function (categoryId) {
                    var _this = this;
                    debugger;
                    this.service.getServiceByCat(categoryId).then(function (s) { return _this.Services = s; });
                };
                ServicesCtrl.prototype.citySelected = function (city) {
                    this.getServiceByCity(city.CityId);
                };
                ServicesCtrl.prototype.catSelected = function (category) {
                    this.getServiceByCategory(category.CategoryId);
                };
                return ServicesCtrl;
            }());
            Services.module.controller("ServicesCtrl", ServicesCtrl);
        })(Controllers = Services.Controllers || (Services.Controllers = {}));
    })(Services = Stev.Services || (Stev.Services = {}));
})(Stev || (Stev = {}));
//# sourceMappingURL=controllers.js.map