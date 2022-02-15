using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class YahooWriteMailPage : WebPage
    {
        const string PATTERN = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        By ReiversUsernameInputID = By.Id("message-to-field");
        By ThemeInputXPath = By.XPath("//input[@data-test-id]");
        By MessageInputXPath = By.XPath("//div[@role='textbox']");
        By SendButtonXPath = By.XPath("//button[@data-test-id='compose-send-button']");

        IWebElement _reciversUsernameInput;
        IWebElement _themeInput;
        IWebElement _messageInput;
        IWebElement _sendButton;

        public YahooWriteMailPage() : base()
        {
            _reciversUsernameInput = _driver.FindElement(ReiversUsernameInputID);
            _themeInput = _driver.FindElement(ThemeInputXPath);
            _messageInput = _driver.FindElement(MessageInputXPath);
            _sendButton = _driver.FindElement(SendButtonXPath);
        }

        public YahooMailPage SendEmail(Message message)
        {
            if (string.IsNullOrEmpty(message.ReciversName) || !Regex.IsMatch(message.ReciversName, PATTERN, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Reciver's username is not valid!");
            }
            if (string.IsNullOrEmpty(message.Text))
            {
                throw new ArgumentException("Message can't be empty!");
            }
            _reciversUsernameInput.SendKeys(message.ReciversName);

            if (!string.IsNullOrEmpty(message.Theme))
            {
                _themeInput.SendKeys(message.Theme);
            }
            _messageInput.SendKeys(message.Text);
            _sendButton.Click();
            return new YahooMailPage();
        }
    }
}
