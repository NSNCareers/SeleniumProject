using System;
using System.Configuration;
using CoreFramework.IOC;
using PageObjectFramework.Interfaces;
using PageObjectFramework.Pages;
using Unity;

namespace PageObjectFramework.IOC
{
    public static class ResolveDependency
    {
       public static void RegisterAndResolveDependencies()
        {
            UnityWrapper.LoadConfig();
            //UnityWrapper.Register<IHomePage, HomePage>();
            //UnityWrapper.Register<ISearchPage, SearchPage>();
            //UnityWrapper.Resolve<>();
        }
    }
}
