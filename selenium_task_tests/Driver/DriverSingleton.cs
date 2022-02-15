using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTaskTests
{
    public class DriverSingleton
    {
        private DriverSingleton()
        {
        }

        private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                //_driver = new FirefoxDriver();
                _driver = new ChromeDriver();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _driver.Manage().Window.Maximize();
            }
            return _driver;
        }

        public static void CloseDriver()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
