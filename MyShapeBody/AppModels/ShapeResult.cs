using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShapeBody.AppModels
{
    /// <summary>
    /// Classe de base regroupant les résultats calculés pour un membre de corps humain
    /// </summary>
    public class ShapeResult
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public ShapeResult(double m, double mc)
        {
            this.Mass = m;
            this.MassCenter = mc;
        }

        /// <summary>
        /// The mass of the member
        /// </summary>
        public double Mass { get; set; }

        /// <summary>
        /// The mass center of the member
        /// </summary>
        public double MassCenter { get; set; }
    }
}