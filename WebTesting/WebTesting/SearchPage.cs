using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting
{
    internal class SearchPage
    {
        private By usersTabLocator = By.CssSelector("#search-header-nav > div > a:nth-child(6)");
        private By listSearchQueryLocator = By.ClassName("itemlist");
        private WebDriverWait Waiter;
        private WebDriver Driver;

        public SearchPage(WebDriver driver, TimeSpan timeforWait)
        {
            Driver = driver;
            Waiter = new WebDriverWait(Driver, timeforWait);
        }
        public void clickUsersTab()
        {
            Waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(usersTabLocator)).Click();
        }
        public IEnumerable<IWebElement> getElementsOfSearchQuery()
        {
            return Waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(listSearchQueryLocator)).FindElements(By.XPath("//*"));
        }
        public UserPage getUserPage(string query)
        {
            Waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.LinkText(query))).Click();

            return new UserPage(Driver, Waiter.Timeout);
        }
    }
}
