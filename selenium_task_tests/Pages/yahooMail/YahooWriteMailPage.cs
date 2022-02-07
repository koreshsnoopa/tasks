using System;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class YahooWriteMailPage : WebPage
    {
        static string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        static string ReiversUsernameInputID = "message-to-field";
        static string ThemeInputXPath = "//input[@data-test-id]";
        static string MessageInputXPath = "//div[@role='textbox']";
        static string SendButtonXPath = "//button[@data-test-id='compose-send-button']";

        IWebElement _reciversUsernameInput;
        IWebElement _themeInput;
        IWebElement _messageInput;
        IWebElement _sendButton;

        public YahooWriteMailPage() : base()
        {
            _reciversUsernameInput = FindElementById(ReiversUsernameInputID);
            _themeInput = FindElementByXPath(ThemeInputXPath);
            _messageInput = FindElementByXPath(MessageInputXPath);
            _sendButton = FindElementByXPath(SendButtonXPath);
        }

        public YahooMailPage SendEmail(Message message)
        {
            if (string.IsNullOrEmpty(message.ReciversName) || !Regex.IsMatch(message.ReciversName, pattern, RegexOptions.IgnoreCase))
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
            Thread.Sleep(10);
            return new YahooMailPage();
        }
    }
}
