using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class HomePage : WebPage
    {
        static string LogInButtonXPath = "//span[text()='Войти']/parent::a";

        private IWebElement _logInButton;

        public HomePage() : base()
        {
            _logInButton = FindElementByXPath(LogInButtonXPath);
        }

        public LogInPages LogIn()
        {
            _logInButton.Click();
            return new LogInPages();
        }


    }
}
