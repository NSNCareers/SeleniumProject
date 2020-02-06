using System;
using NUnit.Framework;
using PageObjectFramework.Interfaces;
using PageObjectFramework.StartUpConfig;

namespace TestFramework.Tests
{
    [TestFixture]
    public class SearchTest1 : StartUpClass
    {
        private readonly IHomePage _homePage;
        private readonly ISearchPage _searchPage;

        public SearchTest1(IHomePage homePage, ISearchPage searchPage)
        {
            _homePage = homePage;
            _searchPage = searchPage;
        }

        [OneTimeSetUp]
        public void SetUp()
        {

        }

        [OneTimeTearDown]
        public void Teardown()
        {

        }



        [Test,Category("Check page titel")]
        public void AssertPageTitel()
        {
            var titel = _homePage.GetPageTitel();
            var pageTitel = "";
            Assert.AreEqual(titel,pageTitel);
            _homePage.EnterSearchString("CV10 8QY");
        }

        [Test, Category("Check page titel")]
        public void AssertTextOnPage()
        {
            _searchPage.ClickOnElement();
            var titel =_searchPage.GetPageTitel();
            var pageTitel = "";
            Assert.AreEqual(titel, pageTitel);
        }
    }
}
