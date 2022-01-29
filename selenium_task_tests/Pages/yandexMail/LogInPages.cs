using System;
using OpenQA.Selenium;

namespace selenium_task_tests
{
    public class LogInPages : WebPage
    {
        UsernameInputPage usernameInpuPage;
        PasswordInputPage passwordInputPage;
        MailsPage mailsPage;

        public LogInPages(IWebDriver driver) : base(driver)
        {
            usernameInpuPage = new UsernameInputPage(_driver);
        }

        public MailsPage LogInAs(string usermane, string password)
        {
            string url1 = _driver.Url;
            try
            {
                passwordInputPage = usernameInpuPage.InputUsermame(usermane);
            }
            catch (ArgumentException ex)
            {
                return null;
            }
            string url2 = _driver.Url;
            if (url1.Equals(url2))
            {
                return null;
            }
            try
            {
                return passwordInputPage.InputPassword(password);
            }
            catch (ArgumentException ex)
            {
                return null;
            }
            string url3 = _driver.Url;
            if (url2.Equals(url3))
            {
                return null;
            }

            return mailsPage;
        }
        
    }
}
