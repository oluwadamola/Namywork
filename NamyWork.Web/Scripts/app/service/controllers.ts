module Stev.Services.Controllers{

    class ServicesCtrl {

        Service: ServiceModel;
        Services: ServiceModel[];
        Category: CategoryModel;
        Categories: CategoryModel[];
        City: CityModel;
        Cities: CityModel[];

        service: Services.Domain.Service;
        notify: Services.NotifyService;

        constructor(_service, _notify) {
            this.service = _service;
            this.notify = _notify;

            this.getCities();
            this.getCategories();
            this.getServices();


        }
        getServices() {
            this.service.GetServices().then(s => this.Services = s);
        }
        getCities() {
            this.service.getCities().then(l => {
                this.Cities = l

                this.City = this.Cities[0];
                this.citySelected(this.City)
            });
        }

        getCategories() {
            this.service.getCategories().then(c => {
                this.Categories = c

                this.Category = this.Categories[0];
                this.catSelected(this.Category);

            });
        }

        getServiceByCity(cityId: number) {
            this.service.getServiceByCity(cityId).then(c => this.Services = c);
        }
        getServiceByCategory(categoryId: number) {
            debugger;
            this.service.getServiceByCat(categoryId).then(s => this.Services = s);

        }

        citySelected(city: CityModel) {
            this.getServiceByCity(city.CityId);
        }

        catSelected(category: CategoryModel) {
            this.getServiceByCategory(category.CategoryId);
        }

    }
    module.controller("ServicesCtrl", ServicesCtrl);
}