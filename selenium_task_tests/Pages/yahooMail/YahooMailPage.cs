using System;
using NLog;
using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class YahooMailPage : WebPage
    {
        
        static string NewMailButtonXPath = "//a[@data-test-id='compose-button']";
        static string NumberOfMailsXPath = "//span[contains(@title,'Inbox')]/following-sibling::span/span";
        static string LastInboxMailXPath = "//li[count(a[@role])=1][1]";
        static string MailsTextXPath = "//div[contains(@class,'msg-body')]/descendant::div[4]";

        IWebElement _newMailButton;
        IWebElement _numberOfMails;
        IWebElement _lastInboxMail;
        IWebElement _mail;
        IWebElement _mailsText;
        Logger logger = LogManager.GetCurrentClassLogger();

        public YahooMailPage(IWebDriver driver) : base(driver)
        {
            _newMailButton = FindElementByXPath(NewMailButtonXPath);
            _numberOfMails = FindElementByXPath(NumberOfMailsXPath);
            _lastInboxMail = FindElementByXPath(LastInboxMailXPath);
        }

        public void WriteMail(string username, string theme, string message)
        {
            _newMailButton.Click();
            var writeMailPage = new YahooWriteMailPage(_driver);

            try
            {
                writeMailPage.SendEmail(username, theme, message);
                logger.Info($"Message to: {username} is sended seccessfylly");
            }
            catch (ArgumentException ex)
            {
                logger.Error($"Message is not sended: {ex.Message}");
            }
        }

        public void WriteMail(string username, string message)
        {
            _newMailButton.Click();
            var writeMailPage = new YahooWriteMailPage(_driver);

            try
            {
                writeMailPage.SendEmail(username, message);
                logger.Info($"Message to: {username} is sended seccessfylly");
            }
            catch (ArgumentException ex)
            {
                logger.Error($"Message is not sended: {ex.Message}");
            }
        }

        public int GetNumberOfMails()
        {
            return int.Parse(_numberOfMails.Text);
        }

        public string ReadTheMailAndGetText(int numberOfMail)
        {
            _mail = FindElementByXPath($"//li[count(a[@role])=1][{numberOfMail}]");
            _mail.Click();
            _mailsText = FindElementByXPath(MailsTextXPath);
            string text = _mailsText.Text;
            _driver.Navigate().Back();
            return text;
        }

        public bool IsLastMailUnread()
        {
            if (_lastInboxMail.GetAttribute("data-test-read") == "false")
            {
                return true;
            }
            return false;
        }

        public string GetMailSenderUsername(int numberOfMail)
        {
            var _temp = _driver.FindElements(By.XPath("//span[count(strong)=1]"));

            return _temp[numberOfMail - 1].GetAttribute("title");
        }
    }
}
