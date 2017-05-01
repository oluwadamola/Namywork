using NamyWork.Core.Business;
using NamyWork.Data.Entities;
using NamyWork.Interface.Data;
using System;
using System.Linq;

namespace NamyWork.Core.Manager
{
    public class ServiceManager : IServiceManager
    {
        private readonly IDataRepository _db;
        public ServiceManager(IDataRepository db)
        {
            _db = db;
        }
        public Operation<long> CreateService(ServiceModel model)
        {
            return Operation.Create((Func<long>)(() =>
            {
                var service = _db.Query<Service>().Where(s => s.ServiceId == model.ServiceId).FirstOrDefault();
                if (service != null) throw new Exception("Service is Created already");

                service = model.Create();
                service.CreatedBy = model.UserId;
                service.CreatedOn = DateTime.Now;
                _db.Add<Service>(service);
                _db.SaveChanges().Unwrap();

                return (long)service.ServiceId;
            }));

        }

        public Operation<ServiceModel> GetService(long serviceId)
        {
            return Operation.Create(() =>
            {
                var service = _db.GetByID<Service>((int)serviceId);
                if (service == null) throw new Exception("Service not found");

                var model = new ServiceModel(service);

                return model;
            });
        }

        public Service GetServiceByName(string roleName)
        {
            throw new NotImplementedException();
        }

        public Operation<ServiceModel[]> GetServices()
        {
            return Operation.Create(() => 
            {
                var services = _db.Query<Service>().ToList();
               return services.Select(s => new ServiceModel(s)).ToArray();
            });

        }

        public Operation<ServiceModel> RemoveService(int userId, string role)
        {
            throw new NotImplementedException();
        }

        public Operation<ServiceModel> UpdateService(ServiceModel model)
        {
            return Operation.Create(() =>
            {
                if (model == null) throw new Exception("No data received");

                var service = _db.Query<Service>().Where(s => s.ServiceId == model.ServiceId).FirstOrDefault();

                //service.Instructions = model.Instructions;
                var entity = new Service()
                {
                    Instruction = model.Instruction,
                    Description = model.Description,
                    JobTitle = model.JobTitle,
                    CategoryId = model.CategoryId,
                    ImageUrl = model.ImageUrl,
                    UserId = model.UserId,
                    ModifiedBy = model.UserId,
                    ModifiedOn = DateTime.Now
            };
                _db.Add<Service>(entity);
                _db.SaveChanges();

                return new ServiceModel(entity);
            });
        }

        public Operation<ServiceModel[]> GetServiceByCity(long id)
        {
            return Operation.Create(() =>
            {
                var service = _db.Query<Service>().Where(s => s.CityId == id).ToList();
                if (service == null) throw new Exception("Location does not exist");
                var model = service.Select(s => new ServiceModel(s)).ToArray();
                return model;
            });
        }

        public Operation<ServiceModel[]> GetServiceByCat(long id)
        {
            return Operation.Create(() =>
            {
                var category = _db.Query<Service>().Where(s => s.CategoryId == id).ToList();
                if (category == null) throw new Exception("Category does not exist");
                var model = category.Select(s => new ServiceModel(s)).ToArray();
                return model;
            });
        }

        public Operation<CategoryModel[]> GetCategories()
        {
            return Operation.Create(() =>
            {
                var categories = _db.Query<Category>().ToList();
                return categories.Select(c => new CategoryModel(c)).ToArray();
            });
        }

        public Operation<CityModel[]> GetCities()
        {
            return Operation.Create(() =>
            {
                var cities = _db.Query<City>().ToList();
                return cities.Select(c => new 
                CityModel(c)).ToArray();
                
            });
        }

    }
}
