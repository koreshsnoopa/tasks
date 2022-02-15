using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class YahooHomePage : WebPage
    {
        By GoToLogInPageXPath = By.XPath("//input[@name='crumb']/following-sibling::a[text()='Sign in']");

        IWebElement _goToLoginPages;

        public YahooHomePage() : base()
        {
            _goToLoginPages = _driver.FindElement(GoToLogInPageXPath);
        }

        public YahooLogInPages GoToLogIn()
        {
            _goToLoginPages.Click();
            return new YahooLogInPages();
        }
    }
}

