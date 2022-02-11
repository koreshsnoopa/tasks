using NUnit.Framework;

namespace SeleniumTaskTests
{
    [TestFixture]
    public class MailsTests : CommonConditions
    {
        User testUserYandex = UserCreator.WithCredentialsFromProperty("yandex");
        User testUserYahoo = UserCreator.WithCredentialsFromProperty("yahoo");
        Message testMessage;

        [Test]
        public void MailIsDeliverdAndCorrect()
        {
            driver.Navigate().GoToUrl(YANDEX_URL);
            testMessage = MessageCreator.WithCredentialsFromProperty(testUserYandex.Username, testUserYahoo.Username, MessageCreator.SOME_THEME);
            new HomePage().LogIn()?.LogInAs(testUserYandex)?.SendEmail(testMessage);
            driver.Navigate().GoToUrl(YAHOO_URL);
            var pageMails = new YahooHomePage().GoToLogIn()?.LogInAs(testUserYahoo)?.GoToMails();
            int i = 1;
            bool isFound = false;
            int nubmerOfUnrMails = pageMails.GetNumberOfUnreadMails();

            while (i <= nubmerOfUnrMails)
            {
                if (pageMails.IsMailUnread(i) &&
                    pageMails.GetMailSenderUsername(i).Equals(testMessage.SendersName))
                {
                   isFound = pageMails.GetMail(i).Equals(testMessage);
                }
                if (isFound == true) break;
                i++;
            }

            Assert.IsTrue(isFound);
        }
    }
}
