using System;
using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class PasswordInputPage : WebPage
    {
        static string NextButtonID = "passp:sign-in";
        static string InputPasswordFieldID = "passp-field-passwd";

        IWebElement _nextButton;
        IWebElement _inputPasswordField;

        public PasswordInputPage() : base()
        {
            _inputPasswordField = FindElementById(InputPasswordFieldID);
            _nextButton = FindElementById(NextButtonID);
        }

        public MailsPage InputPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is not valid");
            }
            _inputPasswordField.SendKeys(password);
            _nextButton.Click();
            return new MailsPage();
        }
    }
}
