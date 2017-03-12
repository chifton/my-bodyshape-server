// ===============================
// *******************************
// The body schema class.
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
    /// The body schema class.
    /// </summary>
    [Table("BodySchemas")]
    public class BodySchema
    {
        /// <summary>
        /// The body identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The weight
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// The weight
        /// </summary>
        public double? Weight { get; set; }

        /// <summary>
        /// The picture 1 name
        /// </summary>
        public string Picture_1 { get; set; }

        /// <summary>
        /// The picture 1 width
        /// </summary>
        public double? PictureWidth_1 { get; set; }

        /// <summary>
        /// The picture 1 height
        /// </summary>
        public double? PictureHeight_1 { get; set; }

        /// <summary>
        /// The picture 1 left
        /// </summary>
        public double? PictureLeft_1 { get; set; }

        /// <summary>
        /// The picture 1 top
        /// </summary>
        public double? PictureTop_1 { get; set; }

        /// <summary>
        /// The picture 2 name
        /// </summary>
        public string Picture_2 { get; set; }

        /// The picture 2 width
        /// </summary>
        public double? PictureWidth_2 { get; set; }

        /// <summary>
        /// The picture 2 height
        /// </summary>
        public double? PictureHeight_2 { get; set; }

        /// <summary>
        /// The picture 2 left
        /// </summary>
        public double? PictureLeft_2 { get; set; }

        /// <summary>
        /// The picture 2 top
        /// </summary>
        public double? PictureTop_2 { get; set; }

        /// <summary>
        /// The abdomen
        /// </summary>
        public virtual Abdomen Abdomen { get; set; }

        /// <summary>
        /// The left forearm
        /// </summary>
        public virtual ForearmL ForeArmLeft { get; set; }

        /// <summary>
        /// The right forearm
        /// </summary>
        public virtual ForearmR ForeArmRight { get; set; }

        /// <summary>
        /// The left arm
        /// </summary>
        public virtual ArmL ArmLeft { get; set; }

        /// <summary>
        /// The right arm
        /// </summary>
        public virtual ArmR ArmRight { get; set; }

        ///// <summary>
        ///// The left ankle
        ///// </summary>
        //public virtual AnkleL AnkleLeft { get; set; }

        ///// <summary>
        ///// The right ankle
        ///// </summary>
        //public virtual AnkleR AnkleRight { get; set; }

        /// <summary>
        /// The neck
        /// </summary>
        public virtual Neck Neck { get; set; }

        /// <summary>
        /// The left thigh
        /// </summary>
        public virtual ThighL ThighLeft { get; set; }

        /// <summary>
        /// The right thigh
        /// </summary>
        public virtual ThighR ThighRight { get; set; }

        /// <summary>
        /// The bottom
        /// </summary>
        public virtual Bottom Bottom { get; set; }

        /// <summary>
        /// The left leg
        /// </summary>
        public virtual LegL LegLeft { get; set; }

        /// <summary>
        /// The right leg
        /// </summary>
        public virtual LegR LegRight { get; set; }

        /// <summary>
        /// The left hand
        /// </summary>
        public virtual HandL HandLeft { get; set; }

        /// <summary>
        /// The right hand
        /// </summary>
        public virtual HandR HandRight { get; set; }

        /// <summary>
        /// The left foot
        /// </summary>
        public virtual FootL FootLeft { get; set; }

        /// <summary>
        /// The right foot
        /// </summary>
        public virtual FootR FootRight { get; set; }

        /// <summary>
        /// The head
        /// </summary>
        public virtual Head Head { get; set; }

        /// <summary>
        /// The thorax
        /// </summary>
        public virtual Thorax Thorax { get; set; }

        /// <summary>
        /// The generation
        /// </summary>
        public virtual Generation Generation { get; set; }
    }
}
