
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
            
           
        }
    }
}
