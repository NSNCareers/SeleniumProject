using System;
using CoreFramework.BaseClasses;
using OpenQA.Selenium;
using PageObjectFramework.Interfaces;

namespace PageObjectFramework.Pages
{
    public class SearchPage : BaseClass, ISearchPage
    {
        private static string pageName = "SearchPage";
        private static By locator = By.CssSelector("#buttonLogin");

        public SearchPage() : base(pageName, locator)
        {
        }

        public string GetPageTitel()
        {
            var titel = driver.Title;

            return titel;
        }
    }
}
