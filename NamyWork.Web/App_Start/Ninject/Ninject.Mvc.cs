using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace NamyWork.Web
{
    public class NinjectResolver : IDependencyResolver
    {
        public IKernel Kernel { get; private set; }
        public NinjectResolver(params NinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
        }

        public NinjectResolver(Assembly assembly)
        {
            Kernel = new StandardKernel();
            Kernel.Load(assembly);
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }


    public class NinjectContainer
    {
        private static NinjectResolver _resolver;

        //Register Ninject Modules
        public static void RegisterModules(NinjectModule[] modules)
        {
            _resolver = new NinjectResolver(modules);
            DependencyResolver.SetResolver(_resolver);
        }

        public static void RegisterAssembly()
        {
            _resolver = new NinjectResolver(Assembly.GetExecutingAssembly());

            //This is where the actual hookup to the MVC Pipeline is done.
            DependencyResolver.SetResolver(_resolver);
        }
        public static T Resolve<T>()
        {
            return _resolver.Kernel.Get<T>();
        }
    }
}