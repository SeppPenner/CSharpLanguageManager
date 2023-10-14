// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageInitializationException.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   An <see cref="Exception" /> that is thrown whenever the <see cref="Language" /> is not initialized correctly.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Exceptions;

/// <summary>
///     An <see cref="Exception" /> that is thrown whenever the <see cref="Language" /> is not initialized correctly.
/// </summary>
[Serializable]
public class LanguageInitializationException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LanguageInitializationException"/> class.
    /// </summary>
    public LanguageInitializationException()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="LanguageInitializationException"/> class.
    /// </summary>
    /// <param name="message">The <see cref="Exception" /> message to be shown.</param>
    public LanguageInitializationException(string message)
        : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="LanguageInitializationException"/> class.
    /// </summary>
    /// <param name="message">The <see cref="Exception" /> message to be shown.</param>
    /// <param name="inner">The inner The <see cref="Exception" /> to be shown.</param>
    public LanguageInitializationException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
