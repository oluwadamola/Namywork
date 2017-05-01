using System;
using System.Web.Routing;

namespace NamyWork.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DataBaseConfig.MigrateToLatest();

            NinjectContainer.RegisterAssembly();
        }

    }
}