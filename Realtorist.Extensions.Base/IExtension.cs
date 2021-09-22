namespace Realtorist.Extensions.Base
{
    /// <summary>
    /// Describes base interface for extensions
    /// </summary>
    public interface IExtension
    {
        /// <summary>
        /// Gets priority in which to execute the extensions (lower - earlier)
        /// </summary>
        int Priority { get; }
    }
}