using System;
using NLog;

namespace SeleniumTaskTests
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
            try
            {
                passwordInputPage = usernameInpuPage.InputUsermame(user.Username);
            }
            catch (ArgumentException ex)
            {
                logger.Error($"User with username: {user.Username} and password: {user.Password} is not logged in:{ex.Message}");
                return null;
            }
            if(passwordInputPage == null)
            {
                return null;
                logger.Error($"User with username: {user.Username} and password: {user.Password} is not logged in");
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
            if (mailsPage == null)
            {
                logger.Error($"User with username: {user.Username} and password: {user.Password} is not logged in");
                return mailsPage;
            }

            logger.Info($"User with username: {user.Username} and password: {user.Password} logged in successfully");
            return mailsPage;
        }
    }
}
