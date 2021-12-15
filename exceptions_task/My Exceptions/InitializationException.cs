using System;
namespace exceptions_task
{
    class InitializationException : Exception
    {
        public InitializationException(string message)
            : base(message)
        {
        }
    }
}
