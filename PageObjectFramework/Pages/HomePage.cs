using System;
using System.Threading;
using CoreFramework.BaseClasses;
using OpenQA.Selenium;
using PageObjectFramework.Interfaces;

namespace PageObjectFramework.Pages
{
    public class HomePage : BaseClass, IHomePage
    {
        private static string pageName = "HomePage";
        private static By locator = By.CssSelector("button[data-testid='hero-primary-cta']");

        public HomePage() : base(pageName, locator)
        {
        }

        public void EnterSearchString(string text)
        {
            AcceptCookie();
            Thread.Sleep(5000);
            var locator = By.CssSelector("input[data-testid='nav-desktop-property-search-input']");
            EnterText(locator, text);
        }

        public string GetPageTitel()
        {
            var titel = driver.Title;

            return titel;
        }

        public void ClickOnElementSearchButton()
        {
            var locator = By.CssSelector("button[data-testid='nav-desktop-property-search-button']");
            ClickOnElement(locator);
        }

        private void AcceptCookie()
        {
            var locator = By.CssSelector("div[class='as-oil-l-item']>button");
            var element = driver.FindElement(locator);
            if (element.Displayed)
            {
                ClickOnElement(locator);
            }
        }
    }
}
