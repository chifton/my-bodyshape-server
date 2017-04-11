using MyShapeBody.AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShapeBody.Engine
{
    /// <summary>
    /// Classe de base du moteur de calcul de BodyShape
    /// </summary>
    public class BodyCalculator
    {
        /// <summary>
        /// The ticket
        /// </summary>
        private Guid ticket;

        /// <summary>
        /// The body input
        /// </summary>
        private Body bodyInput;

        /// <summary>
        /// The body output
        /// </summary>
        private BodyMass bodyOutput;

        /// <summary>
        /// Constructeur
        /// </summary>
        public BodyCalculator(Guid nbticket, Body body)
        {
            ticket = nbticket;
            bodyInput = body;
            bodyOutput = new BodyMass();

            // Autres traitements particuliers pour le moteur de calcul
        }

        /// <summary>
        /// Calcul des masses des membres de tout le corps humain
        /// </summary>
        public BodyTicket GenerateBodyMasses(decimal density)
        {
            // Masses generation
            bodyOutput.Abdomen = new AbdomenMass(GenerateShapeMass(bodyInput.Abdomen, density));
            //bodyOutput.AnkleLeft = new AnkleMass(GenerateShapeMass(bodyInput.AnkleLeft, density));
            //bodyOutput.AnkleRight = new AnkleMass(GenerateShapeMass(bodyInput.AnkleRight, density));
            bodyOutput.ArmLeft = new ArmMass(GenerateShapeMass(bodyInput.ArmLeft, density));
            bodyOutput.ArmRight = new ArmMass(GenerateShapeMass(bodyInput.ArmRight, density));
            bodyOutput.Bottom = new BottomMass(GenerateShapeMass(bodyInput.Bottom, density));
            bodyOutput.FootLeft = new FootMass(GenerateShapeMass(bodyInput.FootLeft, density));
            bodyOutput.FootRight = new FootMass(GenerateShapeMass(bodyInput.FootRight, density));
            bodyOutput.ForeArmLeft = new ForearmMass(GenerateShapeMass(bodyInput.ForeArmLeft, density));
            bodyOutput.ForeArmRight = new ForearmMass(GenerateShapeMass(bodyInput.ForeArmRight, density));
            bodyOutput.HandLeft = new HandMass(GenerateShapeMass(bodyInput.HandLeft, density));
            bodyOutput.HandRight = new HandMass(GenerateShapeMass(bodyInput.HandRight, density));
            bodyOutput.Head = new HeadMass(GenerateShapeMass(bodyInput.Head, density));
            bodyOutput.LegLeft = new LegMass(GenerateShapeMass(bodyInput.LegLeft, density));
            bodyOutput.LegRight = new LegMass(GenerateShapeMass(bodyInput.LegRight, density));
            bodyOutput.Neck = new NeckMass(GenerateShapeMass(bodyInput.Neck, density));
            bodyOutput.ThighLeft = new ThighMass(GenerateShapeMass(bodyInput.ThighLeft, density));
            bodyOutput.ThighRight = new ThighMass(GenerateShapeMass(bodyInput.ThighRight, density));
            bodyOutput.Thorax = new ThoraxMass(GenerateShapeMass(bodyInput.Thorax, density));

            return new BodyTicket(bodyOutput, ticket);
        }
        
        /// <summary>
        /// Calcul de la masse et du centre de masse d'un membre de corps humain
        /// </summary>
        private ShapeResult GenerateShapeMass(IShapeBase member, decimal configDensity)
        {
            // Determinants

            var density = Convert.ToDouble(configDensity);

            var actual = member;

            var defaultDistance = 0.1;

            // Zero test
            if(actual.Front_Down == 0)
            {
                actual.Front_Down = defaultDistance;
            }
            if (actual.Front_Middle == 0)
            {
                actual.Front_Middle = defaultDistance;
            }
            if (actual.Front_Top == 0)
            {
                actual.Front_Top = defaultDistance;
            }
            if (actual.Side_Down == 0)
            {
                actual.Side_Down = defaultDistance;
            }
            if (actual.Side_Middle == 0)
            {
                actual.Side_Middle = defaultDistance;
            }
            if (actual.Side_Top == 0)
            {
                actual.Side_Top = defaultDistance;
            }

            var p = Math.Pow(actual.Height_Down, 2) * actual.Height_Middle
                    - Math.Pow(actual.Height_Middle, 2) * actual.Height_Down
                    - Math.Pow(actual.Height_Down, 2) * actual.Height_Top
                    + Math.Pow(actual.Height_Top, 2) * actual.Height_Down
                    + Math.Pow(actual.Height_Middle, 2) * actual.Height_Top
                    - Math.Pow(actual.Height_Top, 2) * actual.Height_Middle;

            var a = (Math.Pow(actual.Side_Down, 2) * actual.Height_Middle
                    - Math.Pow(actual.Side_Middle, 2) * actual.Height_Down
                    - Math.Pow(actual.Side_Down, 2) * actual.Height_Top
                    + Math.Pow(actual.Side_Top, 2) * actual.Height_Down
                    + Math.Pow(actual.Side_Middle, 2) * actual.Height_Top
                    - Math.Pow(actual.Side_Top, 2) * actual.Height_Middle)
                    / p;

            var b = (Math.Pow(actual.Height_Down, 2) * Math.Pow(actual.Side_Middle, 2)
                    - Math.Pow(actual.Height_Middle, 2) * Math.Pow(actual.Side_Down, 2)
                    - Math.Pow(actual.Height_Down, 2) * Math.Pow(actual.Side_Top, 2)
                    + Math.Pow(actual.Height_Top, 2) * Math.Pow(actual.Side_Down, 2)
                    + Math.Pow(actual.Height_Middle, 2) * Math.Pow(actual.Side_Top, 2)
                    - Math.Pow(actual.Height_Top, 2) * Math.Pow(actual.Side_Middle, 2))
                    / p;

            var c = (Math.Pow(actual.Side_Top, 2) * Math.Pow(actual.Height_Down, 2) * actual.Height_Middle
                    - Math.Pow(actual.Side_Top, 2) * Math.Pow(actual.Height_Middle, 2) * actual.Height_Down
                    - Math.Pow(actual.Side_Middle, 2) * Math.Pow(actual.Height_Down, 2) * actual.Height_Top
                    + Math.Pow(actual.Side_Middle, 2) * Math.Pow(actual.Height_Top, 2) * actual.Height_Down
                    + Math.Pow(actual.Side_Down, 2) * Math.Pow(actual.Height_Middle, 2) * actual.Height_Top
                    - Math.Pow(actual.Side_Down, 2) * Math.Pow(actual.Height_Top, 2) * actual.Height_Middle)
                    / p;

            var k = (actual.Front_Down / actual.Side_Down + actual.Front_Middle / actual.Side_Middle
                     + actual.Front_Top / actual.Side_Top) / 3;
            
            // Results

            var mass = density * Math.PI * k * actual.Height_Top
                 * (3 * b * actual.Height_Top + 6 * c + 2 * a * Math.Pow(actual.Height_Top, 2))
                 / 6;

            var masscenter = (3 * a * Math.Pow(actual.Height_Top, 2) + 6 * c + 4 * b * actual.Height_Top)
                / (6 * c + 3 * b * actual.Height_Top + 2 * a * Math.Pow(actual.Height_Top, 2))
                / 2;

            // Que deux valeurs après la virgule
            mass = Math.Round(mass, 2);
            masscenter = Math.Round(masscenter, 2);
            
            return new ShapeResult(mass, masscenter);
        }
    }
}