namespace SeleniumTaskTests
{
    public class UserCreator
    {
        public const string USERNAME_YANEDX = "firstaccount33@yandex.by";
        public const string PASSWORD_YANDEX = "firstaccountpassword";
        public const string USERNAME_YAHOO = "second_account33@yahoo.com";
        public const string PASSWORD_YAHOO = "secondaccountpassword";

        public static User WithCredentialsFromProperty(string website)
        {
            if (website.Equals("yandex"))
            {
                return new User(USERNAME_YANEDX, PASSWORD_YANDEX);
            }
            else if(website.Equals("yahoo"))
            {
                return new User(USERNAME_YAHOO, PASSWORD_YAHOO);
            }
            return null;
        }

        public static User WithEmptyUsernameYandex()
        {
            return new User(string.Empty, PASSWORD_YANDEX);
        }

        public static User WithEmptyPasswordYandex()
        {
            return new User(USERNAME_YANEDX, string.Empty);
        }

        public static User WithIncorrectUsernameYandex()
        {
            return new User("someincorrectemail@yandex.ru", PASSWORD_YANDEX);
        }

        public static User WithIncorrectPasswordYandex()
        {
            return new User(USERNAME_YANEDX, PASSWORD_YAHOO);
        }
    }
}
