using System;

namespace ToggSdk.Exceptions
{
    public class TogglApiException : Exception
    {
        public TogglApiException() : base()
        {

        }

        public TogglApiException(string message) : base(message)
        {

        }

        public TogglApiException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
