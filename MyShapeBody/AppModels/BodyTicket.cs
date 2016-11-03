using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShapeBody.AppModels
{
    /// <summary>
    /// Classe de base représentant un corps humain avec un ticket
    /// </summary>
    public class BodyTicket
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public BodyTicket(BodyMass bdyMss, Guid tckt)
        {
            this.BodyMass = bdyMss;
            this.Ticket = tckt;
        }

        /// <summary>
        /// The calculated body mass
        /// </summary>
        public BodyMass BodyMass { get; set; }

        /// <summary>
        /// The calculation ticket
        /// </summary>
        public Guid Ticket { get; set; }
    }
}