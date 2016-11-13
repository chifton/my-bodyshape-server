// ===============================
// *******************************
// The bodyshape configuration interface.
// ===============================
// *******************************

namespace MyShapeBody.Configuration
{
    /// <summary>
    /// The bodyshape configuration interface.
    /// </summary>
    public interface IBodyShapeConfiguration
    {
        /// <summary>
        /// The common density.
        /// </summary>
        decimal Density { get; set; }

        /// <summary>
        /// The maximum error percentage.
        /// </summary>
        int MaxError { get; set; }

        /// <summary>
        /// The folder log.
        /// </summary>
        string FolderLog { get; set; }
    }
}
