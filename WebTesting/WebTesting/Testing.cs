using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.PageObject;
using WebTesting.utils;

namespace WebTesting
{
    [TestFixture]
    internal class Testing
    {
        private WebDriver Driver;
        private TimeSpan Waiter;
        private Logger fileLogger;

        [SetUp]
        public void Setup()
        {
            Driver = DriverSingletone.GetDriver("Edge");
            Driver.Manage().Window.Maximize();

            Waiter = TimeSpan.FromSeconds(30);

            fileLogger = new Logger("Log.txt");
        }
        [TearDown]
        public void Dispose()
        {
            DriverSingletone.CloseDriver();
            fileLogger.CloseStream();
        }
        [Test]
        public void testSearchBar()
        {
            HomePage homePage = new HomePage(Driver, Waiter);
            SearchPage searchPage = homePage.getPageOfSearchQuery("Dezmall\n");

            searchPage.clickUsersTab();
            fileLogger.logToFile("функция clickUsersTab");

            Assert.IsTrue(searchPage.getElementsOfUsers().ToList().Count > 1);
        }
        [Test]
        public void testRestrictedRulesForUnsignedUser()
        {
            HomePage homePage = new HomePage(Driver, Waiter);
            SearchPage searchPage = homePage.getPageOfSearchQuery("QueenComplex\n");

            searchPage.clickUsersTab();
            fileLogger.logToFile("функция clickUsersTab");

            UserPage userPage = searchPage.getUserPage("QueenComplex");

            userPage.clickArtTab();
            fileLogger.logToFile("функция clickArtTab");

            Assert.IsNotNull(userPage.getRestrictedArt());
        }
        [Test]
        public void testRestrictedRulesForUserLower13()
        {
            LogInPage logInPage = new LogInPage(Driver, Waiter);
            OwnUserPage ownUserPage = logInPage.getOwnUser(UserGenerator.GetUserLower13());

            ownUserPage.clickArtsTab();
            fileLogger.logToFile("функция clickArtsTab");

            Assert.IsTrue(ownUserPage.getRestrictedContent().ToList().Count < 1);
        }
        [Test]
        public void testRestrictedRulesForSigning()
        {
            SignInPage signInPage = new SignInPage(Driver, Waiter);
            
            Assert.IsTrue(signInPage.getErrorByUsername(UserGenerator.GetRestrictedUserByLogin()));
        }
        [Test]
        public void testSearchBarForCyrillicUsers()
        {
            HomePage homePage = new HomePage(Driver, Waiter);
            SearchPage searchPage = homePage.getPageOfSearchQuery("а\n");

            searchPage.clickUsersTab();
            fileLogger.logToFile("функция clickUsersTab");

            Assert.IsTrue(searchPage.getElementsOfUsers().ToList().Count < 0);
        }
        [Test]
        public void testSearchBarForCyrillicContent()
        {
            HomePage homePage = new HomePage(Driver, Waiter);
            SearchPage searchPage = homePage.getPageOfSearchQuery("а\n");

            searchPage.clickAudioTab();
            fileLogger.logToFile("функция clickAudioTab");

            Assert.IsTrue(searchPage.getElementsOfAudio().ToList().Count > 1);
        }
        [Test]
        public void testSearchBarForMarkedUser()
        {
            HomePage homePage = new HomePage(Driver, Waiter);
            SearchPage searchPage = homePage.getPageOfSearchQuery("Dezmall\n");

            searchPage.clickUsersTab();
            fileLogger.logToFile("функция clickUsersTab");

            Assert.IsTrue(searchPage.getElementFromTopOfList("Dezmall"));
        }
        [Test]
        public void testPaymentSystemForLowerPay()
        {
            LogInPage logInPage = new LogInPage(Driver, Waiter);
            OwnUserPage ownUserPage = logInPage.getOwnUser(UserGenerator.GetUserLower13());
            SupportPage supportPage = ownUserPage.getSupportPage();
            string moneyForPay = "0.01";
            
            supportPage.enterMoneyForPay(moneyForPay);
            fileLogger.logToFile("функция enterMoneyForPay");
            supportPage.clickForPayByCreditCard();
            fileLogger.logToFile("функция clickForPayByCreditCard");

            Assert.IsTrue(supportPage.checkMoneyForPay(moneyForPay));
        }
        [Ignore("Waiting for fix bugs")]
        public void testPaymentSystem()
        {
            LogInPage logInPage = new LogInPage(Driver, Waiter);
            OwnUserPage ownUserPage = logInPage.getOwnUser(UserGenerator.GetUserLower13());
            SupportPage supportPage = ownUserPage.getSupportPage();

            supportPage.clickForPayByCreditCard();
            fileLogger.logToFile("функция clickForPayByCreditCard");
            supportPage.enterRequisitesForPayCard(CardGenerator.GetRestrictedCard());
            fileLogger.logToFile("функция enterRequisitesForPayCard");

            Assert.IsTrue(supportPage.getPaymentStatus());
        }
    }
}
