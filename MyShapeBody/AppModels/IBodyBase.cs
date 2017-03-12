using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace MyShapeBody.AppModels
{
    /// <summary>
    /// Interface de base d'un corps humain
    /// </summary>
    public interface IBodyBase
    {
        /// <summary>
        /// The abdomen
        /// </summary>
        Abdomen Abdomen { get; set; }

        /// <summary>
        /// The left forearm
        /// </summary>
        Forearm ForeArmLeft { get; set; }

        /// <summary>
        /// The right forearm
        /// </summary>
        Forearm ForeArmRight { get; set; }

        /// <summary>
        /// The left arm
        /// </summary>
        Arm ArmLeft { get; set; }

        /// <summary>
        /// The right arm
        /// </summary>
        Arm ArmRight { get; set; }

        ///// <summary>
        ///// The left ankle
        ///// </summary>
        //Ankle AnkleLeft { get; set; }

        ///// <summary>
        ///// The right ankle
        ///// </summary>
        //Ankle AnkleRight { get; set; }

        /// <summary>
        /// The neck
        /// </summary>
        Neck Neck { get; set; }

        /// <summary>
        /// The left thigh
        /// </summary>
        Thigh ThighLeft { get; set; }

        /// <summary>
        /// The right thigh
        /// </summary>
        Thigh ThighRight { get; set; }

        /// <summary>
        /// The bottom
        /// </summary>
        Bottom Bottom { get; set; }

        /// <summary>
        /// The left leg
        /// </summary>
        Leg LegLeft { get; set; }

        /// <summary>
        /// The right leg
        /// </summary>
        Leg LegRight { get; set; }

        /// <summary>
        /// The left hand
        /// </summary>
        Hand HandLeft { get; set; }

        /// <summary>
        /// The right hand
        /// </summary>
        Hand HandRight { get; set; }

        /// <summary>
        /// The left foot
        /// </summary>
        Foot FootLeft { get; set; }

        /// <summary>
        /// The right foot
        /// </summary>
        Foot FootRight { get; set; }

        /// <summary>
        /// The head
        /// </summary>
        Head Head { get; set; }

        /// <summary>
        /// The thorax
        /// </summary>
        Thorax Thorax { get; set; }
    }
}