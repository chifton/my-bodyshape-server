using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShapeBody.AppModels
{
    /// <summary>
    /// Classe de base représentant une paire de fesses de corps humain
    /// </summary>
    public class Bottom : IShapeBase
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="mesure">L'objet mesure désérialisé provenant du client (smartphone, tablette, navigateur)</param>
        public Bottom(ShapeMeasure mesure)
        {
            // Nom
            this.Name = this.GetType().Name;

            // Attribution des valeurs
            this.Front_Down = mesure.Front_Down;
            this.Front_Middle = mesure.Front_Middle;
            this.Front_Top = mesure.Front_Top;

            this.Side_Down = mesure.Side_Down;
            this.Side_Middle = mesure.Side_Middle;
            this.Side_Top = mesure.Side_Top;

            this.Height_Down = mesure.Height_Down;
            this.Height_Middle = mesure.Height_Middle;
            this.Height_Top = mesure.Height_Top;

            // Ajout de contraintes spécifiques à ce membre
            // TODO
        }

        /// <summary>
        /// The name of the member.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The front down measure of the member
        /// </summary>
        public double Front_Down { get; set; }

        /// <summary>
        /// The front middle measure of the member
        /// </summary>
        public double Front_Middle { get; set; }

        /// <summary>
        /// The front top measure of the member
        /// </summary>
        public double Front_Top { get; set; }

        /// <summary>
        /// The side down measure of the member
        /// </summary>
        public double Side_Down { get; set; }

        /// <summary>
        /// The side middle measure of the member
        /// </summary>
        public double Side_Middle { get; set; }

        /// <summary>
        /// The side top measure of the member
        /// </summary>
        public double Side_Top { get; set; }

        /// <summary>
        /// The height down measure of the member
        /// </summary>
        public double Height_Down { get; set; }

        /// <summary>
        /// The height middle measure of the member
        /// </summary>
        public double Height_Middle { get; set; }

        /// <summary>
        /// The height top measure of the member
        /// </summary>
        public double Height_Top { get; set; }
    }
}