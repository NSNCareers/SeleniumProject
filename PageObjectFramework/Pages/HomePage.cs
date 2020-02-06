using System;
using CoreFramework.BaseClasses;
using OpenQA.Selenium;

namespace PageObjectFramework.Pages
{
    public class HomePage : BaseClass
    {
        private static string pageName = "HomePage";
        private static By locator = By.CssSelector("");

        public HomePage():base(pageName, locator)
        {
        }



    }
}
