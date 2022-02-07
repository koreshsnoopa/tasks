using OpenQA.Selenium;

namespace SeleniumTaskTests
{
    public class YahooMainPage : WebPage
    {
        static string MailButtonID = "ybarMailLink";

        IWebElement _mailButton;

        public YahooMainPage() : base()
        {
            _mailButton = FindElementById(MailButtonID);
        }

        public YahooMailPage GoToMails()
        {
            _mailButton.Click();
            return new YahooMailPage();
        }

    }
}
