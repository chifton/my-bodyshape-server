using MyShapeBody.AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyShapeBody.Engine
{
    /// <summary>
    /// Classe de base du concepteur de corps humain
    /// </summary>
    public class BodyGenerator
    {
        /// <summary>
        /// The body input
        /// </summary>
        private Body bodyInput;

        /// <summary>
        /// Packet de données JSON
        /// </summary>
        private object jsonPackage;

        /// <summary>
        /// Paquet Json parsé
        /// </summary>
        private JObject jsonObj;

        /// <summary>
        /// Constructeur
        /// </summary>
        public BodyGenerator()
        {
            bodyInput = new Body();
        }

        /// <summary>
        /// Récupère un membre Json en convertissant en mm
        /// </summary>
        private Member GetJsonMember(string member)
        {
            Member m = new Member();
            string memberJson = jsonObj[member].ToString();
            JObject objLast = JObject.Parse(memberJson);
            m.U1 = 10 * Convert.ToDouble(objLast["U1"].ToString()) / 2;
            m.U2 = 10 * Convert.ToDouble(objLast["U2"].ToString()) / 2;
            m.U3 = 10 * Convert.ToDouble(objLast["U3"].ToString()) / 2;
            m.V1 = 10 * Convert.ToDouble(objLast["V1"].ToString()) / 2;
            m.V2 = 10 * Convert.ToDouble(objLast["V2"].ToString()) / 2;
            m.V3 = 10 * Convert.ToDouble(objLast["V3"].ToString()) / 2;
            m.Z1 = 10 * Convert.ToDouble(objLast["Z1"].ToString());
            m.Z2 = 10 * Convert.ToDouble(objLast["Z2"].ToString());
            m.Z3 = 10 * Convert.ToDouble(objLast["Z3"].ToString());

            return m;
        }

        /// <summary>
        /// Convertit un membre en ShapeMeasure
        /// </summary>
        /// <param name="memb"></param>
        /// <returns></returns>
        private ShapeMeasure MemberToShapeMeasure(Member memb)
        {
            return new ShapeMeasure(memb.U1, memb.U2, memb.U3, memb.V1, memb.V2, memb.V3, memb.Z1, memb.Z2, memb.Z3);
        }

        /// <summary>
        /// Génère le corps humain en entrée
        /// </summary>
        public Body GenerateBody(object paquet)
        {
            jsonPackage = paquet;
            jsonObj = JObject.Parse(jsonPackage.ToString());

            // Body input
            bodyInput.Abdomen = new Abdomen(MemberToShapeMeasure(this.GetJsonMember("Abdomen")));
            bodyInput.Thorax = new Thorax(MemberToShapeMeasure(this.GetJsonMember("Thorax")));
            bodyInput.Neck = new Neck(MemberToShapeMeasure(this.GetJsonMember("Neck")));
            bodyInput.Head = new Head(MemberToShapeMeasure(this.GetJsonMember("Head")));
            bodyInput.Bottom = new Bottom(MemberToShapeMeasure(this.GetJsonMember("Bottom")));
            bodyInput.ThighLeft = new Thigh(MemberToShapeMeasure(this.GetJsonMember("Thigh")));
            bodyInput.ThighRight = new Thigh(MemberToShapeMeasure(this.GetJsonMember("Thigh")));
            bodyInput.LegLeft = new Leg(MemberToShapeMeasure(this.GetJsonMember("Leg")));
            bodyInput.LegRight = new Leg(MemberToShapeMeasure(this.GetJsonMember("Leg")));
            bodyInput.FootLeft = new Foot(MemberToShapeMeasure(this.GetJsonMember("Foot")));
            bodyInput.FootRight = new Foot(MemberToShapeMeasure(this.GetJsonMember("Foot")));
            bodyInput.HandLeft = new Hand(MemberToShapeMeasure(this.GetJsonMember("Hand")));
            bodyInput.HandRight = new Hand(MemberToShapeMeasure(this.GetJsonMember("Hand")));
            bodyInput.ForeArmLeft = new Forearm(MemberToShapeMeasure(this.GetJsonMember("ForeArm")));
            bodyInput.ForeArmRight = new Forearm(MemberToShapeMeasure(this.GetJsonMember("ForeArm")));
            bodyInput.ArmLeft = new Arm(MemberToShapeMeasure(this.GetJsonMember("Arm")));
            bodyInput.ArmRight = new Arm(MemberToShapeMeasure(this.GetJsonMember("Arm")));

            bodyInput.Picture_1 = jsonObj["Picture_1"].ToString();
            bodyInput.PictureWidth_1 = null;
            bodyInput.PictureHeight_1 = Convert.ToDouble(jsonObj["PictureHeight_1"]);
            bodyInput.PictureLeft_1 = Convert.ToDouble(jsonObj["PictureLeft_1"]);
            bodyInput.PictureTop_1 = Convert.ToDouble(jsonObj["PictureTop_1"]);
            bodyInput.Picture_2 = jsonObj["Picture_2"].ToString();
            bodyInput.PictureWidth_2 = null;
            bodyInput.PictureHeight_2 = Convert.ToDouble(jsonObj["PictureHeight_2"]);
            bodyInput.PictureLeft_2 = Convert.ToDouble(jsonObj["PictureLeft_2"]);
            bodyInput.PictureTop_2 = Convert.ToDouble(jsonObj["PictureTop_2"]);
            bodyInput.Height = Convert.ToDouble(jsonObj["Height"]);
            if (jsonObj["Weight"].Type != JTokenType.Null)
            {
                bodyInput.Weight = Convert.ToDouble(jsonObj["Weight"]);
            }

            // A corriger : pour l'instant, même masse que les mains
            //bodyInput.AnkleLeft = new Ankle(MemberToShapeMeasure(this.GetJsonMember("Ankle")));
            //bodyInput.AnkleRight = new Ankle(MemberToShapeMeasure(this.GetJsonMember("Ankle")));
            bodyInput.AnkleLeft = new Ankle(MemberToShapeMeasure(this.GetJsonMember("Hand")));
            bodyInput.AnkleRight = new Ankle(MemberToShapeMeasure(this.GetJsonMember("Hand")));

            return bodyInput;
        }
    }

    /// <summary>
    /// Classe basique de membre
    /// </summary>
    public class Member
    {
        public double U1 {get; set;}
        public double U2 { get; set; }
        public double U3 { get; set; }

        public double V1 { get; set; }
        public double V2 { get; set; }
        public double V3 { get; set; }

        public double Z1 { get; set; }
        public double Z2 { get; set; }
        public double Z3 { get; set; }
    }
}