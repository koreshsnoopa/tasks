using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class YahooMainPage : WebPage
    {
        By MailButtonID = By.Id("ybarMailLink");

        IWebElement _mailButton;

        public YahooMainPage() : base()
        {
            _mailButton = _driver.FindElement(MailButtonID);
        }

        public YahooMailPage GoToMails()
        {
            _mailButton.Click();
            return new YahooMailPage();
        }

    }
}
