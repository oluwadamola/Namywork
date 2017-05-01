using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Web.Http;

namespace NamyWork.Web
{
    public static partial class WebApiStartup
    {
        public static void ConfigureWebApi(this IAppBuilder app)
        {

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            app.UseNinjectWebApi(config);
            
        }
    }
}