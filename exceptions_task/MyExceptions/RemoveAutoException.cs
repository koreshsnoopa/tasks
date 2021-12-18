using System;
namespace exceptions_task
{
    public class RemoveAutoException : Exception
    {
        public RemoveAutoException(string message)
            : base(message)
        {
        }
    }
}
