// ===============================
// *******************************
// The member class.
// ===============================
// *******************************

namespace BodyShapeData.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The member entity.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// The identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The laterality.
        /// </summary>
        public Laterality Laterality { get; set; }

        /// <summary>
        /// The front down measure of the member
        /// </summary>
        public double Front_Down { get; set; }

        /// <summary>
        /// The front middle measure of the member
        /// </summary>
        public double Front_Middle { get; set; }

        /// <summary>
        /// The front top measure of the member
        /// </summary>
        public double Front_Top { get; set; }

        /// <summary>
        /// The side down measure of the member
        /// </summary>
        public double Side_Down { get; set; }

        /// <summary>
        /// The side middle measure of the member
        /// </summary>
        public double Side_Middle { get; set; }

        /// <summary>
        /// The side top measure of the member
        /// </summary>
        public double Side_Top { get; set; }

        /// <summary>
        /// The height down measure of the member
        /// </summary>
        public double Height_Down { get; set; }

        /// <summary>
        /// The height middle measure of the member
        /// </summary>
        public double Height_Middle { get; set; }

        /// <summary>
        /// The height top measure of the member
        /// </summary>
        public double Height_Top { get; set; }
    }
}
