using System;
using System.Threading;
using OpenQA.Selenium;

namespace CoreFramework.BrowserConfig
{
    internal class BrowserSession
    {
        private static ThreadLocal<IWebDriver> _threadDriver = new ThreadLocal<IWebDriver>();

        private static readonly object _lock = new object();


        public static IWebDriver OpenBrowser(string browserType)
        {
            lock (_lock)
            {
                _threadDriver.Value = InitBrowser.InitializeDriver(browserType);
                //Reporter.WriteTestExecutionInfo($"{browserType} - Opened for test execution.");
                return _threadDriver.Value;
            }
        }

        public static void NavigateToSite()
        {
            GetDriver.Navigate().GoToUrl("http://www.purplebricks.co.uk");
        }

        public static IWebDriver GetDriver
        {
            get { return _threadDriver.Value; }
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
