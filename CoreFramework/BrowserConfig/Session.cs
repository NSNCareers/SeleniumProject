using System;
using CoreFramework.Enumerations;
using OpenQA.Selenium;
using static CoreFramework.Enumerations.Enums;

namespace CoreFramework.BrowserConfig
{
    public static class Session
    {
       private static string browserType = Browser.chrome.ToString();

       public static void StartBrowser()
        {
            BrowserSession.OpenBrowser(browserType);
            BrowserSession.NavigateToSite();
        }

        public static void CloseBrowser()
        {
            BrowserSession.CloseBrowser();
        }

        public static IWebDriver Driver
        {
            get { return BrowserSession.GetDriver; }
        }
    }
}
