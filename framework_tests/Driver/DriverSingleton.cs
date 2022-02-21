using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace framework_tests
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
                if (Environment.GetEnvironmentVariable("browser").Equals("firefox"))
                {
                    _driver = new FirefoxDriver();
                }
                else if (Environment.GetEnvironmentVariable("browser").Equals("chrome"))
                {
                    _driver = new ChromeDriver();
                }
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
