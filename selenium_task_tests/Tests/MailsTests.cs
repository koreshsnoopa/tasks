using NUnit.Framework;

namespace selenium_task_tests
{
    [TestFixture]
    public class MailsTests : CommonConditions
    {
        User testUserYandex = UserCreator.WithCredentialsFromPropertyYandex();
        User testUserYahoo = UserCreator.WithCredentialsFromPropertyYahoo();
        Message testMessage;


        [Test]
        public void Mail_Is_Ok()
        {
            driver.Navigate().GoToUrl(YandexURL);
            new HomePage().LogIn()?.LogInAs(testUserYandex)?.SendEmail(testMessage);
            driver.Navigate().GoToUrl(YahooURL);
            testMessage = MessageCreator.WithCredentialsFromProperty(testUserYandex.Username, testUserYahoo.Username);
            var pageMails = new YahooHomePage().GoToLogIn()?.LogInAs(testUserYahoo)?.GoToMails();
            int i = 1;
            bool isFound = false;

            while (i <= pageMails.GetNumberOfUnreadMails())
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
