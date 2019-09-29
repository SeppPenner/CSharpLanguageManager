using Languages.Exceptions;
using Languages.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Languages.Implementation
{
    /// <summary>
    ///     <inheritdoc cref="IImportExport" />.
    /// </summary>
    public class ImportExport : IImportExport
    {
        /// <summary>
        ///     <inheritdoc cref="IImportExport" />.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public List<Exception> Exceptions { get; private set; }

        /// <summary>
        ///     <inheritdoc cref="IImportExport" />.
        /// </summary>
        public Language Load(string filename)
        {
            var xDocument = XDocument.Load(filename);
            return CreateObjectsFromString<Language>(xDocument);
        }

        /// <summary>
        ///     <inheritdoc cref="IImportExport" />.
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
        ///     <inheritdoc cref="IImportExport" />.
        /// </summary>
        public List<Exception> GetExceptions()
        {
            return Exceptions;
        }

        /// <summary>
        ///     <inheritdoc cref="IImportExport" />.
        /// </summary>
        public List<Language> Load(IEnumerable<string> fileNames)
        {
            ClearExceptions();
            var languages = new List<Language>();
            foreach (var file in fileNames)
                TryLoadLanguage(languages, file);
            return languages;
        }

        private void CheckLocationIsNull(string location)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));
        }

        private void TryLoadLanguage(ICollection<Language> languages, string file)
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

        private static T CreateObjectsFromString<T>(XDocument xDocument)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(new StringReader(xDocument.ToString()));
        }
    }
}