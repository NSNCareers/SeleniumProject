using PageObjectFramework.Interfaces;
using PageObjectFramework.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Unity;

namespace PageObjectFramework.IOC
{
    public static class IocConfigurator
    {
        private static IUnityContainer container;
        public static void ConfigureIocContainer()
        {
            container = new UnityContainer();

            RegisterServices(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IHomePage,HomePage>();
            container.RegisterType<ISearchPage,SearchPage>();
        }

        public static object ResolveService(Type serviceType)
        {
            UnityDependencyResolver bb = new UnityDependencyResolver(container);
            var service = bb.GetService(serviceType);
            return service;
        }
    }
}
