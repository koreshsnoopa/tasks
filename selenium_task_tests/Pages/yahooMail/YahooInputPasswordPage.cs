using System;
using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class YahooInputPasswordPage : WebPage
    {
        static string PasswordInputID = "login-passwd";
        static string NextButtonID = "login-signin";

        IWebElement _passwordInput;
        IWebElement _nextButton;

        public YahooInputPasswordPage(IWebDriver driver) : base(driver)
        {
            _passwordInput = FindElementById(PasswordInputID);
            _nextButton = FindElementById(NextButtonID);
        }

        public YahooMainPage InputPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is not valid");
            }
            _passwordInput.SendKeys(password);
            _nextButton.Click();

            return new YahooMainPage(_driver);
        }
    }
}
