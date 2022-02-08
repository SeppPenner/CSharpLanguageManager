// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILanguage.cs" company="Hämmer Electronics">
//   Copyright (c) 2020 All rights reserved.
// </copyright>
// <summary>
//   The <see cref="ILanguage" /> interface to store different <see cref="Language" />s.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Interfaces;

/// <summary>
///     The <see cref="ILanguage" /> interface to store different <see cref="Language" />s.
/// </summary>
public interface ILanguage
{
    /// <summary>
    ///     Gets or sets the identifier of the <see cref="Language" /> according to
    ///     https://msdn.microsoft.com/de-de/library/ee825488(v=cs.20).aspx.
    /// </summary>
    string Identifier { get; set; }

    /// <summary>
    ///     Gets or sets the name of the <see cref="Language" />.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    ///     Gets or sets the <see cref="List{T}" /> of <see cref="Word" />s in the loaded <see cref="Language" />.
    /// </summary>
    List<Word> Words { get; set; }

    /// <summary>
    ///     Gets a word by a key.
    /// </summary>
    /// <param name="key">The key that is defined for the <see cref="Word" />.</param>
    /// <returns>The <see cref="Word" /> defined by the key.</returns>
    string? GetWord(string key);

    /// <summary>
    ///     Gets the current <see cref="CultureInfo" />.
    /// </summary>
    CultureInfo GetCulture();
}
