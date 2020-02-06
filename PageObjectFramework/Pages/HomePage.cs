using System;
using CoreFramework.BaseClasses;
using OpenQA.Selenium;
using PageObjectFramework.Interfaces;

namespace PageObjectFramework.Pages
{
    public class HomePage : BaseClass, IHomePage
    {
        private static string pageName = "HomePage";
        private static By locator = By.CssSelector("");

        public HomePage() : base(pageName, locator)
        {
        }

        public void EnterSearchString(string text)
        {
            var locator = By.CssSelector("");
            EnterText(locator, text);
        }

        public string GetPageTitel()
        {
            var titel = driver.Title;

            return titel;
        }
    }
}
