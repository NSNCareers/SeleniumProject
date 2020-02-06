using System;
using OpenQA.Selenium;

namespace CoreFramework.BaseClasses
{
    public abstract partial class BaseClass
    {

        public void EnterText(By by,string text)
        {
            var element = driver.FindElement(by);

            try
            {
                
                element.SendKeys(text);
            }
            catch (Exception)
            {
                ScrollToView(element);
                element.SendKeys(text);
            }
            finally
            {
                // Report to user unable to click
            }
        }

        public bool ClickOnElement(By by)
        {
            var element = driver.FindElement(by);
            try
            {
                element.Click();
            }
            catch (Exception)
            {
                ScrollToView(element);
                element.Click();
            }
            finally
            {
                // Report to user unable to click
            }

            return element.Selected;
        }

        public bool ClickOnElementJavaScript(By by)
        {
            var element = driver.FindElement(by);

            try
            {
                JavaScriptClick(element);
            }
            catch (Exception)
            {
                ScrollToView(element);
                JavaScriptClick(element);
            }
            finally
            {
                // Report to user unable to click
            }

            return element.Selected;
        }

        private void JavaScriptClick(IWebElement element)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception e)
            {
                // Report
            }
        }

        private void ScrollToView(IWebElement element)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (Exception e)
            {
                // Report
            }
        }
    }
}
