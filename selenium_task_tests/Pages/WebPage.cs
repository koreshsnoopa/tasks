using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public abstract class WebPage
    {
        protected IWebDriver _driver;

        protected WebPage()
        {
            _driver = DriverSingleton.GetDriver();
        }
    }
}
