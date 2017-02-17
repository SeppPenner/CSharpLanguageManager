using System;

namespace Languages.Exceptions
{
    [Serializable]
    public class LanguageInitializationException : Exception
    {
        public LanguageInitializationException()
        {
        }

        public LanguageInitializationException(string message)
            : base(message)
        {
        }

        public LanguageInitializationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}