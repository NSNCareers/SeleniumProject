using PageObjectFramework.Interfaces;
using PageObjectFramework.Pages;
using System;
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
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IHomePage,HomePage>();
            container.RegisterType<ISearchPage,SearchPage>();
        }
    }
}
