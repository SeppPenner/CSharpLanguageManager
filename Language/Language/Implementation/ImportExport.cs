using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using Languages.Exceptions;
using Languages.Interfaces;

namespace Languages.Implementation
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    public class ImportExport : IImportExport
    {
        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public List<Exception> Exceptions { get; private set; }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public Language Load(string filename)
        {
            var xDocument = XDocument.Load(filename);
            return CreateObjectsFromString<Language>(xDocument);
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public List<Language> LoadDefaults()
        {
            ClearExceptions();
            var languages = new List<Language>();
            var location = Assembly.GetExecutingAssembly().Location;
            CheckLocationIsNull(location);
            // ReSharper disable once AssignNullToNotNullAttribute
            var languageFolder = Path.Combine(Directory.GetParent(location).FullName, "languages");
            foreach (var file in Directory.EnumerateFiles(languageFolder))
                TryLoadLanguage(languages, file);
            return languages;
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public List<Exception> GetExceptions()
        {
            return Exceptions;
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public List<Language> Load(IEnumerable<string> filenames)
        {
            ClearExceptions();
            var languages = new List<Language>();
            foreach (var file in filenames)
                TryLoadLanguage(languages, file);
            return languages;
        }

        private void CheckLocationIsNull(string location)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));
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