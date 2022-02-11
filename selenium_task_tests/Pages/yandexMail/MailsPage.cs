using System;
using System.Text.RegularExpressions;
using NLog;
using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class MailsPage : WebPage 
    {
        const string PATTERN = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        By NewMailButtonXPath = By.XPath("//a[@href='#compose']");
        By ReciverUsernameXPath = By.XPath("//span[text()='Кому']/following::div[1]/child::div/child::div");
        By ThemeInputXPath = By.XPath("//input[@name='subject']");
        By MessageInputXPath = By.XPath("//div[@role='textbox']");
        By SendButtonXPath = By.XPath("//div[@class='composeReact__footer']//button");
        By MailsXPath = By.XPath("//a[contains(@href,'#message')]");
        By MailsTextXPath = By.XPath("//div[@dir]");
        By SettingsButtonXPath = By.XPath("//button[contains(@class,'Settings')]");
        By AllSettingsButtonXPath = By.XPath("//a[@href='#setup']");
        By BackToMailsXPath = By.XPath("//a[contains(text(), 'Вернуться во')]");
        By NumberOfUnreadMailsXPath = By.XPath("//a[contains(@class,'Counters')]");

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
            _newMailButton = _driver.FindElement(NewMailButtonXPath);
            _sendButton = _driver.FindElement(SettingsButtonXPath);
            _settingsButton = _driver.FindElement(SettingsButtonXPath);
        }

        public void InputReciverUsername(string username)
        {
            if (string.IsNullOrEmpty(username) || !Regex.IsMatch(username, PATTERN, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Reciver's username is not valid!");
            }
            _newMailButton.Click();
            _reciverUsernameInput = _driver.FindElement(ReciverUsernameXPath);
            _reciverUsernameInput.SendKeys(username);
        }

        public void InputMailsTheme(string theme)
        {
            _themeInputField = _driver.FindElement(ThemeInputXPath);
            _themeInputField.SendKeys(theme);
        }

        public void InputMailsMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Message can't be empty!");
            }
            _messageInputField = _driver.FindElement(MessageInputXPath);
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
            _sendButton = _driver.FindElement(SendButtonXPath);
            _sendButton.Click();
            backToMailButton = _driver.FindElement(BackToMailsXPath);
            backToMailButton.Click();
            logger.Info($"Message to: {message.ReciversName} is sended seccessfylly");
        }

        public bool IsUnread(int numberOfMail)
        {
            return
                _driver.FindElement(By.XPath($"//div[contains(@class,'List')]/div[{numberOfMail}]//*[contains(@class,'toggleable')]"))
                .GetAttribute("title") == "Отметить как прочитанное";
        }

        public int GetNumberOfUnredMails()
        {
            return int.Parse(_driver.FindElement(NumberOfUnreadMailsXPath).Text);
        }

        public string GetMailSenderUsername(int numberOfMail)
        {
            return _driver.FindElement(By.XPath($"//div[contains(@class,'List')]/div[{numberOfMail}]//*[contains(@class,'FromText')]"))
                .GetAttribute("title");
        }

        public Message GetMail(int numberOfMail)
        {
            string sendersName = GetMailSenderUsername(numberOfMail);
            string reciversName;
            string text;
            string theme;

            var _mails = _driver.FindElements(MailsXPath);
            _mails[numberOfMail - 1].Click();
            _mailTextField = _driver.FindElement(MailsTextXPath);
            text = _mailTextField.Text;
            reciversName = _driver.FindElement(By.XPath("//span[contains(@class,'ContactBadge')]")).GetAttribute("title");
            theme = _driver.FindElement(By.XPath("//span[contains(@class,'subject')]")).Text;
            _driver.Navigate().Back();

            return new Message(sendersName, reciversName, theme, text);
        }

        public SettingsPage GoToSettings()
        {
            _settingsButton.Click();
            _allSettings = _driver.FindElement(AllSettingsButtonXPath);
            _allSettings.Click();
            return new SettingsPage();
        }
    }
}
