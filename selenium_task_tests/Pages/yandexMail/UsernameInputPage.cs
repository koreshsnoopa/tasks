using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class UsernameInputPage : WebPage
    {
        static string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
               @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        static string NextButtonID = "passp:sign-in";
        static string InputUsermaneFieldID = "passp-field-login";

        IWebElement _nextButton;
        IWebElement _inputUsernameField;

        public UsernameInputPage() : base()
        {
            _inputUsernameField = FindElementById(InputUsermaneFieldID);
            _nextButton = FindElementById(NextButtonID);
        }

        public PasswordInputPage InputUsermame(string username)
        {
            if (string.IsNullOrEmpty(username) || !Regex.IsMatch(username, pattern, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Email addres is not valid!");
            }
            _inputUsernameField.SendKeys(username);
            _nextButton.Click();
            return new PasswordInputPage();
        }
    }
}
