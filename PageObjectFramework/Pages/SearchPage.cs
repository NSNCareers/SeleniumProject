using System;
using CoreFramework.BaseClasses;
using OpenQA.Selenium;

namespace PageObjectFramework.Pages
{
    public class SearchPage:BaseClass
    {
        private static string pageName = "HomePage";
        private static By locator = By.CssSelector("");

        public SearchPage() : base(pageName, locator)
        {
        }
    }
}
