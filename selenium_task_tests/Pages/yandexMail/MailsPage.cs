using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NLog;
using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class MailsPage : WebPage 
    {
        static string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        static string NewMailButtonXPath = "//a[@href='#compose']";
        static string ReciverUsernameXPath = "//span[text()='Кому']/following::div[1]/child::div/child::div";
        static string ThemeInputXPath = "//input[@name='subject']";
        static string MessageInputXPath = "//div[@role='textbox']";
        static string SendButtonXPath = "//div[@class='composeReact__footer']//button";
        static string MailsXPath = "//a[contains(@href,'#message')]";
        static string MailsTextXPath = "//div[@dir]";
        static string SettingsButtonXPath = "//button[contains(@class,'Settings')]";
        static string AllSettingsButtonXPath = "//a[@href='#setup']";
        static string BackToMailsXPath = "//a[contains(text(), 'Вернуться во')]";
        static string NumberOfUnreadMailsXPath = "//a[contains(@class,'Counters')]";

        IWebElement _newMailButton;
        IWebElement _sendButton;
        IWebElement _reciverUsernameInput;
        IWebElement _themeInputField;
        IWebElement _messageInputField;
        IWebElement _mailTextField;
        IWebElement _settingsButton;
        IWebElement _allSettings;
        IWebElement backToMailButton;

        Logger logger = LogManager.GetCurrentClassLogger();

        public MailsPage() : base()
        {
            _newMailButton = FindElementByXPath(NewMailButtonXPath);
            _sendButton = FindElementByXPath(SettingsButtonXPath);
            _settingsButton = FindElementByXPath(SettingsButtonXPath);
        }

        public void InputReciverUsername(string username)
        {
            if (string.IsNullOrEmpty(username) || !Regex.IsMatch(username, pattern, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Reciver's username is not valid!");
            }
            _newMailButton.Click();
            _reciverUsernameInput = FindElementByXPath(ReciverUsernameXPath);
            _reciverUsernameInput.SendKeys(username);
        }

        public void InputMailsTheme(string theme)
        {
            _themeInputField = FindElementByXPath(ThemeInputXPath);
            _themeInputField.SendKeys(theme);
        }

        public void InputMailsMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Message can't be empty!");
            }
            _messageInputField = FindElementByXPath(MessageInputXPath);
            _messageInputField.SendKeys(message);
        }

        public void SendEmail(Message message)
        {
            try
            {
                InputReciverUsername(message.ReciversName);
            }
            catch (ArgumentException ex)
            {
                logger.Error($"Message is not sended: {ex.Message}");
            }
            try
            {
                InputMailsMessage(message.Text);
            }
            catch (ArgumentException ex)
            {
                logger.Error($"Message is not sended: {ex.Message}");
            }

            if (!string.IsNullOrEmpty(message.Theme))
            {
                InputMailsTheme(message.Theme);
            }
            _sendButton = FindElementByXPath(SendButtonXPath);
            _sendButton.Click();
            backToMailButton = FindElementByXPath(BackToMailsXPath);
            backToMailButton.Click();
            logger.Info($"Message to: {message.ReciversName} is sended seccessfylly");
        }

        public bool IsUnread(int numberOfMail)
        {
            return
                FindElementByXPath($"//div[contains(@class,'List')]/div[{numberOfMail}]//*[contains(@class,'toggleable')]")
                .GetAttribute("title") == "Отметить как прочитанное";
        }

        public int GetNumberOfUnredMails()
        {
            return int.Parse(FindElementByXPath(NumberOfUnreadMailsXPath).Text);
        }
        //public string ReadTheMailAndGetText(int numberOfMail)
        //{
        //    var _mails = _driver.FindElements(By.XPath(MailsXPath));
        //    _mails[numberOfMail - 1].Click();
        //    _mailTextField = FindElementByXPath(MailsTextXPath);
        //    string text = _mailTextField.Text;
        //    _driver.Navigate().Back();
        //    return text;
        //}

        public string GetMailSenderUsername(int numberOfMail)
        {
            return FindElementByXPath($"//div[contains(@class,'List')]/div[{numberOfMail}]//*[contains(@class,'FromText')]")
                .GetAttribute("title");
        }

        public Message GetMail(int numberOfMail)
        {
            string sendersName = GetMailSenderUsername(numberOfMail);
            string reciversName;
            string text;
            string theme;

            var _mails = _driver.FindElements(By.XPath(MailsXPath));
            _mails[numberOfMail - 1].Click();

            _mailTextField = FindElementByXPath(MailsTextXPath);
            text = _mailTextField.Text;

            reciversName = FindElementByXPath("//span[contains(@class,'ContactBadge')]").GetAttribute("title");
            theme = FindElementByXPath("//span[contains(@class,'subject')]").Text;
            _driver.Navigate().Back();

            return new Message(sendersName, reciversName, theme, text);
        }

        public SettingsPage GoToSettings()
        {
            _settingsButton.Click();
            _allSettings = FindElementByXPath(AllSettingsButtonXPath);
            _allSettings.Click();
            return new SettingsPage();
        }
    }
}
