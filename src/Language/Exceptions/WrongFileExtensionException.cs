// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WrongFileExtensionException.cs" company="Hämmer Electronics">
//   Copyright (c) 2020 All rights reserved.
// </copyright>
// <summary>
//   An <see cref="Exception" /> that is thrown whenever the file extension is wrong.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Exceptions;

/// <summary>
///     An <see cref="Exception" /> that is thrown whenever the file extension is wrong.
/// </summary>
[Serializable]
public class WrongFileExtensionException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="WrongFileExtensionException"/> class.
    /// </summary>
    public WrongFileExtensionException()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="WrongFileExtensionException"/> class.
    /// </summary>
    /// <param name="message">The <see cref="Exception" /> message to be shown.</param>
    public WrongFileExtensionException(string message)
        : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="WrongFileExtensionException"/> class.
    /// </summary>
    /// <param name="message">The <see cref="Exception" /> message to be shown.</param>
    /// <param name="inner">The inner The <see cref="Exception" /> to be shown.</param>
    public WrongFileExtensionException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
