using System;
namespace exceptions_task
{
    public class GetAutoByParameterException : Exception
    {
        public GetAutoByParameterException(string message)
            : base(message)
        {
        }
    }
}
