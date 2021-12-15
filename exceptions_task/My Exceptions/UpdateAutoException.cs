using System;
namespace exceptions_task
{
    public class UpdateAutoException : Exception
    {
        public UpdateAutoException(string message)
            : base(message)
        {
        }
    }
}
