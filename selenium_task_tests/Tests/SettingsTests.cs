using System;
using NUnit.Framework;

namespace SeleniumTaskTests
{
    [TestFixture]
    public class SettingsTests : CommonConditions
    {
        Message messageWithNewName;
        User testUserYandex = UserCreator.WithCredentialsFromProperty("yandex");
        User testUserYahoo = UserCreator.WithCredentialsFromProperty("yahoo");

        [Test]
        public void NameIsChanged()
        {
            driver.Url = YAHOO_URL;
            messageWithNewName = MessageCreator.WithCredentialsFromProperty(testUserYahoo.Username, testUserYandex.Username, MessageCreator.THEME_FOR_NAME);
            new YahooHomePage().GoToLogIn()?.LogInAs(testUserYahoo)
                ?.GoToMails()?.WriteMail(messageWithNewName);
            driver.Url = YANDEX_URL;
            MailsPage mailsPage = new HomePage().LogIn()?.LogInAs(testUserYandex);
            Message mailWithNewNameFromMail;
            string newName = string.Empty;

            int i = 1;
            while (i <= mailsPage.GetNumberOfUnredMails())
            {
                Console.WriteLine(i);
                if (mailsPage.IsUnread(i) && mailsPage.GetMailSenderUsername(i).Equals(testUserYahoo.Username))
                {
                    mailWithNewNameFromMail = mailsPage.GetMail(i);
                    newName = mailWithNewNameFromMail.Text;
                    Console.WriteLine(newName);
                }
                i++;
            }

            var settingsPage = mailsPage.GoToSettings().ChangeInformationAboutSender();
            settingsPage.ChangeName(newName);

            Assert.AreEqual(messageWithNewName.Text, settingsPage.GetName());
        }
    }
}
