using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Unity;

namespace PageObjectFramework.IOC
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _container;
        public UnityDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }
        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (Exception)
            {

                return new List<object>(); ;
            }
        }
    }
}
