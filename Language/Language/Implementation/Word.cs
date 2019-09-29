using Languages.Interfaces;
using System;

namespace Languages.Implementation
{
    /// <summary>
    ///     <inheritdoc cref="IWord"/>.
    /// </summary>
    [Serializable]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Word : IWord
    {
        /// <summary>
        ///     <inheritdoc cref="IWord"/>.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     <inheritdoc cref="IWord"/>.
        /// </summary>
        public string Value { get; set; }
    }
}