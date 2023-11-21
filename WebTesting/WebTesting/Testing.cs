using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting
{
    [TestFixture]
    internal class Testing
    {
        private WebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new EdgeDriver();
            Driver.Manage().Window.Maximize();
        }
        [Test]
        public void testSearchBar()
        {
            HomePage homePage = new HomePage(Driver, TimeSpan.FromSeconds(4));
            SearchPage searchPage = homePage.getPageOfSearchQuery("Dezmall\n");

            searchPage.clickUsersTab();

            //Driver.Quit();

            Assert.IsTrue(searchPage.getElementsOfSearchQuery().ToList().Count > 0);
        }
        [Test]
        public void testRestrictedRules()
        {
            HomePage homePage = new HomePage(Driver, TimeSpan.FromSeconds(6));
            SearchPage searchPage = homePage.getPageOfSearchQuery("QueenComplex\n");

            searchPage.clickUsersTab();

            UserPage userPage = searchPage.getUserPage("QueenComplex");

            userPage.clickArtTab();

            //Driver.Quit();

            Assert.IsNotNull(userPage.getRestrictedArt());
        }
    }
}
