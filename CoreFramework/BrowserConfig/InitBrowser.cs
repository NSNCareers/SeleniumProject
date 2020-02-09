using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace CoreFramework.BrowserConfig
{
    internal class InitBrowser
    {
        public static WebDriverWait wait;
        private static DriverOptions option;
        private static ChromeOptions chromeOptions;
        static string pageLoadWaitTime;
        static string elementLoadWaitTime;
        static string remoteWebDriverWaitTime;


        internal static IWebDriver InitializeDriver(string browserType)
        {
            string hubIpAddress = "";
            remoteWebDriverWaitTime = "";
            elementLoadWaitTime = "";
            pageLoadWaitTime = "";
            IWebDriver _driver = null;
            var browser = browserType.ToLower();

            try
            {
                switch (browser)
                {
                    case "ie":
                        option = new InternetExplorerOptions();
                        option.AddAdditionalCapability("--window-size=1920,1080", true);
                        option.AddAdditionalCapability("--start-maximized", true);
                        option.AddAdditionalCapability("", true);
                        break;

                    case "chromess":
                        chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--window-size=1920,1080");
                        chromeOptions.AddArgument("--start-maximized");
                        break;

                    case "firefox":
                        option = new FirefoxOptions();
                        option.AddAdditionalCapability("--window-size=1920,1080", true);
                        option.AddAdditionalCapability("--start-maximized", true);
                        option.AddAdditionalCapability("", true);
                        break;

                    case "noGridChrome":
                        _driver = new ChromeDriver();
                        option.AddAdditionalCapability("--window-size=1920,1080", true);
                        option.AddAdditionalCapability("--start-maximized", true);
                        option.AddAdditionalCapability("", true);
                        break;

                    case "edge":
                        option = new EdgeOptions();
                        option.AddAdditionalCapability("--window-size=1920,1080", true);
                        option.AddAdditionalCapability("--start-maximized", true);
                        option.AddAdditionalCapability("", true);
                        break;

                    default:
                        _driver = new ChromeDriver();
                        break;
                }


                if (browser.Equals("chrome"))
                {
                    _driver = new RemoteWebDriver(new Uri($"{hubIpAddress}"), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(int.Parse(remoteWebDriverWaitTime)));
                    _driver.Manage().Window.Size = new Size(1920, 1080);
                    _driver.Manage().Window.Maximize();
                }
                else
                {
                    _driver = new RemoteWebDriver(new Uri($"{hubIpAddress}"), option.ToCapabilities(), TimeSpan.FromSeconds(int.Parse(remoteWebDriverWaitTime)));
                    _driver.Manage().Window.Size = new Size(1920, 1080);
                    _driver.Manage().Window.Maximize();
                }
            }
            catch (Exception e)
            {
                throw e;

            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(elementLoadWaitTime));
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(int.Parse(pageLoadWaitTime));
            _driver.Manage().Cookies.DeleteAllCookies();
            var allowsDetection = (OpenQA.Selenium.IAllowsFileDetection)_driver;
            allowsDetection.FileDetector = new LocalFileDetector();
            return _driver;
        }
    }
}
