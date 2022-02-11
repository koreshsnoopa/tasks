using System;
using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class PasswordInputPage : WebPage
    {
        By NextButtonID = By.Id("passp:sign-in");
        By InputPasswordFieldID = By.Id("passp-field-passwd");
        By IncorrectPasswordXPath = By.XPath("//div[text()='Неверный пароль']");

        IWebElement _nextButton;
        IWebElement _inputPasswordField;

        public PasswordInputPage() : base()
        {
            _inputPasswordField = _driver.FindElement(InputPasswordFieldID);
            _nextButton = _driver.FindElement(NextButtonID);
        }

        public MailsPage InputPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is not valid");
            }
            _inputPasswordField.SendKeys(password);
            _nextButton.Click();
            try
            {
                _driver.FindElement(IncorrectPasswordXPath);
            }
            catch
            {
                return new MailsPage();
            }
            return null;
        }
    }
}
