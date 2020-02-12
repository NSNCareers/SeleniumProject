using OpenQA.Selenium;
using static CoreFramework.Enumerations.Enums;

namespace CoreFramework.BrowserConfig
{
    public static class Session
    {
       private static string browserType = Browser.firefox.ToString();

       public static void StartBrowser()
        {
            BrowserSession.OpenBrowser(browserType);
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
