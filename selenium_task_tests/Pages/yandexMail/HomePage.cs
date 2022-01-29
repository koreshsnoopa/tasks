using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class HomePage : WebPage
    {
        static string LogInButtonXPath = "//span[text()='Войти']/parent::a";

        private IWebElement _logInButton;

        public HomePage(IWebDriver driver) : base(driver)
        {
            _logInButton = FindElementByXPath(LogInButtonXPath);
        }

        public LogInPages LogIn()
        {
            _logInButton.Click();
            return new LogInPages(_driver);
        }


    }
}
