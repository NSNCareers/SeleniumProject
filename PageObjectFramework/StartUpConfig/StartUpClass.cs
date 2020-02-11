using CoreFramework.BrowserConfig;
using NUnit.Framework;
using PageObjectFramework.Interfaces;
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
            ResolveDependency.RegisterAndResolveDependencies();
            Session.StartBrowser();
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            Session.CloseBrowser();
        }

        #region Interfacce declarations

        public readonly IHomePage homePage;
        public readonly ISearchPage searchPage;

        #endregion
    }
}
