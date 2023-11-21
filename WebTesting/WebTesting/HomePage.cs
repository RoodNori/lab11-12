using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting
{
    internal class HomePage
    {
        private By searchBarLocator = By.Name("terms");
        private WebDriverWait Waiter;
        private WebDriver Driver;

        public HomePage(WebDriver driver, TimeSpan timeforWait)
        {
            Driver = driver;
            Waiter = new WebDriverWait(Driver, timeforWait);

            Driver.Navigate().GoToUrl("https://newgrounds.com");
        }
        public SearchPage getPageOfSearchQuery(string query)
        {
            Waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(searchBarLocator)).SendKeys(query);
            return new SearchPage(Driver, Waiter.Timeout);
        }

    }
}
