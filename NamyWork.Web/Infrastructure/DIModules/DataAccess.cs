using NamyWork.Data;
using NamyWork.Interface.Data;
using Ninject.Modules;
using Ninject.Web.Common;
using System.Data.Entity;

namespace NamyWork.Web.Infrastructure.DIModules
{
    public class DataAccess : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataRepository>().To<EntityRepository>().InRequestScope();
            Bind<DbContext>().To<DataEntities>().InRequestScope();
        }
    }
}