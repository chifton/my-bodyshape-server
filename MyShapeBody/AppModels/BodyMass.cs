using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShapeBody.AppModels
{
    /// <summary>
    /// Classe de base représentant un corps humain calculé
    /// </summary>
    public class BodyMass : IBodyMass
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public BodyMass()
        {
            // Ajout de contraintes spécifiques au corps humain calculé
            // TODO
        }

        /// <summary>
        /// The abdomen mass
        /// </summary>
        public AbdomenMass Abdomen { get; set; }

        /// <summary>
        /// The left forearm mass
        /// </summary>
        public ForearmMass ForeArmLeft { get; set; }

        /// <summary>
        /// The right forearm mass
        /// </summary>
        public ForearmMass ForeArmRight { get; set; }

        /// <summary>
        /// The left arm mass
        /// </summary>
        public ArmMass ArmLeft { get; set; }

        /// <summary>
        /// The right arm mass
        /// </summary>
        public ArmMass ArmRight { get; set; }

        ///// <summary>
        ///// The left ankle mass
        ///// </summary>
        //public AnkleMass AnkleLeft { get; set; }

        ///// <summary>
        ///// The right ankle mass
        ///// </summary>
        //public AnkleMass AnkleRight { get; set; }

        /// <summary>
        /// The neck mass
        /// </summary>
        public NeckMass Neck { get; set; }

        /// <summary>
        /// The left thigh mass
        /// </summary>
        public ThighMass ThighLeft { get; set; }

        /// <summary>
        /// The right thigh mass
        /// </summary>
        public ThighMass ThighRight { get; set; }

        /// <summary>
        /// The bottom mass
        /// </summary>
        public BottomMass Bottom { get; set; }

        /// <summary>
        /// The left leg mass
        /// </summary>
        public LegMass LegLeft { get; set; }

        /// <summary>
        /// The right leg mass
        /// </summary>
        public LegMass LegRight { get; set; }

        /// <summary>
        /// The left hand mass
        /// </summary>
        public HandMass HandLeft { get; set; }

        /// <summary>
        /// The right hand mass
        /// </summary>
        public HandMass HandRight { get; set; }

        /// <summary>
        /// The left foot mass
        /// </summary>
        public FootMass FootLeft { get; set; }

        /// <summary>
        /// The right foot mass
        /// </summary>
        public FootMass FootRight { get; set; }

        /// <summary>
        /// The head mass
        /// </summary>
        public HeadMass Head { get; set; }

        /// <summary>
        /// The thorax mass
        /// </summary>
        public ThoraxMass Thorax { get; set; }
        
        /// <summary>
        /// The body total mass
        /// </summary>
        public double TotalMass
        {
            get
            {
                return Math.Round(this.Abdomen.Mass + this.ArmLeft.Mass + this.ArmRight.Mass
                    + this.Bottom.Mass + this.FootLeft.Mass + this.FootRight.Mass + this.ForeArmLeft.Mass + this.ForeArmRight.Mass
                    + this.HandLeft.Mass + this.HandRight.Mass + this.Head.Mass + this.LegLeft.Mass + this.LegRight.Mass
                    + this.Neck.Mass + this.ThighLeft.Mass + this.ThighRight.Mass + this.Thorax.Mass, 2);
            }
        }
    }
}