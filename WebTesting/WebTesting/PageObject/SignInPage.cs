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
    internal class SignInPage : AbstractPage
    {
        private By loginLocator = By.XPath(".//input[@placeholder='Select a username']");
        private By passwordLocator = By.XPath(".//input[@type='password']");
        private By emailLocator = By.XPath(".//button[@type='email']");
        private By badUsernameLocator = By.XPath(".//span[text()='Invalid username.']"); 

        public SignInPage(WebDriver driver, TimeSpan timeforWait) : base(driver, timeforWait)
        {
            Driver.Navigate().GoToUrl("https://newgrounds.com/passport/signup/new");
        }
        public bool getErrorByUsername(User user)
        {
            Waiter.Until(ExpectedConditions.ElementExists(loginLocator)).SendKeys(user.GetLogin());
            Waiter.Until(ExpectedConditions.ElementExists(passwordLocator)).SendKeys(user.GetPassword());

            return Waiter.Until(ExpectedConditions.ElementIsVisible(badUsernameLocator)).Displayed;
        }
    }
}
