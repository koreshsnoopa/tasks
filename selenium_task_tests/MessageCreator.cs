namespace selenium_task_tests
{
    public class MessageCreator
    {
        static string NewName = "Ivanov Ivan";
        static string ThemeForName = "New name for you";
        static string SomeTheme = "Song line";
        static string SomeText = "Take me down to the paradise city";

        public static Message WithCredentialsFromProperty(string sendersUsername, string reciversName)
        {
            return new Message(sendersUsername, reciversName, SomeTheme, SomeText);
        }

        public static Message MessageWithNewName(string sendersUsername, string reciversName)
        {
            return new Message(sendersUsername, reciversName, ThemeForName, NewName);
        }
    }
}
