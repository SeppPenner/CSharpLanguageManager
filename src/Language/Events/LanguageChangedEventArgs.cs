// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageChangedEventArgs.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The <see cref="LanguageChangedEventArgs" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Events;

/// <summary>
///     The <see cref="LanguageChangedEventArgs" /> class.
/// </summary>
public class LanguageChangedEventArgs : EventArgs
{
    /// <summary>
    /// The event information.
    /// </summary>
    private readonly string eventInformation;

    /// <summary>
    ///     Initializes a new instance of the <see cref="LanguageChangedEventArgs"/> class.
    /// </summary>
    /// <param name="text">The text to be set to the params.</param>
    public LanguageChangedEventArgs(string text)
    {
        this.eventInformation = text;
    }

    /// <summary>
    ///     Gets the <see cref="LanguageChangedEventArgs" /> info.
    /// </summary>
    /// <returns>The event info of the <see cref="LanguageChangedEventArgs" />.</returns>
    public string GetInfo()
    {
        return this.eventInformation;
    }
}
