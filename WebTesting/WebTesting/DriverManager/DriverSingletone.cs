using Microsoft.SqlServer.Server;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace WebTesting
{
    internal class DriverSingletone
    {
        private static WebDriver _instance;

        public static WebDriver GetDriver(string Browser)
        {
            if (_instance == null)
            {
                switch(Browser.ToLower())
                {
                    case "firefox":
                        {
                            new DriverManager().SetUpDriver(new FirefoxConfig());
                            _instance = new FirefoxDriver();
                            break;
                        }
                    case "chrome":
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig());
                            _instance = new ChromeDriver();
                            break;
                        }
                    case "edge":
                        {
                            new DriverManager().SetUpDriver(new EdgeConfig());
                            _instance = new EdgeDriver();
                            break;
                        }
                    default: break; 
                }
            }
            return _instance;
        }
        public static void CloseDriver()
        {
            _instance.Quit();
            _instance = null;
        }

    }
}
