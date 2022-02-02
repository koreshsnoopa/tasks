using System;
using System.Text.RegularExpressions;
using System.Threading;
using NLog;
using OpenQA.Selenium;

namespace selenium_task_tests
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

        public YahooWriteMailPage(IWebDriver driver) : base(driver)
        {
            _reciversUsernameInput = FindElementById(ReiversUsernameInputID);
            _themeInput = FindElementByXPath(ThemeInputXPath);
            _messageInput = FindElementByXPath(MessageInputXPath);
            _sendButton = FindElementByXPath(SendButtonXPath);
        }

        public YahooMailPage SendEmail(string username, string theme, string message)
        {
            if (string.IsNullOrEmpty(username) || !Regex.IsMatch(username, pattern, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Reciver's username is not valid!");
            }
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Message can't be empty!");
            }
            _reciversUsernameInput.SendKeys(username);
            _themeInput.SendKeys(theme);
            _messageInput.SendKeys(message);
            _sendButton.Click();
            Thread.Sleep(10);
            return new YahooMailPage(_driver);
        }

        public YahooMailPage SendEmail(string username, string message)
        {
            if (string.IsNullOrEmpty(username) || !Regex.IsMatch(username, pattern, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Reciver's username is not valid!");
            }
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Message can't be empty!");
            }
            _reciversUsernameInput.SendKeys(username);
            _messageInput.SendKeys(message);
            _sendButton.Click();
            Thread.Sleep(10);

            return new YahooMailPage(_driver);
        }
    }
}
