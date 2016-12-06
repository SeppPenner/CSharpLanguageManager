using System;

namespace Languages.Exceptions
{
    [Serializable]
    public class WrongFileExtensionException : Exception
    {
        public WrongFileExtensionException()
        {
        }

        public WrongFileExtensionException(string message)
            : base(message)
        {
        }

        public WrongFileExtensionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}