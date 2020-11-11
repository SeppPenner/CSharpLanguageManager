// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IImportExport.cs" company="Hämmer Electronics">
//   Copyright (c) 2020 All rights reserved.
// </copyright>
// <summary>
//   An interface to load <see cref="Language" />s from file names.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Languages.Implementation;

    /// <summary>
    ///     An interface to load <see cref="Language" />s from file names.
    /// </summary>
    public interface IImportExport
    {
        /// <summary>
        ///     Loads the <see cref="Language" /> defined by the file name.
        /// </summary>
        /// <param name="filename">The <see cref="Language" /> file name that should be loaded.</param>
        /// <returns>The corresponding <see cref="Language" /> class.</returns>
        // ReSharper disable once UnusedMemberInSuper.Global
        Language Load(string filename);

        /// <summary>
        ///     Loads the <see cref="Language" />s defined by the file names.
        /// </summary>
        /// <param name="fileNames">The <see cref="Language" /> file names that should be loaded.</param>
        /// <returns>The corresponding <see cref="Language" />s <see cref="List{T}" />.</returns>
        // ReSharper disable once UnusedMember.Global
        List<Language> Load(IEnumerable<string> fileNames);

        /// <summary>
        ///     Loads the default <see cref="Language" />s.
        /// </summary>
        /// <returns>A list of <see cref="Language" />s.</returns>
        List<Language> LoadDefaults();

        /// <summary>
        ///     Shows the <see cref="Exception" />s that occured while loading the <see cref="Language" />s.
        /// </summary>
        /// <returns>The <see cref="List{T}" /> of <see cref="Exception" />s.</returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        List<Exception> GetExceptions();
    }
}