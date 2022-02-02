namespace selenium_task_tests
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }
    }
}
