using Languages.Events;
using Languages.Exceptions;
using Languages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Languages.Implementation
{
    /// <summary>
    ///     <inheritdoc cref="ILanguageManager"/>.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public class LanguageManager : ILanguageManager
    {
        private readonly IImportExport _importExport = new ImportExport();

        private Language _currentLanguage;

        private List<Language> _languages;

        /// <summary>
        ///     <inheritdoc cref="ILanguageManager"/>.
        ///     Creates a new instance of the <see cref="LanguageManager"/> class.
        /// </summary>
        public LanguageManager()
        {
            LoadDefaults();
        }

        /// <summary>
        ///     <inheritdoc cref="ILanguageManager"/>.
        /// </summary>
        public void ReloadLanguages()
        {
            LoadDefaults();
        }

        /// <summary>
        ///     <inheritdoc cref="ILanguageManager"/>.
        /// </summary>
        public event EventHandler OnLanguageChanged;

        /// <summary>
        ///     <inheritdoc cref="ILanguageManager"/>.
        /// </summary>
        public List<ILanguage> GetLanguages()
        {
            return ConvertToListILanguage(_languages);
        }

        /// <summary>
        ///     <inheritdoc cref="ILanguageManager"/>.
        /// </summary>
        public ILanguage GetCurrentLanguage()
        {
            return _currentLanguage;
        }

        /// <summary>
        ///     <inheritdoc cref="ILanguageManager"/>.
        /// </summary>
        public string GetWord(string key)
        {
            return _currentLanguage.GetWord(key);
        }

        /// <summary>
        ///     <inheritdoc cref="ILanguageManager"/>.
        /// </summary>
        public void SetCurrentLanguage(string identifier)
        {
            _currentLanguage = _languages.First(x => x.Identifier.Equals(identifier));
            if (_currentLanguage == null)
                ThrowLanguageNotProperlyLoadedException(identifier);
            LanguageHasChanged();
        }

        /// <summary>
        ///     <inheritdoc cref="ILanguageManager"/>.
        /// </summary>
        public void SetCurrentLanguageFromName(string name)
        {
            _currentLanguage = _languages.First(x => x.Name.Equals(name));
            if (_currentLanguage == null)
                ThrowLanguageNotProperlyLoadedException(name);
            LanguageHasChanged();
        }

        private static List<ILanguage> ConvertToListILanguage(IEnumerable<Language> languages)
        {
            return languages.Cast<ILanguage>().ToList();
        }

        private static void ThrowLanguageNotProperlyLoadedException(string language)
        {
            throw new LanguageNotLoadedException("The language " + language + " is not loaded properly",
                new Exception("The language " + language + " is not loaded properly"));
        }

        /// <summary>
        /// Called whenever the language is changed.
        /// </summary>
        /// <param name="e">The parameters.</param>
        protected virtual void LanguageChanged(EventArgs e)
        {
            var handler = OnLanguageChanged;
            handler?.Invoke(this, e);
        }

        private void LanguageHasChanged()
        {
            LanguageChanged(new LanguageChangedEventArgs("Language has changed to: " + _currentLanguage.Name));
        }

        private void LoadDefaults()
        {
            _languages = _importExport.LoadDefaults();
            CheckSingleLanguage();
            if (_importExport.GetExceptions().Count > 0)
                throw new LanguageInitializationException(_importExport.GetExceptions().ToString());
        }

        private void CheckSingleLanguage()
        {
            if (_languages.Count != 1) return;
            _currentLanguage = _languages.First();
            LanguageHasChanged();
        }
    }
}