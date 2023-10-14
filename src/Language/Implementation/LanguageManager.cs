// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageManager.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The <see cref="LanguageManager" /> class to manage the <see cref="Language" />s.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Implementation;

/// <inheritdoc cref = "ILanguageManager" />.
/// <summary>
///     The <see cref="LanguageManager" /> class to manage the <see cref="Language" />s.
/// </summary>
/// <seealso cref = "ILanguageManager" />.
public class LanguageManager : ILanguageManager
{
    /// <summary>
    /// The import export class.
    /// </summary>
    private readonly IImportExport importExport = new ImportExport();

    /// <summary>
    /// The current language.
    /// </summary>
    private Language currentLanguage = new();

    /// <summary>
    /// The languages.
    /// </summary>
    private List<Language> languages = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="LanguageManager"/> class.
    /// </summary>
    public LanguageManager()
    {
        this.LoadDefaults();
    }

    /// <inheritdoc cref = "ILanguageManager" />.
    /// <summary>
    ///     The <see cref="EventHandler" /> that is called whenever the <see cref="Language" /> changes.
    /// </summary>
    /// <seealso cref = "ILanguageManager" />.
    public event EventHandler? OnLanguageChanged;

    /// <inheritdoc cref = "ILanguageManager" />.
    /// <summary>
    ///     Reloads all language files.
    /// </summary>
    /// <seealso cref = "ILanguageManager" />.
    public void ReloadLanguages()
    {
        this.LoadDefaults();
    }

    /// <inheritdoc cref = "ILanguageManager" />.
    /// <summary>
    ///     Gets all the loaded <see cref="ILanguage" />s.
    /// </summary>
    /// <returns>All the loaded <see cref="ILanguage" />s.</returns>
    /// <seealso cref = "ILanguageManager" />.
    public List<ILanguage> GetLanguages()
    {
        return ConvertToListILanguage(this.languages);
    }

    /// <inheritdoc cref = "ILanguageManager" />.
    /// <summary>
    ///     Gets the current <see cref="ILanguage" />.
    /// </summary>
    /// <returns>The current <see cref="ILanguage" />.</returns>
    /// <seealso cref = "ILanguageManager" />.
    public ILanguage GetCurrentLanguage()
    {
        return this.currentLanguage;
    }

    /// <inheritdoc cref = "ILanguageManager" />.
    /// <summary>
    ///     Gets the <see cref="Word" /> by a key.
    /// </summary>
    /// <param name="key">The key for the <see cref="Word" /> that is searched.</param>
    /// <returns>The corresponding <see cref="Word" />.</returns>
    /// <seealso cref = "ILanguageManager" />.
    public string? GetWord(string key)
    {
        return this.currentLanguage.GetWord(key);
    }

    /// <inheritdoc cref = "ILanguageManager" />.
    /// <summary>
    ///     Sets the current <see cref="Language" /> by the identifier.
    /// </summary>
    /// <param name="identifier">The identifier of the <see cref="Language" /> that should be set.</param>
    /// <seealso cref = "ILanguageManager" />.
    public void SetCurrentLanguage(string identifier)
    {
        this.currentLanguage = this.languages.First(x => x.Identifier.Equals(identifier));

        if (this.currentLanguage == null)
        {
            ThrowLanguageNotProperlyLoadedException(identifier);
        }

        this.LanguageHasChanged();
    }

    /// <inheritdoc cref = "ILanguageManager" />.
    /// <summary>
    ///     Sets the current <see cref="Language" /> by the name.
    /// </summary>
    /// <param name="name">The name of the <see cref="Language" /> that should be set.</param>
    /// <seealso cref = "ILanguageManager" />.
    public void SetCurrentLanguageFromName(string name)
    {
        this.currentLanguage = this.languages.First(x => x.Name.Equals(name));

        if (this.currentLanguage == null)
        {
            ThrowLanguageNotProperlyLoadedException(name);
        }

        this.LanguageHasChanged();
    }

    /// <summary>
    /// Called whenever the language is changed.
    /// </summary>
    /// <param name="e">The parameters.</param>
    protected virtual void LanguageChanged(EventArgs e)
    {
        var handler = this.OnLanguageChanged;
        handler?.Invoke(this, e);
    }

    /// <summary>
    /// Converts the languages to an interface list.
    /// </summary>
    /// <param name="languages">The languages.</param>
    /// <returns>The interface list.</returns>
    private static List<ILanguage> ConvertToListILanguage(IEnumerable<Language> languages)
    {
        return languages.Cast<ILanguage>().ToList();
    }

    /// <summary>
    /// Throws a <see cref="LanguageNotLoadedException"/>.
    /// </summary>
    /// <param name="language">The language.</param>
    private static void ThrowLanguageNotProperlyLoadedException(string language)
    {
        throw new LanguageNotLoadedException("The language " + language + " is not loaded properly", new Exception("The language " + language + " is not loaded properly"));
    }

    /// <summary>
    /// Handles the language changed event internally.
    /// </summary>
    private void LanguageHasChanged()
    {
        this.LanguageChanged(new LanguageChangedEventArgs("Language has changed to: " + this.currentLanguage.Name));
    }

    /// <summary>
    /// Loads the defaults.
    /// </summary>
    private void LoadDefaults()
    {
        this.languages = this.importExport.LoadDefaults();
        this.CheckSingleLanguage();

        if (this.importExport.GetExceptions().Count > 0)
        {
            var message = this.importExport.GetExceptions().ToString();
            throw new LanguageInitializationException(message ?? string.Empty);
        }
    }

    /// <summary>
    /// Checks whether there is only one language or more available.
    /// </summary>
    private void CheckSingleLanguage()
    {
        if (this.languages.Count != 1)
        {
            return;
        }

        this.currentLanguage = this.languages.First();
        this.LanguageHasChanged();
    }
}
