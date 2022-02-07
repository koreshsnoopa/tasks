using System.Threading;
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

        public IWebElement FindElementByXPath(string Xpath)
        {
            int count = 0;
            while(count < 100)
            {
                try
                {
                    return _driver.FindElement(By.XPath(Xpath));
                }
                catch
                {
                    Thread.Sleep(10);
                    count++;
                }
            }

            return null;
        }

        public IWebElement FindElementById(string ID)
        {
            int count = 0;
            while (count < 100)
            {
                try
                {
                    return _driver.FindElement(By.Id(ID));
                }
                catch
                {
                    Thread.Sleep(10);
                    count++;
                }
            }

            return null;
        }

        public IWebElement FindElementByTag(string tag)
        {
            int count = 0;
            while (count < 10)
            {
                try
                {
                    return _driver.FindElement(By.TagName(tag));
                }
                catch
                {
                    Thread.Sleep(10);
                    count++;
                }
            }

            return null;
        }
    }
}
