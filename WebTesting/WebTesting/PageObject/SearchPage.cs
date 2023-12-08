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
    internal class SearchPage : AbstractPage
    {
        private By usersTabLocator = By.CssSelector("nav[class=\"searchnav\"] a:nth-child(6)");
        private By audioTabLocator = By.CssSelector("nav[class=\"searchnav\"] a:nth-child(5)");
        private By listUsersLocator = By.XPath(".//ul[@class='itemlist spaced']");
        private By listAudioLocator = By.XPath(".//ul[@class='itemlist spaced']");

        public SearchPage(WebDriver driver, TimeSpan timeforWait) : base(driver, timeforWait)
        {
            
        }
        public void clickUsersTab()
        {
            Waiter.Until(ExpectedConditions.ElementExists(usersTabLocator)).Click();
        }
        public void clickAudioTab()
        {
            Waiter.Until(ExpectedConditions.ElementExists(audioTabLocator)).Click();
        }
        public IEnumerable<IWebElement> getElementsOfUsers()
        {
            return Waiter.Until(ExpectedConditions.ElementExists(listUsersLocator)).FindElements(By.XPath("//*"));
        }
        public IEnumerable<IWebElement> getElementsOfAudio()
        {
            return Waiter.Until(ExpectedConditions.ElementExists(listAudioLocator)).FindElements(By.XPath("//*"));
        }
        public bool getElementFromTopOfList(string username)
        {
            var listOfElements = Waiter.Until(ExpectedConditions.ElementExists(listAudioLocator)).FindElements(By.XPath("//*"));

            int positionInList = 0;

            foreach(var element in listOfElements)
            {
                if (element.FindElements(By.XPath($"//div[@class='item-details-main']//a[text()='{username}']")).ToList().Count < 1)
                    positionInList++;
                else break;
            }
            return positionInList <= 3;
        }
        public UserPage getUserPage(string query)
        {
            Waiter.Until(ExpectedConditions.ElementExists(By.LinkText(query))).Click();

            return new UserPage(Driver, Waiter.Timeout);
        }
    }
}
