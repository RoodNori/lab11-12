using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.PageObject;

namespace WebTesting
{
    internal class HomePage : AbstractPage
    {
        private By searchBarLocator = By.XPath(".//div[@class='wrapper']//input[@placeholder='Search Newgrounds...']");

        public HomePage(WebDriver driver, TimeSpan timeforWait) : base(driver, timeforWait)
        {
            Driver.Navigate().GoToUrl("https://newgrounds.com");
        }
        public SearchPage getPageOfSearchQuery(string query)
        {
            Waiter.Until(ExpectedConditions.ElementExists(searchBarLocator)).SendKeys(query);
            return new SearchPage(Driver, Waiter.Timeout);
        }
    }
}
