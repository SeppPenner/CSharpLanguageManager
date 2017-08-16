using System;
using System.Collections.Generic;
using System.Linq;
using Languages.Events;
using Languages.Exceptions;
using Languages.Interfaces;

namespace Languages.Implementation
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public class LanguageManager : ILanguageManager
    {
        private readonly IImportExport _importExport = new ImportExport();

        private Language _currentLanguage;

        private List<Language> _languages;

        public LanguageManager()
        {
            LoadDefaults();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void ReloadLanguages()
        {
            LoadDefaults();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public event EventHandler OnLanguageChanged;

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public List<ILanguage> GetLanguages()
        {
            return ConvertToListIlanguage(_languages);
        }

        private static List<ILanguage> ConvertToListIlanguage(IEnumerable<Language> languages)
        {
            return languages.Cast<ILanguage>().ToList();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public ILanguage GetCurrentLanguage()
        {
            return _currentLanguage;
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string GetWord(string key)
        {
            return _currentLanguage.GetWord(key);
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetCurrentLanguage(string identifier)
        {
            _currentLanguage = _languages.First(x => x.Identifier.Equals(identifier));
            if (_currentLanguage == null)
                ThrowLanguageNotProperlyLoadedException(identifier);
            LanguageHasChanged();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetCurrentLanguageFromName(string name)
        {
            _currentLanguage = _languages.First(x => x.Name.Equals(name));
            if (_currentLanguage == null)
                ThrowLanguageNotProperlyLoadedException(name);
            LanguageHasChanged();
        }

        private static void ThrowLanguageNotProperlyLoadedException(string language)
        {
            throw new LanguageNotLoadedException("The language " + language + " is not loaded properly",
                new Exception("The language " + language + " is not loaded properly"));
        }

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