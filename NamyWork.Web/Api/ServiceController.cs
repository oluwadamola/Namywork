using NamyWork.Core.Business;
using NamyWork.Core.Manager;
using NamyWork.Web.Infrastructure.Utils;
using System.Web.Http;

namespace NamyWork.Web.Api
{
    [RoutePrefix("api/services")]
    public class ServiceController : ApiController
    {
        private readonly IServiceManager _servicemanager;

        public ServiceController(IServiceManager servicemanager)
        {
            _servicemanager = servicemanager;
        }

        //[Authorize]
        [HttpPost, Route("")]
        public IHttpActionResult CreateService([FromBody]ServiceModel model)
        {
            var op = _servicemanager.CreateService(model);
            return this.OperationResult(op);
        }

        //[Authorize]
        [HttpGet, Route("")]
        public IHttpActionResult GetServices()
        {
            var services = _servicemanager.GetServices();
            return this.OperationResult(services);
        }

        [HttpGet, Route("{serviceId:int}")]
        public IHttpActionResult GetService(long serviceId)
        {
            var service = _servicemanager.GetService(serviceId);
            return this.OperationResult(service);
        }

        [HttpGet, Route("location/{id}")]
        public IHttpActionResult GetServiceByLoc(long id)
        {
            var serviceloc = _servicemanager.GetServiceByCity(id);
            return this.OperationResult(serviceloc);
        }

        [HttpGet, Route("category/{id}")]
        public IHttpActionResult GetServiceByCat(long id)
        {
            var serviceCat = _servicemanager.GetServiceByCat(id);

            return this.OperationResult(serviceCat);
        }

        [HttpGet, Route("categories")]
        public IHttpActionResult GetCategories()
        {
            var categories = _servicemanager.GetCategories();
            return this.OperationResult(categories);
        }
        [HttpGet, Route("cities")]
        public IHttpActionResult GetCities()
        {
            var cities = _servicemanager.GetCities();
            return this.OperationResult(cities);
        }
    }
}
