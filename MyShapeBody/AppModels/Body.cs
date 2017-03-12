using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShapeBody.AppModels
{
    /// <summary>
    /// Classe de base représentant un corps humain
    /// </summary>
    public class Body : IBodyBase
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public Body()
        {
            // Ajout de contraintes spécifiques au corps humain
            // TODO
        }

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
        public Abdomen Abdomen { get; set; }

        /// <summary>
        /// The left forearm
        /// </summary>
        public Forearm ForeArmLeft { get; set; }

        /// <summary>
        /// The right forearm
        /// </summary>
        public Forearm ForeArmRight { get; set; }

        /// <summary>
        /// The left arm
        /// </summary>
        public Arm ArmLeft { get; set; }

        /// <summary>
        /// The right arm
        /// </summary>
        public Arm ArmRight { get; set; }

        ///// <summary>
        ///// The left ankle
        ///// </summary>
        //public Ankle AnkleLeft { get; set; }

        ///// <summary>
        ///// The right ankle
        ///// </summary>
        //public Ankle AnkleRight { get; set; }

        /// <summary>
        /// The neck
        /// </summary>
        public Neck Neck { get; set; }

        /// <summary>
        /// The left thigh
        /// </summary>
        public Thigh ThighLeft { get; set; }

        /// <summary>
        /// The right thigh
        /// </summary>
        public Thigh ThighRight { get; set; }

        /// <summary>
        /// The bottom
        /// </summary>
        public Bottom Bottom { get; set; }

        /// <summary>
        /// The left leg
        /// </summary>
        public Leg LegLeft { get; set; }

        /// <summary>
        /// The right leg
        /// </summary>
        public Leg LegRight { get; set; }

        /// <summary>
        /// The left hand
        /// </summary>
        public Hand HandLeft { get; set; }

        /// <summary>
        /// The right hand
        /// </summary>
        public Hand HandRight { get; set; }

        /// <summary>
        /// The left foot
        /// </summary>
        public Foot FootLeft { get; set; }

        /// <summary>
        /// The right foot
        /// </summary>
        public Foot FootRight { get; set; }

        /// <summary>
        /// The head
        /// </summary>
        public Head Head { get; set; }

        /// <summary>
        /// The thorax
        /// </summary>
        public Thorax Thorax { get; set; }
    }
}