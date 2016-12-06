using System;
using System.Collections.Generic;
using Languages.Implementation;

namespace Languages.Interfaces
{
    public interface IImportExport
    {
        Language Load(string filename);
        List<Language> Load(List<string> filenames);
        List<Language> LoadDefaults();
        List<Exception> GetExceptions();
    }
}