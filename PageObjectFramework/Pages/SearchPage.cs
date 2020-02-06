using System;
using CoreFramework.BaseClasses;
using OpenQA.Selenium;
using PageObjectFramework.Interfaces;

namespace PageObjectFramework.Pages
{
    public class SearchPage : BaseClass, ISearchPage
    {
        private static string pageName = "HomePage";
        private static By locator = By.CssSelector("");

        public SearchPage() : base(pageName, locator)
        {
        }

        public void ClickOnElement()
        {
            var locator = By.CssSelector("");
            ClickOnElement(locator);
        }

        public string GetPageTitel()
        {
            var titel = driver.Title;

            return titel;
        }
    }
}
