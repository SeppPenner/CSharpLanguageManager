using System;
using System.Collections.Generic;
using System.Globalization;
using Languages.Interfaces;

namespace Languages.Implementation
{
    [Serializable]
    public class Language : ILanguage
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        //According to https://msdn.microsoft.com/de-de/library/ee825488(v=cs.20).aspx

        public List<Word> Words { get; set; }

        public string GetWord(string key)
        {
            return Words.Find(x => x.Key.Equals(key)).Value;
        }

        public string GetIdentifier()
        {
            return Identifier;
        }

        public CultureInfo GetCulture()
        {
            return new CultureInfo(Identifier);
        }
    }
}