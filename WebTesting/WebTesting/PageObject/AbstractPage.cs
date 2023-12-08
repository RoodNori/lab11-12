using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.PageObject
{
    internal abstract class AbstractPage
    {
        protected WebDriverWait Waiter;
        protected WebDriver Driver;
        public delegate void LogOp(string info);
        public event LogOp methodSucces;

        protected AbstractPage(WebDriver driver, TimeSpan timeforWait)
        {
            Driver = driver;
            Waiter = new WebDriverWait(Driver, timeforWait);
        }

    }
}
