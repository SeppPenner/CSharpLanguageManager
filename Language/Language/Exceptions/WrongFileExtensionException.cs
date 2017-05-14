using System;

namespace Languages.Exceptions
{
    /// <summary>
    ///     An <see cref="Exception" /> that is thrown whenever the file extension is wrong
    /// </summary>
    [Serializable]
    public class WrongFileExtensionException : Exception
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public WrongFileExtensionException()
        {
        }

        /// <summary>
        ///     Constructor with message
        /// </summary>
        /// <param name="message">The <see cref="Exception" /> message to be shown</param>
        public WrongFileExtensionException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Constructor with message and inner <see cref="Exception" /> message
        /// </summary>
        /// <param name="message">The <see cref="Exception" /> message to be shown</param>
        /// <param name="inner">The inner The <see cref="Exception" /> to be shown</param>
        public WrongFileExtensionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}