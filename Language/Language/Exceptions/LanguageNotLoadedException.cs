using Languages.Implementation;
using System;

namespace Languages.Exceptions
{
    /// <summary>
    ///     An <see cref="Exception" /> that is thrown whenever the <see cref="Language" /> is not loaded correctly.
    /// </summary>
    [Serializable]
    public class LanguageNotLoadedException : Exception
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public LanguageNotLoadedException()
        {
        }

        /// <summary>
        ///     Constructor with message.
        /// </summary>
        /// <param name="message">The <see cref="Exception" /> message to be shown.</param>
        // ReSharper disable once UnusedMember.Global
        public LanguageNotLoadedException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Constructor with message and inner <see cref="Exception" /> message.
        /// </summary>
        /// <param name="message">The <see cref="Exception" /> message to be shown.</param>
        /// <param name="inner">The inner The <see cref="Exception" /> to be shown.</param>
        public LanguageNotLoadedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}