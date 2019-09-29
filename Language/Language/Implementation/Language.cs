using Languages.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Languages.Implementation
{
    /// <summary>
    ///     <inheritdoc cref="ILanguage"/>.
    /// </summary>
    [Serializable]
    public class Language : ILanguage
    {
        /// <summary>
        ///     <inheritdoc cref="ILanguage"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     <inheritdoc cref="ILanguage"/>.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        ///     <inheritdoc cref="ILanguage"/>.
        /// </summary>
        public List<Word> Words { get; set; }

        /// <summary>
        ///     <inheritdoc cref="ILanguage"/>.
        /// </summary>
        public string GetWord(string key)
        {
            return Words.Find(x => x.Key.Equals(key)).Value;
        }

        /// <summary>
        ///     <inheritdoc cref="ILanguage"/>.
        /// </summary>
        public CultureInfo GetCulture()
        {
            return new CultureInfo(Identifier);
        }
    }
}