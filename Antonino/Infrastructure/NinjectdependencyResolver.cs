using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Antonino.Classes;
using Antonino.Infrastructure.Abstract;
using Antonino.Infrastructure.Concrete;


namespace Antonino.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IDataBase>().To<MongoDB>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}