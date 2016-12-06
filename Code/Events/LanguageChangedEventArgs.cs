using System;

namespace Languages.Events
{
    public class LanguageChangedEventArgs : EventArgs
    {
        private readonly string _eventInfo;

        public LanguageChangedEventArgs(string text)
        {
            _eventInfo = text;
        }

        public string GetInfo()
        {
            return _eventInfo;
        }
    }
}