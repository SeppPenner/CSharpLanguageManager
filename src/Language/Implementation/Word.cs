// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Word.cs" company="Hämmer Electronics">
//   Copyright (c) 2020 All rights reserved.
// </copyright>
// <summary>
//   The <see cref="Word" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Implementation;

/// <summary>
///     The <see cref="Word" /> class.
/// </summary>
[Serializable]
public class Word : IWord
{
    /// <summary>
    ///     Gets or sets the key of the <see cref="Word" />.
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets value of the <see cref="Word" />.
    /// </summary>
    public string Value { get; set; } = string.Empty;
}
