using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class YahooMainPage : WebPage
    {
        static string MailButtonID = "ybarMailLink";

        IWebElement _mailButton;

        public YahooMainPage(IWebDriver driver) : base(driver)
        {
            _mailButton = FindElementById(MailButtonID);
        }

        public YahooMailPage GoToMails()
        {
            _mailButton.Click();
            return new YahooMailPage(_driver);
        }

    }
}
