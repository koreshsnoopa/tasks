namespace selenium_task_tests
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

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
