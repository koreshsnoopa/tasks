using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class HomePage : WebPage
    {
        By LogInButtonXPath = By.XPath("//span[text()='Войти']/parent::a");

        private IWebElement _logInButton;

        public HomePage() : base()
        {
            _logInButton = _driver.FindElement(LogInButtonXPath);
        }

        public LogInPages LogIn()
        {
            _logInButton.Click();
            return new LogInPages();
        }
    }
}
