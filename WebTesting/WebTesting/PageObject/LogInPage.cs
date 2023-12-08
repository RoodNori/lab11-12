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
    internal class LogInPage : AbstractPage
    {
        private By loginLocator = By.XPath(".//input[@placeholder='Username or Email']");
        private By passwordLocator = By.XPath(".//input[@type='password']"); 
        private By buttonLocator = By.XPath(".//button[@name='login']");

        public LogInPage(WebDriver driver, TimeSpan timeforWait) : base(driver, timeforWait)
        {
            Driver.Navigate().GoToUrl("https://newgrounds.com/passport");
        }
        public OwnUserPage getOwnUser(User user)
        {
            Waiter.Until(ExpectedConditions.ElementExists(loginLocator)).SendKeys(user.GetLogin());
            Waiter.Until(ExpectedConditions.ElementExists(passwordLocator)).SendKeys(user.GetPassword());
            Waiter.Until(ExpectedConditions.ElementExists(buttonLocator)).Click();

            return new OwnUserPage(Driver, Waiter.Timeout);
        }
    }
}
