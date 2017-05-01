using NamyWork.Core.Interface;
using NamyWork.Core.Manager;
using Ninject.Modules;
using Ninject.Web.Common;

namespace NamyWork.Web.Infrastructure.DIModules
{
    public class Manager : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserManager>().To<UserManager>().InRequestScope();
            Bind<IServiceManager>().To<ServiceManager>().InRequestScope();
        }
    }
}