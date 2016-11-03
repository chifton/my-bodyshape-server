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
    /// Interface de base d'un membre du corps humain
    /// </summary>
    public interface IShapeBase
    {
        /// <summary>
        /// The name of the member.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The front down measure of the member
        /// </summary>
        double Front_Down { get; set; }

        /// <summary>
        /// The front middle measure of the member
        /// </summary>
        double Front_Middle { get; set; }

        /// <summary>
        /// The front top measure of the member
        /// </summary>
        double Front_Top { get; set; }

        /// <summary>
        /// The side down measure of the member
        /// </summary>
        double Side_Down { get; set; }

        /// <summary>
        /// The side middle measure of the member
        /// </summary>
        double Side_Middle { get; set; }

        /// <summary>
        /// The side top measure of the member
        /// </summary>
        double Side_Top { get; set; }

        /// <summary>
        /// The height down measure of the member
        /// </summary>
        double Height_Down { get; set; }

        /// <summary>
        /// The height middle measure of the member
        /// </summary>
        double Height_Middle { get; set; }

        /// <summary>
        /// The height top measure of the member
        /// </summary>
        double Height_Top { get; set; }
    }
}