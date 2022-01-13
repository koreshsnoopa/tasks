
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locators
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com/");
            //IWebElement webElement = driver.FindElement(By.Id("orb-search-q"));
            IWebElement webElement = driver.FindElement(By.LinkText("Sport"));
           // IWebElement webElement = driver.FindElement(By.XPath());
           // webElement.SendKeys("Sport");
            webElement.Click();

        }
    }
}
