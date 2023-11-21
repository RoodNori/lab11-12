using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting
{
    internal class UserPage
    {
        private By artsTabLocator = By.CssSelector("#user-header > nav > div > div > a:nth-child(3)");
        private By ratedALocator = By.XPath(".//a[@title='Restricted Art']");
        private By errorLocator = By.ClassName("error");
        private WebDriverWait Waiter;
        private WebDriver Driver;

        public UserPage(WebDriver driver, TimeSpan timeforWait)
        {
            Driver = driver;
            Waiter = new WebDriverWait(Driver, timeforWait);
        }
        public void clickArtTab()
        {
            Waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(artsTabLocator)).Click();
        }
        public IWebElement getRestrictedArt()
        {
            Waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(ratedALocator)).Click();

            return Waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(errorLocator));
        }
    }
}
