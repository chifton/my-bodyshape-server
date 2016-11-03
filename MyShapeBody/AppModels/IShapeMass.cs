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
    /// Interface de base d'un membre calculé du corps humain
    /// </summary>
    public interface IShapeMass
    {
        /// <summary>
        /// The weight of the member
        /// </summary>
        double Mass { get; set; }

        /// <summary>
        /// The mass center of the member
        /// </summary>
        double MassCenter { get; set; }
    }
}