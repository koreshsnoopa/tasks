using System;
using NLog;
using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class YahooLogInPages : WebPage
    {
        YahooInputPasswordPage passwordPage;
        YahooInputUsernamePage usernamePage;
        YahooMainPage mainPage;
        Logger logger = LogManager.GetCurrentClassLogger();

        public YahooLogInPages(IWebDriver driver) : base(driver)
        {
            usernamePage = new YahooInputUsernamePage(_driver);
        }

        public YahooMainPage LogInAs(User user)
        {
            string url1 = _driver.Url;
            try
            {
                passwordPage = usernamePage.InputUsername(user.Username);
            }
            catch(ArgumentException ex)
            {
                logger.Error($"User with username: {user.Username} and password: {user.Password} is not logged in: {ex.Message}");
                return null;
            }
            string url2 = _driver.Url;
            if (url1.Equals(url2))
            {
                logger.Error($"User with username: {user.Username} and password: {user.Password} is not logged in");
                return null;
            }
            try
            {
               mainPage = passwordPage.InputPassword(user.Password);
            }
            catch(ArgumentException ex)
            {
                logger.Error($"User with username: {user.Username} and password: {user.Password} is not logged in: {ex.Message}");
                return null;
            }
            string url3 = _driver.Url;
            if (url3.Equals(url2))
            {
                logger.Error($"User with username: {user.Username} and password: {user.Password} is not logged in");
                return null;
            }

            logger.Info($"User with username: {user.Username} and password: {user.Password} logged in successfully");
            return mainPage;
        }
    }
}
