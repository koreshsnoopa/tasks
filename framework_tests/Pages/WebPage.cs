using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace framework_tests
{
      public abstract class WebPage
      {
        protected IWebDriver _driver;
        protected WebDriverWait wait;
        

            protected WebPage()
            {
                _driver = DriverSingleton.GetDriver();
                wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            }
      }
}
