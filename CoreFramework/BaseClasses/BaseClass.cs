using System;
using CoreFramework.BrowserConfig;
using OpenQA.Selenium;

namespace CoreFramework.BaseClasses
{
    public class BaseClass 
    {
        private IWebDriver driver = Session.Driver;
        private readonly string _pageName;
        private readonly By _by;

        public BaseClass(string pageName,By by)
        {
            _pageName = pageName;
            _by = by;
            this.OnPage();
        }

        private bool OnPage()
        {
            WaitHelpers.WaitUntillPageFullyLoaded();
            var boolResults = WaitHelpers.WaitTillElementVisible(_by);
            if (!boolResults)
            {
                // Report with page name
                Console.WriteLine($"Unable to find element on page {_pageName}");
                return false;
            }
            return true;
        }
    }
}
