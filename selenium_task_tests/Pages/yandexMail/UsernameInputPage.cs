using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class UsernameInputPage : WebPage
    {
        const string PATTERN = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
               @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        By NextButtonID = By.Id("passp:sign-in");
        By InputUsermaneFieldID = By.Id("passp-field-login");
        By IncorrectUsernameXPath = By.XPath("//div[@role]");

        IWebElement _nextButton;
        IWebElement _inputUsernameField;

        public UsernameInputPage() : base()
        {
            _inputUsernameField = _driver.FindElement(InputUsermaneFieldID);
            _nextButton = _driver.FindElement(NextButtonID);
        }

        public PasswordInputPage InputUsermame(string username)
        {
            if (string.IsNullOrEmpty(username) || !Regex.IsMatch(username, PATTERN, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Email addres is not valid!");
            }
            _inputUsernameField.SendKeys(username);
            
            _nextButton.Click();
            try
            {
                _driver.FindElement(IncorrectUsernameXPath);
            }
            catch
            {
                return new PasswordInputPage();
            }
            return null;
        }
    }
}
