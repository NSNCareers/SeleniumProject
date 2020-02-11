﻿using System;
using NUnit.Framework;
using PageObjectFramework.Interfaces;
using PageObjectFramework.IOC;
using PageObjectFramework.StartUpConfig;
using Unity;

namespace TestFramework.Tests
{
    [TestFixture()]
    public class SearchTest15 : StartUpClass
    {
        private IHomePage _homePage;
        private ISearchPage _searchPage;

        [OneTimeSetUp]
        public void SetUp()
        {

        }

        [OneTimeTearDown]
        public void Teardown()
        {

        }



        [Test, Category("Check page titel15")]
        public void AssertPageTitel()
        {
            _homePage = UnityWrapper.Resolve<IHomePage>();
            var titel = _homePage.GetPageTitel();
            var pageTitel = "Purplebricks Estate Agents - You'll Be Totally Sold";
            Assert.AreEqual(titel,pageTitel);
            _homePage.EnterSearchString("CV10 8QY");
            _homePage.ClickOnElementSearchButton();
        }

        [Test, Category("Check page titel15")]
        public void AssertTextOnPage()
        {
            _searchPage = UnityWrapper.Resolve<ISearchPage>();
            var titel =_searchPage.GetPageTitel();
            var pageTitel = "Nuneaton Properties for Sale | Purplebricks";
            Assert.AreEqual(titel, pageTitel);
        }
    }
}
