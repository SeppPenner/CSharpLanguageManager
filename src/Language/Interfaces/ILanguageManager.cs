// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILanguageManager.cs" company="Hämmer Electronics">
//   Copyright (c) 2020 All rights reserved.
// </copyright>
// <summary>
//   The <see cref="ILanguageManager" /> interface to manage the <see cref="Language" />s.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Languages.Implementation;

    /// <summary>
    ///     The <see cref="ILanguageManager" /> interface to manage the <see cref="Language" />s.
    /// </summary>
    public interface ILanguageManager
    {
        /// <summary>
        ///     The <see cref="EventHandler" /> that is called whenever the <see cref="Language" /> changes.
        /// </summary>
        event EventHandler OnLanguageChanged;

        /// <summary>
        ///     Sets the current <see cref="Language" /> by the identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the <see cref="Language" /> that should be set.</param>
        void SetCurrentLanguage(string identifier);

        /// <summary>
        ///     Sets the current <see cref="Language" /> by the name.
        /// </summary>
        /// <param name="name">The name of the <see cref="Language" /> that should be set.</param>
        void SetCurrentLanguageFromName(string name);

        /// <summary>
        ///     Gets the current <see cref="ILanguage" />.
        /// </summary>
        /// <returns>The current <see cref="ILanguage" />.</returns>
        ILanguage GetCurrentLanguage();

        /// <summary>
        ///     Gets the <see cref="Word" /> by a key.
        /// </summary>
        /// <param name="key">The key for the <see cref="Word" /> that is searched.</param>
        /// <returns>The corresponding <see cref="Word" />.</returns>
        string? GetWord(string key);

        /// <summary>
        ///     Gets all the loaded <see cref="ILanguage" />s.
        /// </summary>
        /// <returns>All the loaded <see cref="ILanguage" />s.</returns>
        List<ILanguage> GetLanguages();

        /// <summary>
        ///     Reloads all language files.
        /// </summary>
        void ReloadLanguages();
    }
}