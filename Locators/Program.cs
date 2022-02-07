
using System.Threading;
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
            IWebElement searchLine = driver.FindElement(By.Id("orb-search-q"));
            //IWebElement webElement2 = driver.FindElement(By.LinkText("Sport"));
            searchLine.SendKeys("Sport");
            //webElement2.Click();
            IWebElement searchButton = driver.FindElement(By.XPath("//input[@id='orb-search-q']/following-sibling::button"));
            //searchButton.Click();
            searchButton.Click();
            //IWebElement news = driver.FindElement(By.XPath("//li[@class='orb-nav-newsdotcom']/child::a"));
            //IWebElement sport = driver.FindElement(By.XPath("//li[@class='orb-nav-newsdotcom']/following-sibling::li[1]/child::a"));
            //sport.Click();
            Thread.Sleep(100000);
            driver.Close();
        }
    }
}
