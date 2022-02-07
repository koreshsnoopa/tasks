using NUnit.Framework;

namespace selenium_task_tests
{
    [TestFixture]
    public class UserAccessTests : CommonConditions
    {
        User testUserYandex = UserCreator.WithCredentialsFromPropertyYandex();

        //[SetUp]
        //public void SetUp()
        //{
        //    driver = DriverSingleton.GetDriver();
        //}

        [Test]
        public void Yandex_LogIn_Test_Correct_Password_And_Username()
        {
            driver.Url = YandexURL;
            var mailPageYandex = new HomePage().LogIn()?.LogInAs(testUserYandex);
            Assert.NotNull(mailPageYandex);
        }

        [Test]
        public void Yandex_LogIn_Test_Empty_Username()
        {
            driver.Url = YandexURL;
            var mailPageYandex = new HomePage()
                .LogIn()?.LogInAs(UserCreator.WithEmptyUsernameYandex());

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void Yandex_LogIn_Test_Empty_Password()
        {
            driver.Url = YandexURL;
            var mailPageYandex = new HomePage()
                .LogIn()?.LogInAs(UserCreator.WithEmptyPasswordYandex());

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void Yandex_LogIn_Test_Correct_Password_And_Incorrect_Username()
        {
            driver.Url = YandexURL;
            var mailPageYandex = new HomePage()
                .LogIn()?.LogInAs(UserCreator.WithIncorrectUsernameYandex());

            Assert.IsNull(mailPageYandex);
        }

        [Test]
        public void Yandex_LogIn_Test_Incorrect_Password_And_Correct_Username()
        {
            driver.Url = YandexURL;
            var mailPageYandex = new HomePage()
                .LogIn()?.LogInAs(UserCreator.WithIncorrectPasswordYandex());

            Assert.IsNull(mailPageYandex);
        }
    }
}
