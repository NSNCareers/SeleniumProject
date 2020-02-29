﻿using System;
using System.Configuration;
using System.Drawing;
using System.Threading;
using CoreFramework.Config;
using CoreFramework.JsonReader;
using Microsoft.Extensions.Configuration;
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
<<<<<<< HEAD
            string hubIpAddress = JsonConfig.GetJsonValue("HubIpAddress");
=======
<<<<<<< HEAD
            //string hubIpAddress = GetJson.GetJsonString().BaseUrl;
            string hubIpAddress = "http://www.purplebricks.co.uk";
            remoteWebDriverWaitTime = ConfigurationManager.AppSettings.Get("remoteWebdriverWait");
            elementLoadWaitTime = ConfigurationManager.AppSettings.Get("elementWaitTime");
            pageLoadWaitTime = ConfigurationManager.AppSettings.Get("pageLoad");
=======
            string hubIpAddress = "http://159.89.181.18:4444/wd/hub";
>>>>>>> c5783051340e0b9550059f9f2cd6139e13dd563a
            remoteWebDriverWaitTime = "60";
            elementLoadWaitTime = "10";
            pageLoadWaitTime = "10";
>>>>>>> e096591cd0e7a7a14ee8384fb078b3ae42d983b7
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

<<<<<<< HEAD
                    case "chromessss":
=======
                    case "chrome":
>>>>>>> e096591cd0e7a7a14ee8384fb078b3ae42d983b7
                        chromeOptions = new ChromeOptions();
                        //chromeOptions.AddArgument("no-sandbox");

                        //ChromeOptions options = new ChromeOptions();
                        //options.AddArgument("no-sandbox");
                        //ChromeDriver driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
                        //driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));


                        break;

                    case "firefox":
                        option = new FirefoxOptions();

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
                        _driver.Manage().Window.Maximize();
                        _driver.Manage().Cookies.DeleteAllCookies();
                        Thread.Sleep(5000);
                        return _driver;
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
