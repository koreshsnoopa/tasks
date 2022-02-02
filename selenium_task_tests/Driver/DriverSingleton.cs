using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace selenium_task_tests
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
                _driver = new ChromeDriver();
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
