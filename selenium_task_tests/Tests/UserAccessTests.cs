using NUnit.Framework;

namespace SeleniumTaskTests
{
    [TestFixture]
    public class UserAccessTests : CommonConditions
    {
        User testUserYandex = UserCreator.WithCredentialsFromPropertyYandex();

        [Test]
        public void YandexLogInTestCorrectPasswordAndUsername()
        {
            driver.Url = YandexURL;
            var mailPageYandex = new HomePage().LogIn()?.LogInAs(testUserYandex);
            Assert.NotNull(mailPageYandex);
        }

        [Test]
        public void YandexLogInTestEmptyUsername()
        {
            driver.Url = YandexURL;
            var mailPageYandex = new HomePage()
                .LogIn()?.LogInAs(UserCreator.WithEmptyUsernameYandex());

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void YandexLogInTestEmptyPassword()
        {
            driver.Url = YandexURL;
            var mailPageYandex = new HomePage()
                .LogIn()?.LogInAs(UserCreator.WithEmptyPasswordYandex());

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void YandexLogInTestCorrectPasswordAndIncorrectUsername()
        {
            driver.Url = YandexURL;
            var mailPageYandex = new HomePage()
                .LogIn()?.LogInAs(UserCreator.WithIncorrectUsernameYandex());

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void YandexLogInTestIncorrectPasswordAndCorrectUsername()
        {
            driver.Url = YandexURL;
            var mailPageYandex = new HomePage()
                .LogIn()?.LogInAs(UserCreator.WithIncorrectPasswordYandex());

            Assert.IsNull(mailPageYandex);
        }
    }
}
