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
                return _threadDriver.Value;
            }
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
