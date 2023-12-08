using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace WebTesting.PageObject
{
    internal class OwnUserPage : AbstractPage
    {
        private By artsTabLocator = By.CssSelector("nav[class=\"header-nav-buttons\"] > a[class=\"header-nav-button-art\"]");
        private By listArtsLocator = By.CssSelector("div[class=\"portalitem-art-icons-medium\"]");
        private By ratedAArtsLocator = By.CssSelector("div[title=\"Rated A\"]");

        public OwnUserPage(WebDriver driver, TimeSpan timeforWait) : base(driver, timeforWait)
        {
            
        }
        public void clickArtsTab()
        {
            Waiter.Until(ExpectedConditions.ElementExists(artsTabLocator)).Click();
        }
        public SupportPage getSupportPage()
        {
            return new SupportPage(Driver, Waiter.Timeout);
        }
        public IEnumerable<IWebElement> getRestrictedContent()
        {
            return Waiter.Until(ExpectedConditions.ElementExists(listArtsLocator)).FindElements(ratedAArtsLocator);
        }
    }
}
