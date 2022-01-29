using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_task
{
    class Program
    {
        static string FistAccountUsername = "firstaccount33@yandex.ru";
        static string FirstAccountPassword = "firstaccountpassword";
        static string SecondAccoutUseraneme = "second_account33@yahoo.com";
        static string SecondAccountPassword = "secondaccountpassword";

        static void Main(string[] args)
        {
            IWebDriver driverYandex = new ChromeDriver();
            driverYandex.Url = "https://mail.yandex.by/";
            HomePage homePageYandex = new HomePage(driverYandex);
            var logInPagesYandex = homePageYandex.LogIn();
            var mailPageYandex = logInPagesYandex.LogInAs(FistAccountUsername, FirstAccountPassword);
            string newNameForFirst = mailPageYandex.ReadTheMailAndGetText(1);
            var settingsPage = mailPageYandex.GoToSettings();
            //settingsPage.ChangeInformationAboutSender().GetName();
            settingsPage.ChangeInformationAboutSender().ChangeName(newNameForFirst);

            //IWebDriver driverYahoo = new ChromeDriver();
            //driverYahoo.Url = "https://www.yahoo.com/";
            //YahooHomePage homePageYahoo = new YahooHomePage(driverYahoo);
            //var logInPageYahoo = homePageYahoo.GoToLogIn();
            //var mainPageYahoo = logInPageYahoo.LogInAs(SecondAccoutUseraneme, SecondAccountPassword);
            //YahooMailPage mailPageYahoo = mainPageYahoo.GoToMails();
            //string newName = "Иван Иванов";
            //mailPageYahoo.WriteMail(FistAccountUsername, "New Name", newName);


            Thread.Sleep(100000);
        }
    }
}
