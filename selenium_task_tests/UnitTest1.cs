using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_task_tests
{
    public class Tests
    {
        static string FirstAccountUsername = "firstaccount33@yandex.by";
        static string FirstAccountPassword = "firstaccountpassword";
        static string SecondAccoutUsername = "second_account33@yahoo.com";
        static string SecondAccountPassword = "secondaccountpassword";
        static string Message = "Test message from first account.";
        static string NewName = "Иванов Иван";


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Yandex_LogIn_Test_Correct_Password_And_Username()
        {
            IWebDriver driverYandexTest = new ChromeDriver();
            driverYandexTest.Url = "https://mail.yandex.by/";
            HomePage homePageYandex = new HomePage(driverYandexTest);
            var logInPagesYandex = homePageYandex.LogIn();

            var mailPageYandex = logInPagesYandex.LogInAs(FirstAccountUsername, FirstAccountPassword);

            Assert.NotNull(mailPageYandex);
        }

        [Test]
        public void Yandex_LogIn_Test_Enpty_Username()
        { 
            IWebDriver driverYandexTest = new ChromeDriver();
            driverYandexTest.Url = "https://mail.yandex.by/";
            HomePage homePageYandex = new HomePage(driverYandexTest);
            var logInPagesYandex = homePageYandex.LogIn();

            var mailPageYandex = logInPagesYandex.LogInAs(string.Empty, FirstAccountPassword);

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void Yandex_LogIn_Test_Empty_Password()
        {
            IWebDriver driverYandexTest = new ChromeDriver();
            driverYandexTest.Url = "https://mail.yandex.by/";
            HomePage homePageYandex = new HomePage(driverYandexTest);
            var logInPagesYandex = homePageYandex.LogIn();

            var mailPageYandex = logInPagesYandex.LogInAs(FirstAccountUsername, string.Empty);

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void Yandex_LogIn_Test_Correct_Password_And_Incorrect_Username()
        {
            IWebDriver driverYandexTest = new ChromeDriver();
            driverYandexTest.Url = "https://mail.yandex.by/";
            HomePage homePageYandex = new HomePage(driverYandexTest);
            var logInPagesYandex = homePageYandex.LogIn();

            var mailPageYandex = logInPagesYandex.LogInAs("sometestmail@yandex.ru", FirstAccountPassword);

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void Yandex_LogIn_Test_Incorrect_Password_And_Correct_Username()
        {
            IWebDriver driverYandexTest = new ChromeDriver();
            driverYandexTest.Url = "https://mail.yandex.by/";
            HomePage homePageYandex = new HomePage(driverYandexTest);
            var logInPagesYandex = homePageYandex.LogIn();

            var mailPageYandex = logInPagesYandex.LogInAs(FirstAccountUsername, "111111111");

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void Mail_Is_Deliverd()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.yahoo.com/";
            var homePageYahoo = new YahooHomePage(driver);
            var logInPageYahoo = homePageYahoo.GoToLogIn();
            var mainPageYahoo = logInPageYahoo.LogInAs(SecondAccoutUsername, SecondAccountPassword);
            YahooMailPage mailPageYahoo = mainPageYahoo.GoToMails();
            int mailsAmount = mailPageYahoo.GetNumberOfMails();
            driver.Navigate().GoToUrl("https://mail.yandex.by/");
            HomePage yandexHome = new HomePage(driver);
            LogInPages logIn = yandexHome.LogIn();
            MailsPage mailsPage = logIn.LogInAs(FirstAccountUsername, FirstAccountPassword);
            mailsPage.SendEmail(SecondAccoutUsername, "To check", Message);
            driver.Url = "https://www.yahoo.com/";  
            var mainPage2 = new YahooMainPage(driver);
     
            int newMailsAmount = mainPage2.GoToMails().GetNumberOfMails();

            Assert.AreEqual(mailsAmount, newMailsAmount);
        }

        [Test]
        public void Mail_Is_Unread()
        {
            IWebDriver driverYahoo = new ChromeDriver();
            driverYahoo.Url = "https://www.yahoo.com/";
            var homePageYahoo = new YahooHomePage(driverYahoo);
            var logInPageYahoo = homePageYahoo.GoToLogIn();
            var mainPageYahoo = logInPageYahoo.LogInAs(SecondAccoutUsername, SecondAccountPassword);
            YahooMailPage mailPageYahoo = mainPageYahoo.GoToMails();

            Assert.IsTrue(mailPageYahoo.IsLastMailUnread());
        }

        [Test]
        public void Senders_Name_Is_Correct()
        {
            IWebDriver driverYahoo = new ChromeDriver();
            driverYahoo.Url = "https://www.yahoo.com/";
            var homePageYahoo = new YahooHomePage(driverYahoo);
            var logInPageYahoo = homePageYahoo.GoToLogIn();
            var mainPageYahoo = logInPageYahoo.LogInAs(SecondAccoutUsername, SecondAccountPassword);
            YahooMailPage mailPageYahoo = mainPageYahoo.GoToMails();

            string actualName = mailPageYahoo.GetMailSenderUsername(1);

            Assert.AreEqual(FirstAccountUsername, actualName);
        }

        [Test]
        public void Sended_Message_Ang_Actual_Are_Equal()
        {
            IWebDriver driverYahoo = new ChromeDriver();
            driverYahoo.Url = "https://www.yahoo.com/";
            var homePageYahoo = new YahooHomePage(driverYahoo);
            var logInPageYahoo = homePageYahoo.GoToLogIn();
            var mainPageYahoo = logInPageYahoo.LogInAs(SecondAccoutUsername, SecondAccountPassword);
            YahooMailPage mailPageYahoo = mainPageYahoo.GoToMails();

            string actualMessage = mailPageYahoo.ReadTheMailAndGetText(1);

            Assert.AreEqual(Message, actualMessage);
        }

        [Test]
        public void Name_Is_Changed()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.yahoo.com/";
            var homePageYahoo = new YahooHomePage(driver);
            var logInPageYahoo = homePageYahoo.GoToLogIn();
            var mainPageYahoo = logInPageYahoo.LogInAs(SecondAccoutUsername, SecondAccountPassword);
            YahooMailPage mailPageYahoo = mainPageYahoo.GoToMails();
            mailPageYahoo.WriteMail(FirstAccountUsername, "New name", NewName);

            IWebDriver driver2 = new ChromeDriver();
            driver2.Url = "https://mail.yandex.by/";
            HomePage yandexHome = new HomePage(driver2);
            LogInPages logIn = yandexHome.LogIn();
            MailsPage mailsPage = logIn.LogInAs(FirstAccountUsername, FirstAccountPassword);
            string nameToChange = mailsPage.ReadTheMailAndGetText(1);
            var settingsPage = mailsPage.GoToSettings().ChangeInformationAboutSender();
            
            settingsPage.ChangeName(nameToChange);

            Assert.AreEqual(nameToChange, settingsPage.GetName());
            
        }

    }
}
