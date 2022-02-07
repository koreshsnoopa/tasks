using System;
using NLog;

namespace selenium_task_tests
{
    public class LogInPages : WebPage
    {
        UsernameInputPage usernameInpuPage;
        PasswordInputPage passwordInputPage;
        MailsPage mailsPage;
        Logger logger = LogManager.GetCurrentClassLogger();

        public LogInPages() : base()
        {
            usernameInpuPage = new UsernameInputPage();
        }

        public MailsPage LogInAs(User user)
        {
            string url1 = _driver.Url;
            try
            {
                passwordInputPage = usernameInpuPage.InputUsermame(user.Username);
            }
            catch (ArgumentException ex)
            {
                logger.Error($"User with username: {user.Username} and password: {user.Password} is not logged in:{ex.Message}");
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
                mailsPage = passwordInputPage.InputPassword(user.Password);
            }
            catch (ArgumentException ex)
            {
                logger.Error($"User with username: {user.Username} and password: {user.Password} is not logged in:\n{ex.Message}");
                return null;
            }
            string url3 = _driver.Url;

            if (url3.Equals(url2))
            {
                logger.Error($"User with username: {user.Username} and password: {user.Password} is not logged in");
                return null;
            }

            logger.Info($"User with username: {user.Username} and password: {user.Password} logged in successfully");
            return mailsPage;
        }
    }
}
