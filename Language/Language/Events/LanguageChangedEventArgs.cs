using System;

namespace Languages.Events
{
    /// <summary>
    ///     The <see cref="LanguageChangedEventArgs" /> class.
    /// </summary>
    public class LanguageChangedEventArgs : EventArgs
    {
        private readonly string _eventInfo;

        /// <summary>
        ///     Constructor with text.
        /// </summary>
        /// <param name="text">The text to be set to the params.</param>
        public LanguageChangedEventArgs(string text)
        {
            _eventInfo = text;
        }

        /// <summary>
        ///     Gets the <see cref="LanguageChangedEventArgs" /> info.
        /// </summary>
        /// <returns>The event info of the <see cref="LanguageChangedEventArgs" />.</returns>
        // ReSharper disable once UnusedMember.Global
        public string GetInfo()
        {
            return _eventInfo;
        }
    }
}