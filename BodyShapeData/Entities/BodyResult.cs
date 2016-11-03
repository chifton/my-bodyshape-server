// ===============================
// *******************************
// The body result class.
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
    /// The body resut class.
    /// </summary>
    [Table("BodyResults")]
    public class BodyResult
    {
        /// <summary>
        /// The body mass identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The abdomen mass
        /// </summary>
        public virtual AbdomenMass Abdomen { get; set; }

        /// <summary>
        /// The left forearm mass
        /// </summary>
        public virtual ForearmMassL ForeArmLeft { get; set; }

        /// <summary>
        /// The right forearm mass
        /// </summary>
        public virtual ForearmMassR ForeArmRight { get; set; }

        /// <summary>
        /// The left arm mass
        /// </summary>
        public virtual ArmMassL ArmLeft { get; set; }

        /// <summary>
        /// The right arm mass
        /// </summary>
        public virtual ArmMassR ArmRight { get; set; }

        /// <summary>
        /// The left ankle mass
        /// </summary>
        public virtual AnkleMassL AnkleLeft { get; set; }

        /// <summary>
        /// The right ankle mass
        /// </summary>
        public virtual AnkleMassR AnkleRight { get; set; }

        /// <summary>
        /// The neck mass
        /// </summary>
        public virtual NeckMass Neck { get; set; }

        /// <summary>
        /// The left thigh mass
        /// </summary>
        public virtual ThighMassL ThighLeft { get; set; }

        /// <summary>
        /// The right thigh mass
        /// </summary>
        public virtual ThighMassR ThighRight { get; set; }

        /// <summary>
        /// The bottom mass
        /// </summary>
        public virtual BottomMass Bottom { get; set; }

        /// <summary>
        /// The left leg mass
        /// </summary>
        public virtual LegMassL LegLeft { get; set; }

        /// <summary>
        /// The right leg mass
        /// </summary>
        public virtual LegMassR LegRight { get; set; }

        /// <summary>
        /// The left hand mass
        /// </summary>
        public virtual HandMassL HandLeft { get; set; }

        /// <summary>
        /// The right hand mass
        /// </summary>
        public virtual HandMassR HandRight { get; set; }

        /// <summary>
        /// The left foot mass
        /// </summary>
        public virtual FootMassL FootLeft { get; set; }

        /// <summary>
        /// The right foot mass
        /// </summary>
        public virtual FootMassR FootRight { get; set; }

        /// <summary>
        /// The head mass
        /// </summary>
        public virtual HeadMass Head { get; set; }

        /// <summary>
        /// The thorax mass
        /// </summary>
        public virtual ThoraxMass Thorax { get; set; }

        /// <summary>
        /// The body total mass
        /// </summary>
        public double TotalMass
        {
            get
            {
                return this.Abdomen.Mass + this.AnkleLeft.Mass + this.AnkleRight.Mass + this.ArmLeft.Mass + this.ArmRight.Mass
                    + this.Bottom.Mass + this.FootLeft.Mass + this.FootRight.Mass + this.ForeArmLeft.Mass + this.ForeArmRight.Mass
                    + this.HandLeft.Mass + this.HandRight.Mass + this.Head.Mass + this.LegLeft.Mass + this.LegRight.Mass
                    + this.Neck.Mass + this.ThighLeft.Mass + this.ThighRight.Mass + this.Thorax.Mass;
            }
        }

        /// <summary>
        /// The generation
        /// </summary>
        public virtual Generation Generation { get; set; }
    }
}
