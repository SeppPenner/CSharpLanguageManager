using System;
using System.Collections.Generic;
using Languages.Implementation;

namespace Languages.Interfaces
{
    /// <summary>
    ///     The <see cref="LanguageManager" /> class to manage the <see cref="Language" />s
    /// </summary>
    public interface ILanguageManager
    {
        /// <summary>
        ///     Sets the current <see cref="Language" /> by the identifer
        /// </summary>
        /// <param name="identifier">The identifier of the <see cref="Language" /> that should be set</param>
        void SetCurrentLanguage(string identifier);

        /// <summary>
        ///     Sets the current <see cref="Language" /> by the name
        /// </summary>
        /// <param name="name">The name of the <see cref="Language" /> that should be set</param>
        void SetCurrentLanguageFromName(string name);

        /// <summary>
        ///     Gets the current <see cref="Language" />
        /// </summary>
        /// <returns>The current <see cref="Language" /></returns>
        Language GetCurrentLanguage();

        /// <summary>
        ///     Gets the <see cref="Word" /> by a key
        /// </summary>
        /// <param name="key">The key for the <see cref="Word" /> that is searched</param>
        /// <returns>The corresponding <see cref="Word" /></returns>
        string GetWord(string key);

        /// <summary>
        ///     Gets all the loaded <see cref="Language" />s
        /// </summary>
        /// <returns>All the loaded <see cref="Language" />s</returns>
        List<Language> GetLanguages();

        /// <summary>
        ///     The <see cref="EventHandler" /> that is called whenever the <see cref="Language" /> changes
        /// </summary>
        event EventHandler OnLanguageChanged;
    }
}