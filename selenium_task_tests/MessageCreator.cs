namespace SeleniumTaskTests
{
    public class MessageCreator
    {
        const string NEW_NAME = "Ivanov Ivan";
        public const string THEME_FOR_NAME = "New name for you";
        public const string SOME_THEME = "Song line";
        const string SOME_TEXT = "Take me down to the paradise city";

        public static Message WithCredentialsFromProperty(string sendersUsername, string reciversName, string theme)
        {
            if (theme.Equals(SOME_THEME))
            {
                return new Message(sendersUsername, reciversName, SOME_THEME, SOME_TEXT);
            }
            else if (theme.Equals(THEME_FOR_NAME))
            {
                return new Message(sendersUsername, reciversName, THEME_FOR_NAME, NEW_NAME);
            }
            return null;
        }
    }
}
