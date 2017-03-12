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
    /// Interface de base d'un corps humain calculé
    /// </summary>
    public interface IBodyMass
    {
        /// <summary>
        /// The abdomen mass
        /// </summary>
        AbdomenMass Abdomen { get; set; }

        /// <summary>
        /// The left forearm mass
        /// </summary>
        ForearmMass ForeArmLeft { get; set; }

        /// <summary>
        /// The right forearm mass
        /// </summary>
        ForearmMass ForeArmRight { get; set; }

        /// <summary>
        /// The left arm mass
        /// </summary>
        ArmMass ArmLeft { get; set; }

        /// <summary>
        /// The right arm mass
        /// </summary>
        ArmMass ArmRight { get; set; }

        ///// <summary>
        ///// The left ankle mass
        ///// </summary>
        //AnkleMass AnkleLeft { get; set; }

        ///// <summary>
        ///// The right ankle mass
        ///// </summary>
        //AnkleMass AnkleRight { get; set; }

        /// <summary>
        /// The neck mass
        /// </summary>
        NeckMass Neck { get; set; }

        /// <summary>
        /// The left thigh mass
        /// </summary>
        ThighMass ThighLeft { get; set; }

        /// <summary>
        /// The right thigh mass
        /// </summary>
        ThighMass ThighRight { get; set; }

        /// <summary>
        /// The bottom mass
        /// </summary>
        BottomMass Bottom { get; set; }

        /// <summary>
        /// The left leg mass
        /// </summary>
        LegMass LegLeft { get; set; }

        /// <summary>
        /// The right leg mass
        /// </summary>
        LegMass LegRight { get; set; }

        /// <summary>
        /// The left hand mass
        /// </summary>
        HandMass HandLeft { get; set; }

        /// <summary>
        /// The right hand mass
        /// </summary>
        HandMass HandRight { get; set; }

        /// <summary>
        /// The left foot mass
        /// </summary>
        FootMass FootLeft { get; set; }

        /// <summary>
        /// The right foot mass
        /// </summary>
        FootMass FootRight { get; set; }

        /// <summary>
        /// The head mass
        /// </summary>
        HeadMass Head { get; set; }

        /// <summary>
        /// The thorax mass
        /// </summary>
        ThoraxMass Thorax { get; set; }
    }
}