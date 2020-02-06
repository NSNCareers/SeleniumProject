using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace CoreFramework.BaseClasses
{
    public abstract partial class BaseClass
    {

        public IWebElement GetElementOrThrow(IWebElement element, By by)
        {
            try
            {
                var elementLocated = driver.FindElement(by);
                return elementLocated;
            }
            catch (Exception)
            {
               // Report
                return null;
            }
        }

        public IEnumerable<IWebElement> GetElementsOrThrow(IEnumerable<IWebElement> element, By by)
        {
            try
            {
                var elementLocated = driver.FindElements(by);
                return elementLocated;
            }
            catch (Exception)
            {
                // Report
                return null;
            }
        }
    }
}
