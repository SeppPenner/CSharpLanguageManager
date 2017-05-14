using System.Collections.Generic;
using System.Globalization;
using Languages.Implementation;

namespace Languages.Interfaces
{
    /// <summary>
    ///     The <see cref="Language" /> class to store different <see cref="Language" />s
    /// </summary>
    public interface ILanguage
    {
        /// <summary>
        ///     The identifier of the <see cref="Language" /> according to
        ///     https://msdn.microsoft.com/de-de/library/ee825488(v=cs.20).aspx
        /// </summary>
        string Identifier { get; set; }

        /// <summary>
        ///     A <see cref="List{T}" /> of <see cref="Word" />s in the loaded <see cref="Language" />
        /// </summary>
        List<Word> Words { get; set; }

        /// <summary>
        ///     Gets a word by a key
        /// </summary>
        /// <param name="key">The key that is defined for the <see cref="Word" /></param>
        /// <returns></returns>
        string GetWord(string key);

        /// <summary>
        ///     Gets the current <see cref="CultureInfo" />
        /// </summary>
        /// <returns>The currently loaded <see cref="CultureInfo" /></returns>
        CultureInfo GetCulture();
    }
}