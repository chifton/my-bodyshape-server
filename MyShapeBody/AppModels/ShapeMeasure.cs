using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShapeBody.AppModels
{
    /// <summary>
    /// Classe de base regroupant les mesures élémentaires d'un membre de corps humain
    /// </summary>
    public class ShapeMeasure
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="frontdown"></param>
        /// <param name="frontmiddle"></param>
        /// <param name="fronttop"></param>
        /// <param name="sidedown"></param>
        /// <param name="sidemiddle"></param>
        /// <param name="sidetop"></param>
        /// <param name="heightdown"></param>
        /// <param name="heightmiddle"></param>
        /// <param name="heighttop"></param>
        public ShapeMeasure(double frontdown, double frontmiddle, double fronttop,
                            double sidedown, double sidemiddle, double sidetop,
                            double heightdown, double heightmiddle, double heighttop)
        {
            this.Front_Down = frontdown;
            this.Front_Middle = frontmiddle;
            this.Front_Top = fronttop;

            this.Side_Down = sidedown;
            this.Side_Middle = sidemiddle;
            this.Side_Top = sidetop;

            this.Height_Down = heightdown;
            this.Height_Middle = heightmiddle;
            this.Height_Top = heighttop;
        }

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