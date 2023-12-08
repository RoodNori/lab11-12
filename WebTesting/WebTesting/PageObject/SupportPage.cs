using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using OpenQA.Selenium.DevTools.V117.SystemInfo;
using WebTesting.model;
using System.Threading;
using System.Security.Policy;
using SeleniumExtras.WaitHelpers;

namespace WebTesting.PageObject
{
    internal class SupportPage : AbstractPage
    {
        private By otherMoneyForPayLocator = By.XPath(".//div[@data-param='month']//a[text()='Other']");
        private By inputMoneyForPayLocator = By.XPath(".//div[@data-param='month']//input[@data-min-price='2.99']");
        private By creditCardLocator = By.XPath(".//div[@data-param='month']//button[@class='credit-card']");
        private By moneyForPayLocator = By.XPath(".//form[@action='/supporter/credit-card']//div[@class='padded']/p");

        private By inputNumberPayCardLocator = By.XPath("//input[@id='Field-numberInput']"); 
        private By inputValidatyPayCardLocator = By.XPath("//input[@id='Field-expiryInput']"); 
        private By inputCVCPayCardLocator = By.XPath("//input[@id='Field-cvcInput']"); 
        private By submitPaymentLocator = By.XPath(".//div[@class='blackout-hover']//div[@class='form-row']/a"); 
        private By errorLocator = By.XPath("//div[@id='payment-errors']");

        public SupportPage(WebDriver driver, TimeSpan timeforWait) : base(driver, timeforWait)
        {
            Driver.Navigate().GoToUrl("https://www.newgrounds.com/supporter");
            Driver.Navigate().GoToUrl("https://www.newgrounds.com/supporter"); // без него переход не осуществляется
        }
        public void enterMoneyForPay(string money)
        {
            Waiter.Until(ExpectedConditions.ElementExists(otherMoneyForPayLocator)).Click();


            Waiter.Until(ExpectedConditions.ElementExists(inputMoneyForPayLocator)).SendKeys(Keys.Control + "A" + Keys.Delete);


            Waiter.Until(ExpectedConditions.ElementExists(inputMoneyForPayLocator)).SendKeys(money);


        }
        public void clickForPayByCreditCard()
        {
            Waiter.Until(ExpectedConditions.ElementExists(creditCardLocator)).Click();


        }
        public bool checkMoneyForPay(string money)
        {
            return Waiter.Until(ExpectedConditions.ElementExists(moneyForPayLocator)).Text.IndexOf(money) < 1;
        }
        public void enterRequisitesForPayCard(PayCard card)
        {
            string Validaty = card.GetPeriodValidaty().Year.ToString();
            Validaty = card.GetPeriodValidaty().Month + Validaty.Substring(2);

            Waiter.Until(ExpectedConditions.ElementIsVisible(inputNumberPayCardLocator)).SendKeys(card.GetCardNumber()); // проблема в условии


            Waiter.Until(ExpectedConditions.ElementIsVisible(inputValidatyPayCardLocator)).SendKeys(Validaty); // проблема в условии


            Waiter.Until(ExpectedConditions.ElementIsVisible(inputCVCPayCardLocator)).SendKeys(card.GetCVC()); // проблема в условии


        }
        public bool getPaymentStatus()
        {
            Waiter.Until(ExpectedConditions.ElementIsVisible(submitPaymentLocator)).Click();



            return Waiter.Until(ExpectedConditions.ElementIsVisible(errorLocator)).Displayed;
        }
    }
}
