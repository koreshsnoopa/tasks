using System;
using NLog;
using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class YahooMailPage : WebPage
    {
        By NewMailButtonXPath = By.XPath("//a[@data-test-id='compose-button']");
        By NumberOfMailsXPath = By.XPath("//span[contains(@title,'Inbox')]/following-sibling::span/span");
        By MailsTextXPath = By.XPath("//div[contains(@class,'msg-body')]/descendant::div[4]");

        IWebElement _newMailButton;
        IWebElement _numberOfMails;
        IWebElement _mail;
        IWebElement _mailsText;

        Logger logger = LogManager.GetCurrentClassLogger();
       
        public YahooMailPage() : base()
        {
            _newMailButton = _driver.FindElement(NewMailButtonXPath);
            _numberOfMails = _driver.FindElement(NumberOfMailsXPath);
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
            return _driver.FindElement(By.XPath($"//li[count(a[@role])=1][{numberOfMail}]/a"))
                .GetAttribute("data-test-read") == "false";
        }

        public string GetMailSenderUsername(int numberOfMail)
        {
            return _driver.FindElement(By.XPath($"//li[count(a[@role])=1][{numberOfMail}]//div[@data-test-id='senders']/span"))
                .GetAttribute("title");
        }

        public Message GetMail(int numberOfMail)
        {
            string sendersName = GetMailSenderUsername(numberOfMail);
            string reciversName;
            string text;
            string theme;

            _mail = _driver.FindElement(By.XPath($"//li[count(a[@role])=1][{numberOfMail}]"));
            _mail.Click();
            _mailsText = _driver.FindElement(MailsTextXPath);
            text = _mailsText.Text;
            reciversName = _driver.FindElement(By.XPath("//span[@data-test-id='message-to']")).GetAttribute("title");
            theme = _driver.FindElement(By.XPath("//span[@data-test-id='message-group-subject-text']")).Text;
            _driver.Navigate().Back();
                  
            return new Message(sendersName, reciversName, theme, text);
        }
    }
}
