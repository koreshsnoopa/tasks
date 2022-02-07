namespace selenium_task_tests
{
    public class Message
    {
        public string ReciversName { get; set; }
        public string SendersName { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }

        public Message(string sendersUsername, string reciversName, string theme, string text)
        {
            SendersName = sendersUsername;
            ReciversName = reciversName;
            Theme = theme;
            Text = text;
        }

        public Message(string reciversName, string text)
        {
            ReciversName = reciversName;
            Text = text;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Message))
            {
                return false;
            }
            return (ReciversName == ((Message)obj).ReciversName)
                && (SendersName == ((Message)obj).SendersName)
                && (Theme == ((Message)obj).Theme)
                && (Text == ((Message)obj).Text);
        }
    }
}