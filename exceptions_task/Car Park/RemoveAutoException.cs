using System;
namespace exceptions_task.CarPark
{
    public class RemoveAutoException : Exception
    {
        public RemoveAutoException(string message)
            : base(message)
        {
        }
    }
}
