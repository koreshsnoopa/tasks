using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

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
                //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver",@"/path/to/where/you/ve/put/chromedriver.exe")

                //_driver = new FirefoxDriver();

                //ChromeOptions ops = new ChromeOptions();
                //ops.AddArguments("--disable-notifications");
                _driver = new ChromeDriver();

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
