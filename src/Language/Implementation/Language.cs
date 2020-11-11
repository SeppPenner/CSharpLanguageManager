// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Language.cs" company="Hämmer Electronics">
//   Copyright (c) 2020 All rights reserved.
// </copyright>
// <summary>
//   The <see cref="Language" /> interface to store different <see cref="Language" />s.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using Languages.Interfaces;

    /// <inheritdoc cref = "ILanguage" />.
    /// <summary>
    ///     The <see cref="Language" /> interface to store different <see cref="Language" />s.
    /// </summary>
    /// <seealso cref = "ILanguage" />.
    [Serializable]
    public class Language : ILanguage
    {
        /// <inheritdoc cref = "ILanguage" />.
        /// <summary>
        ///     Gets or sets the name of the <see cref="Language" />.
        /// </summary>
        /// <seealso cref = "ILanguage" />.
        public string Name { get; set; }

        /// <inheritdoc cref = "ILanguage" />.
        /// <summary>
        ///     Gets or sets the identifier of the <see cref="Language" /> according to
        ///     https://msdn.microsoft.com/de-de/library/ee825488(v=cs.20).aspx.
        /// </summary>
        /// <seealso cref = "ILanguage" />.
        public string Identifier { get; set; }

        /// <inheritdoc cref = "ILanguage" />.
        /// <summary>
        ///     Gets or sets the <see cref="List{T}" /> of <see cref="Word" />s in the loaded <see cref="Language" />.
        /// </summary>
        /// <seealso cref = "ILanguage" />.
        public List<Word> Words { get; set; }

        /// <inheritdoc cref = "ILanguage" />.
        /// <summary>
        ///     Gets a word by a key.
        /// </summary>
        /// <param name="key">The key that is defined for the <see cref="Word" />.</param>
        /// <returns>The <see cref="Word" /> defined by the key.</returns>
        /// <seealso cref = "ILanguage" />.
        public string GetWord(string key)
        {
            return this.Words.Find(x => x.Key.Equals(key)).Value;
        }

        /// <inheritdoc cref = "ILanguage" />.
        /// <summary>
        ///     Gets the current <see cref="CultureInfo" />.
        /// </summary>
        /// <returns>The currently loaded <see cref="CultureInfo" />.</returns>
        /// <seealso cref = "ILanguage" />.
        public CultureInfo GetCulture()
        {
            return new CultureInfo(this.Identifier);
        }
    }
}