using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Languages.Exceptions;
using Languages.Interfaces;

namespace Languages.Implementation
{
    public class ImportExport : IImportExport
    {
        public List<Exception> Exceptions { get; private set; }

        public Language Load(string filename)
        {
            var xDocument = XDocument.Load(filename);
            return CreateObjectsFromString<Language>(xDocument);
        }

        public List<Language> LoadDefaults()
        {
            ClearExceptions();
            var languages = new List<Language>();
            foreach (var file in Directory.EnumerateFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "languages")))
                TryLoadLanguage(languages, file);
            return languages;
        }

        public List<Exception> GetExceptions()
        {
            return Exceptions;
        }

        public List<Language> Load(IEnumerable<string> filenames)
        {
            ClearExceptions();
            var languages = new List<Language>();
            foreach (var file in filenames)
                TryLoadLanguage(languages, file);
            return languages;
        }

        private void TryLoadLanguage(List<Language> languages, string file)
        {
            try
            {
                var extension = Path.GetExtension(file);
                if (extension != null && extension.Equals(".xml"))
                {
                    languages.Add(Load(file));
                    return;
                }
                SaveException(new WrongFileExtensionException("File " + file + " is no XML file",
                    new Exception("File " + file + " is no XML file")));
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }

        private void SaveException(Exception ex)
        {
            if (Exceptions == null)
                Exceptions = new List<Exception>();
            Exceptions.Add(ex);
        }

        private void ClearExceptions()
        {
            Exceptions = new List<Exception>();
        }

        private T CreateObjectsFromString<T>(XDocument xDocument)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            return (T) xmlSerializer.Deserialize(new StringReader(xDocument.ToString()));
        }
    }
}