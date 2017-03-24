using System;
using System.Collections.Generic;
using Languages.Implementation;

namespace Languages.Interfaces
{
    public interface ILanguageManager
    {
        void SetCurrentLanguage(string identifier);

        void SetCurrentLanguageFromName(string name);
        Language GetCurrentLanguage();

        string GetWord(string key);

        List<Language> GetLanguages();

        event EventHandler OnLanguageChanged;
    }
}