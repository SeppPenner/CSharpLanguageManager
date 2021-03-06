﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Word.cs" company="Hämmer Electronics">
//   Copyright (c) 2020 All rights reserved.
// </copyright>
// <summary>
//   The <see cref="Word" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Languages.Implementation
{
    using System;

    using Languages.Interfaces;

    /// <summary>
    ///     The <see cref="Word" /> class.
    /// </summary>
    [Serializable]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Word : IWord
    {
        /// <summary>
        ///     Gets or sets the key of the <see cref="Word" />.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets value of the <see cref="Word" />.
        /// </summary>
        public string Value { get; set; }
    }
}