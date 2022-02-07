using System;
using System.Collections.Generic;
using System.Threading;
using NLog;
using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class YahooMailPage : WebPage
    {
        static string NewMailButtonXPath = "//a[@data-test-id='compose-button']";
        static string NumberOfMailsXPath = "//span[contains(@title,'Inbox')]/following-sibling::span/span";
        static string MailsTextXPath = "//div[contains(@class,'msg-body')]/descendant::div[4]";
        static string MailsXPath = "//span[@role='gridcell'][@title][not(@data-test-id)]";

        IWebElement _newMailButton;
        IWebElement _numberOfMails;
        IWebElement _mail;
        IWebElement _mailsText;
        IWebElement _inboxMail;

        Logger logger = LogManager.GetCurrentClassLogger();
        List<string> names = new List<string>();
        List<bool> isUnread = new List<bool>();
       
        public YahooMailPage() : base()
        {
            _newMailButton = FindElementByXPath(NewMailButtonXPath);
            _numberOfMails = FindElementByXPath(NumberOfMailsXPath);

            foreach (var i in _driver.FindElements(By.XPath(MailsXPath)))
            {
                names.Add(i.GetAttribute("title"));
            }

            foreach (var i in _driver.FindElements(By.XPath($"//li[count(a[@role])=1]/a")))
            {
                isUnread.Add(i.GetAttribute("data-test-read") == "false");
            }
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
            Thread.Sleep(100);
            return FindElementByXPath($"//li[count(a[@role])=1][{numberOfMail}]/a")
                .GetAttribute("data-test-read") == "false";
        }

        public string GetMailSenderUsername(int numberOfMail)
        {
            return names[numberOfMail - 1];
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
