using System;
using System.Collections.Generic;
using System.Globalization;
using Languages.Interfaces;

namespace Languages.Implementation
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    [Serializable]
    public class Language : ILanguage
    {
        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public List<Word> Words { get; set; }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string GetWord(string key)
        {
            return Words.Find(x => x.Key.Equals(key)).Value;
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public CultureInfo GetCulture()
        {
            return new CultureInfo(Identifier);
        }
    }
}