using System;
using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class YahooInputPasswordPage : WebPage
    {
        By PasswordInputID = By.Id("login-passwd");
        By NextButtonID = By.Id("login-signin");

        IWebElement _passwordInput;
        IWebElement _nextButton;

        public YahooInputPasswordPage() : base()
        {
            _passwordInput = _driver.FindElement(PasswordInputID);
            _nextButton = _driver.FindElement(NextButtonID);
        }

        public YahooMainPage InputPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is not valid");
            }
            _passwordInput.SendKeys(password);
            _nextButton.Click();

            return new YahooMainPage();
        }
    }
}
