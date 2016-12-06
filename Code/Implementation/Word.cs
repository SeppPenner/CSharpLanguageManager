using Languages.Interfaces;

namespace Languages.Implementation
{
    public class Word : IWord
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}