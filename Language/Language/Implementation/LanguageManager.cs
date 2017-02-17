using System;
using System.Collections.Generic;
using System.Linq;
using Languages.Events;
using Languages.Exceptions;
using Languages.Interfaces;

namespace Languages.Implementation
{
    public class LanguageManager : ILanguageManager
    {
        private readonly IImportExport _importExport = new ImportExport();

        private Language _currentLanguage;

        private List<Language> _languages;

        public LanguageManager()
        {
            LoadDefaults();
        }

        public event EventHandler OnLanguageChanged;

        public List<Language> GetLanguages()
        {
            return _languages;
        }

        public Language GetCurrentLanguage()
        {
            return _currentLanguage;
        }

        public string GetWord(string key)
        {
            return _currentLanguage.GetWord(key);
        }

        public void SetCurrentLanguage(string identifier)
        {
            _currentLanguage = _languages.First(x => x.GetIdentifier().Equals(identifier));
            if (_currentLanguage == null)
                throw new LanguageNotLoadedException("The language " + identifier + " is not loaded properly",
                    new Exception("The language " + identifier + " is not loaded properly"));
            LanguageHasChanged();
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