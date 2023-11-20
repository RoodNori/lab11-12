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
        private EdgeDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new EdgeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://newgrounds.com");
        }
        [Test]
        public void testSearchBar()
        {
            WebDriverWait waitForDownloadPage = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));
            var searchBar = waitForDownloadPage.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("terms")));
            searchBar.SendKeys("Dezmall\n");

            var usersTab = waitForDownloadPage.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("#search-header-nav > div > a:nth-child(6)")));
            usersTab.Click();

            var listOfUsers = waitForDownloadPage.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("itemlist")));
            var Users = listOfUsers.FindElements(By.XPath(".//*"));

            //Driver.Quit();

            Assert.IsTrue(Users.ToList().Count > 0);
        }
    }
}
