using System;
using System.Threading;
using OpenQA.Selenium;
using static CoreFramework.Enumerations.Enums;

namespace CoreFramework.BrowserConfig
{
    internal class BrowserSession
    {
        private static ThreadLocal<IWebDriver> _threadDriver = new ThreadLocal<IWebDriver>();

        private static readonly object _lock = new object();

        private static string browserType = Browser.firefox.ToString();


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
            try
            {
                var driver = _threadDriver.Value;
                driver.Navigate().GoToUrl("http://www.purplebricks.co.uk");
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
