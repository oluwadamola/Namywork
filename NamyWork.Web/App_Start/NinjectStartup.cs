using Ninject;
using Ninject.Web.Common.OwinHost;
using Owin;
using System.Data.Entity;

namespace NamyWork.Web
{
    public static partial class NinjectStartup
    {
        public static IAppBuilder ConfigureDI(this IAppBuilder app)
        {
            app.UseNinjectMiddleware(CreateKernel);
            return app;
        }
        public static IKernel CreateKernel()
        {
            var _kernel = new StandardKernel();
            _kernel.Load(System.Reflection.Assembly.GetExecutingAssembly());
            //RegisterService(_kernel);
            return _kernel;
        }

        /*public static void RegisterService(IKernel _kernel)
        {
            _kernel.Bind<IDataRepository>().To<EntityRepository>().InRequestScope();
            _kernel.Bind<IUserManager>().To<UserManager>().InRequestScope();
            _kernel.Bind<DbContext>().To<DataEntities>().InRequestScope();
        }*/
    }
}