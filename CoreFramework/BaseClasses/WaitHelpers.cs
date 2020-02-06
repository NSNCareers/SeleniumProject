using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CoreFramework.BaseClasses
{
     public abstract partial class BaseClass
    {

        public bool WaitTillElementVisible(By by, int timeout = 20)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                // Report
                return false;
            }
            return true;
        }

        public void WaitTillElementExist(By by, int timeout = 20)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(ExpectedConditions.ElementExists(by));
            }
            catch (Exception e)
            {
                // Report
            }
        }

        public void WaitTillElementIsClickable(By by, int timeout = 20)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (Exception e)
            {
                // Report
            }
        }

        public void WaitTillElementContainsString(By by, string text, int timeout = 20)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));
            }
            catch (Exception e)
            {
               // Report
            }
        }

        public void WaitTillElementIsInVisible(By by, int timeout = 20)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (Exception e)
            {
                // Report
            }
        }

        public void WaitUntillPageFullyLoaded(int timeout = 20)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
            }
            catch (Exception ex)
            {
                // Report
            }
        }
    }
}
