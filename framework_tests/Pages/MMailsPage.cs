using System;
using NLog;
using OpenQA.Selenium;

namespace framework_tests
{
    public class MMailsPage : WebPage
    {
        By EmailNameLocator = By.XPath("//div[@id='egen']");
        By GoToMailLocator = By.XPath("//span[contains(text(),'Проверить')]/..");

        IWebElement _goToMails;

        Logger logger = LogManager.GetCurrentClassLogger();

        public MMailsPage()
        {
            _goToMails = _driver.FindElement(GoToMailLocator);
        }

        public string GetEmailName()
        {
            string emailName = _driver.FindElement(EmailNameLocator).Text;
            logger.Info($"Generated email: {emailName}");
            return emailName;
        }

        public MUnreadMails GoToMails()
        {
            _goToMails.Click();
            return new MUnreadMails();
        }
    }
}
