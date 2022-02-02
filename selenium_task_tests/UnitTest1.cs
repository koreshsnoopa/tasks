using System;
using System.IO;
using System.Threading;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace selenium_task_tests
{
    public class Tests 
    {
        static string Message = "";
        static string NewName = "Иванов Иван";
        User testUserYandex = UserCreator.WithCredentialsFromPropertyYandex();
        User testUserYahoo = UserCreator.WithCredentialsFromPropertyYahoo();
        //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
        Logger logger = LogManager.GetCurrentClassLogger();
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverSingleton.GetDriver();
            DriverSingleton.GetDriver().Manage().Window.Maximize();
        }

        [TearDown]
        public void StopBrowser()
        {
            DateTime dt = new DateTime();
            var result = TestContext.CurrentContext.Result.Outcome;
            if (result.Equals(ResultState.Failure) || result.Equals(ResultState.Error))
            {
                var screenFile = ((ITakesScreenshot)DriverSingleton.GetDriver()).GetScreenshot();
                screenFile
                    .SaveAsFile($"/Users/marialukasova/Projects/epam_tasks/selenium_task_tests/bin/Debug/netcoreapp3.1/screenshots/{DateTime.Now.ToString("dd_MM_yy_HH_mm_ss")}.png", ScreenshotImageFormat.Png);
            }
            DriverSingleton.CloseDriver();
        }

        [Test]
        public void Yandex_LogIn_Test_Correct_Password_And_Username()
        {
            //var driver2 = new FirefoxDriver();
            //driver2.Url = "https://mail.yandex.by/";
            driver.Url = "https://mail.yandex.by/";
            HomePage homePageYandex = new HomePage(driver);
            var logInPagesYandex = homePageYandex.LogIn();
            var mailPageYandex = logInPagesYandex.LogInAs(testUserYandex);

            Assert.NotNull(mailPageYandex);
        }

        [Test]
        public void Yandex_LogIn_Test_Empty_Username()
        {
            driver.Url = "https://mail.yandex.by/";
            HomePage homePageYandex = new HomePage(driver);
            var logInPagesYandex = homePageYandex.LogIn();

            var mailPageYandex = logInPagesYandex.LogInAs(UserCreator.WithEmptyUsernameYandex());

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void Yandex_LogIn_Test_Empty_Password()
        {
            driver.Url = "https://mail.yandex.by/";
            HomePage homePageYandex = new HomePage(driver);
            var logInPagesYandex = homePageYandex.LogIn();

            var mailPageYandex = logInPagesYandex.LogInAs(UserCreator.WithEmptyPasswordYandex());

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void Yandex_LogIn_Test_Correct_Password_And_Incorrect_Username()
        {
            driver.Url = "https://mail.yandex.by/";
            HomePage homePageYandex = new HomePage(driver);
            var logInPagesYandex = homePageYandex.LogIn();

            var mailPageYandex = logInPagesYandex.LogInAs(UserCreator.WithIncorrectUsernameYandex());

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void Yandex_LogIn_Test_Incorrect_Password_And_Correct_Username()
        {
            driver.Url = "https://mail.yandex.by/";
            HomePage homePageYandex = new HomePage(driver);
            var logInPagesYandex = homePageYandex.LogIn();

            var mailPageYandex = logInPagesYandex.LogInAs(UserCreator.WithIncorrectPasswordYandex());

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void Mail_Is_Deliverd()
        {
            driver.Url = "https://www.yahoo.com/";
            var homePageYahoo = new YahooHomePage(driver);
            var logInPageYahoo = homePageYahoo.GoToLogIn();
            var mainPageYahoo = logInPageYahoo.LogInAs(testUserYahoo);
            YahooMailPage mailPageYahoo = mainPageYahoo.GoToMails();
            int mailsAmount = mailPageYahoo.GetNumberOfMails();
            driver.Navigate().GoToUrl("https://mail.yandex.by/");
            HomePage yandexHome = new HomePage(driver);
            LogInPages logIn = yandexHome.LogIn();
            MailsPage mailsPage = logIn.LogInAs(testUserYandex);
            mailsPage.SendEmail(testUserYahoo.Username, "To check", Message);
            driver.Url = "https://www.yahoo.com/";
            var mainPage2 = new YahooMainPage(driver);

            int newMailsAmount = mainPage2.GoToMails().GetNumberOfMails();

            Assert.AreEqual(mailsAmount, newMailsAmount);
        }

        [Test]
        public void Mail_Is_Unread()
        {
            driver.Url = "https://www.yahoo.com/";
            var homePageYahoo = new YahooHomePage(driver);
            var logInPageYahoo = homePageYahoo.GoToLogIn();
            var mainPageYahoo = logInPageYahoo.LogInAs(testUserYahoo);
            YahooMailPage mailPageYahoo = mainPageYahoo.GoToMails();

            Assert.IsTrue(mailPageYahoo.IsLastMailUnread());
        }

        [Test]
        public void Senders_Name_Is_Correct()
        {
            driver.Url = "https://www.yahoo.com/";
            var homePageYahoo = new YahooHomePage(driver);
            var logInPageYahoo = homePageYahoo.GoToLogIn();
            var mainPageYahoo = logInPageYahoo.LogInAs(testUserYahoo);
            YahooMailPage mailPageYahoo = mainPageYahoo.GoToMails();

            string actualName = mailPageYahoo.GetMailSenderUsername(1);

            Assert.AreEqual(testUserYandex.Username, actualName);
        }

        [Test]
        public void Sended_Message_And_Actual_Are_Equal()
        {
            driver.Url = "https://www.yahoo.com/";
            var homePageYahoo = new YahooHomePage(driver);
            var logInPageYahoo = homePageYahoo.GoToLogIn();
            var mainPageYahoo = logInPageYahoo.LogInAs(testUserYahoo);
            YahooMailPage mailPageYahoo = mainPageYahoo.GoToMails();

            string actualMessage = mailPageYahoo.ReadTheMailAndGetText(1);

            Assert.AreEqual(Message, actualMessage);
        }

        //[Test]
        //public void Name_Is_Changed()
        //{
        //    driver.Url = "https://www.yahoo.com/";
        //    var homePageYahoo = new YahooHomePage(driver);
        //    var logInPageYahoo = homePageYahoo.GoToLogIn();
        //    var mainPageYahoo = logInPageYahoo.LogInAs(testUserYahoo);
        //    YahooMailPage mailPageYahoo = mainPageYahoo.GoToMails();
        //    mailPageYahoo.WriteMail(testUserYandex.Username, "New name", NewName);
        //    driver.Url = "https://mail.yandex.by/";
        //    HomePage yandexHome = new HomePage(driver);
        //    LogInPages logIn = yandexHome.LogIn();
        //    MailsPage mailsPage = logIn.LogInAs(testUserYandex);
        //    string nameToChange = mailsPage.ReadTheMailAndGetText(1);
        //    var settingsPage = mailsPage.GoToSettings().ChangeInformationAboutSender();

        //    Assert.AreEqual(nameToChange, settingsPage.GetName());
        //}

    }
}
