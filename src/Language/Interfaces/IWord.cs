// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWord.cs" company="Haemmer Electronics">
//   Copyright (c) 2020 All rights reserved.
// </copyright>
// <summary>
//   The <see cref="Word" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Interfaces
{
    using Languages.Implementation;

    /// <inheritdoc cref = "IWord" />.
    /// <summary>
    ///     The <see cref="Word" /> interface.
    /// </summary>
    /// <seealso cref = "IWord" />.
    public interface IWord
    {
        /// <inheritdoc cref = "IWord" />.
        /// <summary>
        ///     Gets or sets the key of the <see cref="Word" />.
        /// </summary>
        /// <seealso cref = "IWord" />.
        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        string Key { get; set; }

        /// <inheritdoc cref = "IWord" />.
        /// <summary>
        ///     Gets or sets value of the <see cref="Word" />.
        /// </summary>
        /// <seealso cref = "IWord" />.
        // ReSharper disable UnusedMemberInSuper.Global
        // ReSharper disable once UnusedMember.Global
        string Value { get; set; }
    }
}