using System;
using Languages.Interfaces;

namespace Languages.Implementation
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
	[Serializable]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Word : IWord
    {
        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string Value { get; set; }
    }
}