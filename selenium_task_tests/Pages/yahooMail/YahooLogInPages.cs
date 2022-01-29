using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class YahooLogInPages : WebPage
    {
        YahooInputPasswordPage passwordPage;
        YahooInputUsernamePage usernamePage;

        public YahooLogInPages(IWebDriver driver) : base(driver)
        {
            usernamePage = new YahooInputUsernamePage(_driver);
        }

        public YahooMainPage LogInAs(string username, string password)
        {
            //string url1 = _driver.Url;
            passwordPage = usernamePage.InputUsername(username);
            YahooMainPage mailsPage = passwordPage.InputPassword(password);
            //string url2 = _driver.Url;

            return mailsPage;
        }
    }
}
