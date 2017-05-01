using NamyWork.Core.Business;
using NamyWork.Data.Entities;
using System;

namespace NamyWork.Core.Manager
{
    public interface IServiceManager
    {
        Operation<long> CreateService(ServiceModel model);
        Operation<ServiceModel> UpdateService(ServiceModel model);
        Operation<ServiceModel> GetService(long serviceId);
        Operation<ServiceModel[]> GetServices();
        Service GetServiceByName(string roleName);
        Operation<ServiceModel> RemoveService(int userId, string role);
        Operation<ServiceModel[]> GetServiceByCity(long id);
        Operation<ServiceModel[]> GetServiceByCat(long id);
        Operation<CategoryModel[]> GetCategories();
        Operation<CityModel[]> GetCities();
        
    }
}