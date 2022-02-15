using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class YahooInputUsernamePage : WebPage
    {
        const string PATTERN = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
         @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        By InputUsernameID = By.Id("login-username");
        By NextButtonID = By.Id("login-signin");

        IWebElement _inputUsername;
        IWebElement _nextButton;

        public YahooInputUsernamePage() : base()
        {
            _inputUsername = _driver.FindElement(InputUsernameID);
            _nextButton = _driver.FindElement(NextButtonID);
        }

        public YahooInputPasswordPage InputUsername(string username)
        {
            if (string.IsNullOrEmpty(username) || !Regex.IsMatch(username, PATTERN, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Email addres is not valid!");
            }
            _inputUsername.SendKeys(username);
            _nextButton.Click();

            return new YahooInputPasswordPage();
        }

    }
}