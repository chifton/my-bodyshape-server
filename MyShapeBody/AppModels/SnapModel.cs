// ===============================
// *******************************
// The snap model class.
// ===============================
// *******************************

namespace MyShapeBody.AppModels
{
    using System.Drawing;

    /// <summary>
    /// The snap model
    /// </summary>
    public class SnapModel
    {
        /// <summary>
        /// The member name (for reflection in bodyticket and bodymass).
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// The label text.
        /// </summary>
        public string LabelText { get; set; }

        /// <summary>
        /// The position.
        /// </summary>
        public Point? Position { get; set; }

        /// <summary>
        /// The constructor.
        /// </summary>
        public SnapModel(string memberName, string labelText, Point? position)
        {
            this.MemberName = memberName;
            this.LabelText = labelText;
            this.Position = position;
        }
    }
}