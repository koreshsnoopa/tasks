using System.Threading;
using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class YahooWriteMailPage : WebPage
    {
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
            _reciversUsernameInput.SendKeys(username);
            _themeInput.SendKeys(theme);
            _messageInput.SendKeys(message);
            _sendButton.Click();
            Thread.Sleep(10);
            return new YahooMailPage(_driver);
        }
    }
}
