// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageNotLoadedException.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   An <see cref="Exception" /> that is thrown whenever the <see cref="Language" /> is not loaded correctly.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Exceptions;

/// <summary>
///     An <see cref="Exception" /> that is thrown whenever the <see cref="Language" /> is not loaded correctly.
/// </summary>
[Serializable]
public class LanguageNotLoadedException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LanguageNotLoadedException"/> class.
    /// </summary>
    public LanguageNotLoadedException()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="LanguageNotLoadedException"/> class.
    /// </summary>
    /// <param name="message">The <see cref="Exception" /> message to be shown.</param>
    public LanguageNotLoadedException(string message)
        : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="LanguageNotLoadedException"/> class.
    /// </summary>
    /// <param name="message">The <see cref="Exception" /> message to be shown.</param>
    /// <param name="inner">The inner The <see cref="Exception" /> to be shown.</param>
    public LanguageNotLoadedException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
