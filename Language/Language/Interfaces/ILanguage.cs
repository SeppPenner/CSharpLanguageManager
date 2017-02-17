using System.Collections.Generic;
using System.Globalization;
using Languages.Implementation;

namespace Languages.Interfaces
{
    public interface ILanguage
    {
        string Identifier { get; set; }

        List<Word> Words { get; set; }

        string GetWord(string key);

        string GetIdentifier();

        CultureInfo GetCulture();
    }
}