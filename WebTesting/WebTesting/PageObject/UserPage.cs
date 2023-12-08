using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using WebTesting.PageObject;

namespace WebTesting
{
    internal class UserPage : AbstractPage
    {
        private By artsTabLocator = By.XPath(".//nav[@class='user-header-nav']//a[@href='/art']");
        private By ratedAArtLocator = By.XPath(".//a[@title='Restricted Art']");
        private By errorLocator = By.XPath(".//h2[@class='error']");

        public UserPage(WebDriver driver, TimeSpan timeforWait) : base(driver, timeforWait)
        {
            
        }
        public void clickArtTab()
        {
            Waiter.Until(ExpectedConditions.ElementExists(artsTabLocator)).Click();
        }
        public IWebElement getRestrictedArt()
        {
            Waiter.Until(ExpectedConditions.ElementExists(ratedAArtLocator)).Click();

            return Waiter.Until(ExpectedConditions.ElementExists(errorLocator));
        }
    }
}
