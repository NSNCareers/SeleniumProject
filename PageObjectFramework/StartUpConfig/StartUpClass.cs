using System;
using CoreFramework.BrowserConfig;
using NUnit.Framework;
using PageObjectFramework.IOC;

namespace PageObjectFramework.StartUpConfig
{
    [TestFixture]
    public class StartUpClass
    {
        public StartUpClass()
        {
        }

        [OneTimeSetUp]
        public void StartUp()
        {
            // Register dependencies
            ResolveDependency.RegisterAndResolveDependencies();
            // Open Browser session
            Session.StartBrowser();
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            Session.CloseBrowser();
        }
    }
}
