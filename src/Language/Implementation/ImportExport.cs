// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImportExport.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   A class to load <see cref="Language" />s from file names.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Implementation;

/// <inheritdoc cref = "IImportExport" />.
/// <summary>
///    A class to load <see cref="Language" />s from file names.
/// </summary>
/// <seealso cref = "IImportExport" />.
public class ImportExport : IImportExport
{
    /// <summary>
    ///     Gets the exceptions.
    /// </summary>
    public List<Exception> Exceptions { get; private set; } = new();

    /// <inheritdoc cref = "IImportExport" />.
    /// <summary>
    ///     Loads the <see cref="Language" /> defined by the file name.
    /// </summary>
    /// <param name="filename">The <see cref="Language" /> file name that should be loaded.</param>
    /// <returns>The corresponding <see cref="Language" /> class.</returns>
    /// <seealso cref = "IImportExport" />.
    public Language? Load(string filename)
    {
        var xDocument = XDocument.Load(filename);
        return CreateObjectsFromString<Language>(xDocument);
    }

    /// <inheritdoc cref = "IImportExport" />.
    /// <summary>
    ///     Loads the default <see cref="Language" />s.
    /// </summary>
    /// <returns>A list of <see cref="Language" />s.</returns>
    /// <seealso cref = "IImportExport" />.
    public List<Language> LoadDefaults()
    {
        this.ClearExceptions();
        var languages = new List<Language>();
        var location = Assembly.GetExecutingAssembly().Location;
        CheckLocationIsNull(location);
        var directoryFolder = Directory.GetParent(location)?.FullName ?? string.Empty;
        var languageFolder = Path.Combine(directoryFolder, "languages");

        foreach (var file in Directory.EnumerateFiles(languageFolder))
        {
            this.TryLoadLanguage(languages, file);
        }

        return languages;
    }

    /// <inheritdoc cref = "IImportExport" />.
    /// <summary>
    ///     Shows the <see cref="Exception" />s that occured while loading the <see cref="Language" />s.
    /// </summary>
    /// <returns>The <see cref="List{T}" /> of <see cref="Exception" />s.</returns>
    /// <seealso cref = "IImportExport" />.
    public List<Exception> GetExceptions()
    {
        return this.Exceptions;
    }

    /// <inheritdoc cref = "IImportExport" />.
    /// <summary>
    ///     Loads the <see cref="Language" />s defined by the file names.
    /// </summary>
    /// <param name="fileNames">The <see cref="Language" /> file names that should be loaded.</param>
    /// <returns>The corresponding <see cref="Language" />s <see cref="List{T}" />.</returns>
    /// <seealso cref = "IImportExport" />.
    public List<Language> Load(IEnumerable<string> fileNames)
    {
        this.ClearExceptions();
        var languages = new List<Language>();

        foreach (var file in fileNames)
        {
            this.TryLoadLanguage(languages, file);
        }

        return languages;
    }

    /// <summary>
    /// Checks whether the given location is <c>null</c>.
    /// </summary>
    /// <param name="location">The location.</param>
    private static void CheckLocationIsNull(string location)
    {
        if (location is null)
        {
            throw new ArgumentNullException(nameof(location));
        }
    }

    /// <summary>
    /// Deserializes the objects from the found <see cref="string"/>.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="xDocument">The X document.</param>
    /// <returns>The objects of type T.</returns>
    private static T? CreateObjectsFromString<T>(XDocument xDocument)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));
        return (T?)xmlSerializer.Deserialize(new StringReader(xDocument.ToString()));
    }

    /// <summary>
    /// Tries to load the language from the file.
    /// </summary>
    /// <param name="languages">The languages.</param>
    /// <param name="file">The file.</param>
    private void TryLoadLanguage(ICollection<Language> languages, string file)
    {
        try
        {
            var extension = Path.GetExtension(file);

            if (extension is not null && extension.Equals(".xml"))
            {
                var loadedLanguage = this.Load(file);

                if (loadedLanguage is null)
                {
                    return;
                }

                languages.Add(loadedLanguage);
                return;
            }

            this.SaveException(new WrongFileExtensionException("File " + file + " is no XML file", new Exception("File " + file + " is no XML file")));
        }
        catch (Exception ex)
        {
            this.SaveException(ex);
        }
    }

    /// <summary>
    /// Saves the <see cref="Exception"/>.
    /// </summary>
    /// <param name="ex">The exception.</param>
    private void SaveException(Exception ex)
    {
        if (this.Exceptions == null)
        {
            this.Exceptions = new List<Exception>();
        }

        this.Exceptions.Add(ex);
    }

    /// <summary>
    /// Clears the <see cref="Exception"/>s.
    /// </summary>
    private void ClearExceptions()
    {
        this.Exceptions = new List<Exception>();
    }
}
