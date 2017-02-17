using System;
using System.Collections.Generic;
using Languages.Implementation;

namespace Languages.Interfaces
{
    public interface IImportExport
    {
        Language Load(string filename);
        List<Language> Load(IEnumerable<string> filenames);
        List<Language> LoadDefaults();
        List<Exception> GetExceptions();
    }
}