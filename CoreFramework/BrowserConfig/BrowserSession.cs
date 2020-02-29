using System;
using System.IO;
using System.Reflection;
using System.Threading;
using CoreFramework.Config;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using static CoreFramework.Enumerations.Enums;

namespace CoreFramework.BrowserConfig
{
    internal class BrowserSession
    {
        private static ThreadLocal<IWebDriver> _threadDriver = new ThreadLocal<IWebDriver>();

        private static readonly object _lock = new object();

        private static string browserType = Browser.chrome.ToString();

        static BrowserSession()
        {
        }

        public static IWebDriver OpenBrowser()
        {
            lock (_lock)
            {
                _threadDriver.Value = InitBrowser.InitializeDriver(browserType);
                return _threadDriver.Value;
            }
        }

        public static IWebDriver driver
        {
            get { return _threadDriver.Value; }
        }
        
        public static void GoToDesiredUrl()
        {
            string Url = JsonConfig.GetJsonValue("BaseUrl");
            try
            {
                var driver = _threadDriver.Value;
                driver.Navigate().GoToUrl(Url);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
       
        public static void CloseBrowser()
        {
            if (_threadDriver.Value != null)
            {
                _threadDriver.Value.Dispose();
                _threadDriver.Value.Quit();
            }
        }
    }
}
