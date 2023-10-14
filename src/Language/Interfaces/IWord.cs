// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWord.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The <see cref="Word" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Interfaces;

/// <inheritdoc cref = "IWord" />.
/// <summary>
///     The <see cref="Word" /> interface.
/// </summary>
/// <seealso cref = "IWord" />.
public interface IWord
{
    /// <inheritdoc cref = "IWord" />.
    /// <summary>
    ///     Gets or sets the key of the <see cref="Word" />.
    /// </summary>
    /// <seealso cref = "IWord" />.
    string Key { get; set; }

    /// <inheritdoc cref = "IWord" />.
    /// <summary>
    ///     Gets or sets value of the <see cref="Word" />.
    /// </summary>
    /// <seealso cref = "IWord" />.
    string Value { get; set; }
}
