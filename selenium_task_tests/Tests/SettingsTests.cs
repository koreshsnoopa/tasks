using System;
using NUnit.Framework;

namespace SeleniumTaskTests
{
    [TestFixture]
    public class SettingsTests : CommonConditions
    {
        Message messageWithNewName;
        User testUserYandex = UserCreator.WithCredentialsFromPropertyYandex();
        User testUserYahoo = UserCreator.WithCredentialsFromPropertyYahoo();

        [Test]
        public void NameIsChanged()
        {
            driver.Url = YahooURL;
            messageWithNewName = MessageCreator.MessageWithNewName(testUserYahoo.Username, testUserYandex.Username);
            new YahooHomePage().GoToLogIn()?.LogInAs(testUserYahoo)
                ?.GoToMails()?.WriteMail(messageWithNewName);
            driver.Url = YandexURL;
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
