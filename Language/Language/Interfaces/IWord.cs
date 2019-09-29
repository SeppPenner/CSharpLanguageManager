using Languages.Implementation;

namespace Languages.Interfaces
{
    /// <summary>
    ///     The <see cref="Word" /> class.
    /// </summary>
    public interface IWord
    {
        /// <summary>
        ///     The key of the <see cref="Word" />.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        string Key { get; set; }

        /// <summary>
        ///     The value of the <see cref="Word" />.
        /// </summary>
        // ReSharper disable UnusedMemberInSuper.Global
        // ReSharper disable once UnusedMember.Global
        string Value { get; set; }
    }
}