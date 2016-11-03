using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShapeBody.AppModels
{
    /// <summary>
    /// Classe de base représentant une main calculée de corps humain
    /// </summary>
    public class HandMass : IShapeMass
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="result">L'objet calculé contenant la masse et le centre de masse</param>
        public HandMass(ShapeResult result)
        {
            // Attribution des valeurs
            this.Mass = result.Mass;
            this.MassCenter = result.MassCenter;

            // Ajout de contraintes spécifiques à ce résultat de membre
            // TODO
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