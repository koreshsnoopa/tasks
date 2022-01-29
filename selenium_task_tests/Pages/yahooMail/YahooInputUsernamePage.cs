using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class YahooInputUsernamePage : WebPage
    {
        static string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
         @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        static string InputUsernameID = "login-username";
        static string NextButtonID = "login-signin";

        IWebElement _inputUsername;
        IWebElement _nextButton;

        public YahooInputUsernamePage(IWebDriver driver) : base(driver)
        {
            _inputUsername = FindElementById(InputUsernameID);
            _nextButton = FindElementById(NextButtonID);
        }

        public YahooInputPasswordPage InputUsername(string username)
        {
            if (string.IsNullOrEmpty(username) || !Regex.IsMatch(username, pattern, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Email addres is not valid!");
            }
            _inputUsername.SendKeys(username);
            _nextButton.Click();

            return new YahooInputPasswordPage(_driver);
        }

    }
}