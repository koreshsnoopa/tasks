using System;
using NLog;
using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class YahooMailPage : WebPage
    {
        static string NewMailButtonXPath = "//a[@data-test-id='compose-button']";
        static string NumberOfMailsXPath = "//span[contains(@title,'Inbox')]/following-sibling::span/span";
        static string MailsTextXPath = "//div[contains(@class,'msg-body')]/descendant::div[4]";

        IWebElement _newMailButton;
        IWebElement _numberOfMails;
        IWebElement _mail;
        IWebElement _mailsText;

        Logger logger = LogManager.GetCurrentClassLogger();
       
        public YahooMailPage() : base()
        {
            _newMailButton = FindElementByXPath(NewMailButtonXPath);
            _numberOfMails = FindElementByXPath(NumberOfMailsXPath);
        }

        public void WriteMail(Message message)
        {
            _newMailButton.Click();
            var writeMailPage = new YahooWriteMailPage();

            try
            {
                writeMailPage.SendEmail(message);
                logger.Info($"Message to: {message.ReciversName} is sended seccessfylly");
            }
            catch (ArgumentException ex)
            {
                logger.Error($"Message is not sended: {ex.Message}");
            }
        }

        public int GetNumberOfUnreadMails()
        {
            return int.Parse(_numberOfMails.Text);
        }

        public bool IsMailUnread(int numberOfMail)
        {
            return FindElementByXPath($"//li[count(a[@role])=1][{numberOfMail}]/a")
                .GetAttribute("data-test-read") == "false";
        }

        public string GetMailSenderUsername(int numberOfMail)
        {
            return FindElementByXPath($"//li[count(a[@role])=1][{numberOfMail}]//div[@data-test-id='senders']/span")
                .GetAttribute("title");
        }

        public Message GetMail(int numberOfMail)
        {
            string sendersName = GetMailSenderUsername(numberOfMail);
            string reciversName;
            string text;
            string theme;

            _mail = FindElementByXPath($"//li[count(a[@role])=1][{numberOfMail}]");
            _mail.Click();
            _mailsText = FindElementByXPath(MailsTextXPath);
            text = _mailsText.Text;
            reciversName = FindElementByXPath("//span[@data-test-id='message-to']").GetAttribute("title");
            theme = FindElementByXPath("//span[@data-test-id='message-group-subject-text']").Text;
            _driver.Navigate().Back();
                  
            return new Message(sendersName, reciversName, theme, text);
        }
    }
}
