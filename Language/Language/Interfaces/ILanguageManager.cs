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
        // ReSharper disable once UnusedMember.Global
        void SetCurrentLanguage(string identifier);

        /// <summary>
        ///     Sets the current <see cref="Language" /> by the name
        /// </summary>
        /// <param name="name">The name of the <see cref="Language" /> that should be set</param>
        // ReSharper disable once UnusedMember.Global
        void SetCurrentLanguageFromName(string name);

        /// <summary>
        ///     Gets the current <see cref="ILanguage" />
        /// </summary>
        /// <returns>The current <see cref="ILanguage" /></returns>
        // ReSharper disable once UnusedMember.Global
        ILanguage GetCurrentLanguage();

        /// <summary>
        ///     Gets the <see cref="Word" /> by a key
        /// </summary>
        /// <param name="key">The key for the <see cref="Word" /> that is searched</param>
        /// <returns>The corresponding <see cref="Word" /></returns>
        // ReSharper disable once UnusedMember.Global
        string GetWord(string key);

        /// <summary>
        ///     Gets all the loaded <see cref="ILanguage" />s
        /// </summary>
        /// <returns>All the loaded <see cref="ILanguage" />s</returns>
        // ReSharper disable once UnusedMember.Global
        List<ILanguage> GetLanguages();

        /// <summary>
        ///     The <see cref="EventHandler" /> that is called whenever the <see cref="Language" /> changes
        /// </summary>
        // ReSharper disable once EventNeverSubscribedTo.Global
        event EventHandler OnLanguageChanged;

        /// <summary>
        ///     Reloads all language files.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        void ReloadLanguages();
    }
}