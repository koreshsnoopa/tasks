using System;
using OpenQA.Selenium;

namespace framework_tests
{
    public class MMailsPage : WebPage
    {
        By EmailNameLocator = By.XPath("//div[@id='egen']");
        By GoToMailLocator = By.XPath("//span[contains(text(),'Проверить')]/..");

        IWebElement _goToMails;

        public MMailsPage()
        {
            _goToMails = _driver.FindElement(GoToMailLocator);
        }

        public string GetEmailName()
        {
            return _driver.FindElement(EmailNameLocator).Text;
        }

        public MUnreadMails GoToMails()
        {
            _goToMails.Click();
            return new MUnreadMails();
        }
    }
}
