using System;

namespace Languages.Exceptions
{
    [Serializable]
    public class LanguageNotLoadedException : Exception
    {
        public LanguageNotLoadedException()
        {
        }

        public LanguageNotLoadedException(string message)
            : base(message)
        {
        }

        public LanguageNotLoadedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}