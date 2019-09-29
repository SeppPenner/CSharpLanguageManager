using Languages.Implementation;
using System;

namespace Languages.Exceptions
{
    /// <summary>
    ///     An <see cref="Exception" /> that is thrown whenever the <see cref="Language" /> is not initialized correctly.
    /// </summary>
    [Serializable]
    public class LanguageInitializationException : Exception
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public LanguageInitializationException()
        {
        }

        /// <summary>
        ///     Constructor with message.
        /// </summary>
        /// <param name="message">The <see cref="Exception" /> message to be shown.</param>
        public LanguageInitializationException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Constructor with message and inner <see cref="Exception" /> message.
        /// </summary>
        /// <param name="message">The <see cref="Exception" /> message to be shown.</param>
        /// <param name="inner">The inner The <see cref="Exception" /> to be shown.</param>
        // ReSharper disable once UnusedMember.Global
        public LanguageInitializationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}