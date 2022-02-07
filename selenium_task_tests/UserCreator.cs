namespace selenium_task_tests
{
    public class UserCreator
    {
        public static string UsernameYandex = "firstaccount33@yandex.by";
        public static string PasswordYandex = "firstaccountpassword";
        public static string UsernameYahoo = "second_account33@yahoo.com";
        public static string PasswordYahoo = "secondaccountpassword";

        public static User WithCredentialsFromPropertyYandex()
        {
            return new User(UsernameYandex, PasswordYandex);
        }

        public static User WithCredentialsFromPropertyYahoo()
        {
            return new User(UsernameYahoo, PasswordYahoo);
        }

        public static User WithEmptyUsernameYandex()
        {
            return new User(string.Empty, PasswordYandex);
        }

        public static User WithEmptyPasswordYandex()
        {
            return new User(UsernameYandex, string.Empty);
        }

        public static User WithEmptyUsernameYahoo()
        {
            return new User(string.Empty, PasswordYahoo);
        }

        public static User WithEmptyPasswordYahoo()
        {
            return new User(UsernameYahoo, string.Empty);
        }

        public static User WithIncorrectUsernameYandex()
        {
            return new User("someincorrectemail@yandex.ru", PasswordYandex);
        }

        public static User WithIncorrectPasswordYandex()
        {
            return new User(UsernameYandex, PasswordYahoo);
        }
    }
}
