using Languages.Implementation;

namespace Languages.Interfaces
{
    /// <summary>
    ///     The <see cref="Word" /> class
    /// </summary>
    public interface IWord
    {
        /// <summary>
        ///     The key of the <see cref="Word" />
        /// </summary>
        string Key { get; set; }

        /// <summary>
        ///     The value of the <see cref="Word" />
        /// </summary>
        string Value { get; set; }
    }
}