using OpenQA.Selenium;

namespace framework_tests
{
    public class MailMain : WebPage
    {
        By NewEmailLocator = By.XPath("//a[@href='email-generator']/i/..");

        IWebElement _newEmail;

        public MailMain() : base()
        {
            _newEmail = _driver.FindElement(NewEmailLocator);
        }

        public MMailsPage GenerateNewEmail()
        {
            _newEmail.Click();
            return new MMailsPage();
        }
    }
}
