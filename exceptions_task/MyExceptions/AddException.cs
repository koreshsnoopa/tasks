using System;
namespace exceptions_task
{
    public class AddException : Exception
    {
        public AddException(string message)
            : base(message)
        {
        }
    }
}
