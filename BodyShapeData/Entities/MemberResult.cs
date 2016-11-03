// ===============================
// *******************************
// The member result class.
// ===============================
// *******************************

namespace BodyShapeData.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The member result entity.
    /// </summary>
    public class MemberResult
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
        /// The weight of the member
        /// </summary>
        public double Mass { get; set; }

        /// <summary>
        /// The mass center of the member
        /// </summary>
        public double MassCenter { get; set; }
    }
}
