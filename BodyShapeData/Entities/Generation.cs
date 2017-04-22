// ===============================
// *******************************
// The generation class.
// ===============================
// *******************************

namespace BodyShapeData.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The generation class.
    /// </summary>
    [Table("Generations")]
    public class Generation
    {
        /// <summary>
        /// The generation identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The user identifier.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The anonymous identifier (for both authenticated and non authenticated users)
        /// </summary>
        public Guid AnonymousId { get; set; }

        /// <summary>
        /// The has account boolean.
        /// </summary>
        public bool HasAccount { get; set; }

        /// <summary>
        /// The generation date.
        /// </summary>
        public DateTime GenerationDate { get; set; }

        /// <summary>
        /// The success result.
        /// </summary>
        public bool? Success { get; set; }

        /// <summary>
        /// The error percentage.
        /// </summary>
        public double? ErrorPercent { get; set; }

        /// <summary>
        /// The front picture name.
        /// </summary>
        public string FrontPicture { get; set; }

        /// <summary>
        /// The side picture name.
        /// </summary>
        public string SidePicture { get; set; }

        /// <summary>
        /// The user height.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// The user expected weight.
        /// </summary>
        public double? ExpectedWeight { get; set; }

        /// <summary>
        /// The user generated weight.
        /// </summary>
        public double GeneratedWeight { get; set; }
        
        /// <summary>
        /// The body schema.
        /// </summary>
        public virtual BodySchema BodySchema { get; set; }

        /// <summary>
        /// The body result.
        /// </summary>
        public virtual BodyResult BodyResult { get; set; }
    }
}
