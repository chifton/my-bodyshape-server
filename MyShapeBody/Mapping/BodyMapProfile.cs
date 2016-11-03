// ===============================
// *******************************
// The body mapper configuration class.
// ===============================
// *******************************

namespace MyShapeBody.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using AutoMapper;

    using Entities = BodyShapeData.Entities;
    using AppModels = AppModels;

    public class BodyMapProfile : Profile
    {
        /// <summary>
        /// The constructor
        /// </summary>
        public BodyMapProfile() 
        {
            this.CreateMap<AppModels.Body, Entities.BodySchema>()
            .AfterMap((s, d) => d.Abdomen.Laterality = Entities.Laterality.None)
            .AfterMap((s, d) => d.AnkleLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.AnkleRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.ArmLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.ArmRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.Bottom.Laterality = Entities.Laterality.None)
            .AfterMap((s, d) => d.FootLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.FootRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.ForeArmLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.ForeArmRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.HandLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.HandRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.Head.Laterality = Entities.Laterality.None)
            .AfterMap((s, d) => d.LegLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.LegRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.Neck.Laterality = Entities.Laterality.None)
            .AfterMap((s, d) => d.ThighLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.ThighRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.Thorax.Laterality = Entities.Laterality.None);

            this.CreateMap<AppModels.BodyMass, Entities.BodyResult>()
            .AfterMap((s, d) => d.Abdomen.Laterality = Entities.Laterality.None)
            .AfterMap((s, d) => d.AnkleLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.AnkleRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.ArmLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.ArmRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.Bottom.Laterality = Entities.Laterality.None)
            .AfterMap((s, d) => d.FootLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.FootRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.ForeArmLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.ForeArmRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.HandLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.HandRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.Head.Laterality = Entities.Laterality.None)
            .AfterMap((s, d) => d.LegLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.LegRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.Neck.Laterality = Entities.Laterality.None)
            .AfterMap((s, d) => d.ThighLeft.Laterality = Entities.Laterality.Left)
            .AfterMap((s, d) => d.ThighRight.Laterality = Entities.Laterality.Right)
            .AfterMap((s, d) => d.Thorax.Laterality = Entities.Laterality.None);

            this.CreateMap<AppModels.Abdomen, Entities.Abdomen>();
            this.CreateMap<AppModels.Ankle, Entities.AnkleL>();
            this.CreateMap<AppModels.Ankle, Entities.AnkleR>();
            this.CreateMap<AppModels.Arm, Entities.ArmL>();
            this.CreateMap<AppModels.Arm, Entities.ArmR>();
            this.CreateMap<AppModels.Bottom, Entities.Bottom>();
            this.CreateMap<AppModels.Foot, Entities.FootL>();
            this.CreateMap<AppModels.Foot, Entities.FootR>();
            this.CreateMap<AppModels.Forearm, Entities.ForearmL>();
            this.CreateMap<AppModels.Forearm, Entities.ForearmR>();
            this.CreateMap<AppModels.Hand, Entities.HandL>();
            this.CreateMap<AppModels.Hand, Entities.HandR>();
            this.CreateMap<AppModels.Head, Entities.Head>();
            this.CreateMap<AppModels.Leg, Entities.LegL>();
            this.CreateMap<AppModels.Leg, Entities.LegR>();
            this.CreateMap<AppModels.Neck, Entities.Neck>();
            this.CreateMap<AppModels.Thigh, Entities.ThighL>();
            this.CreateMap<AppModels.Thigh, Entities.ThighR>();
            this.CreateMap<AppModels.Thorax, Entities.Thorax>();

            this.CreateMap<AppModels.AbdomenMass, Entities.AbdomenMass>();
            this.CreateMap<AppModels.AnkleMass, Entities.AnkleMassL>();
            this.CreateMap<AppModels.AnkleMass, Entities.AnkleMassR>();
            this.CreateMap<AppModels.ArmMass, Entities.ArmMassL>();
            this.CreateMap<AppModels.ArmMass, Entities.ArmMassR>();
            this.CreateMap<AppModels.BottomMass, Entities.BottomMass>();
            this.CreateMap<AppModels.FootMass, Entities.FootMassL>();
            this.CreateMap<AppModels.FootMass, Entities.FootMassR>();
            this.CreateMap<AppModels.ForearmMass, Entities.ForearmMassL>();
            this.CreateMap<AppModels.ForearmMass, Entities.ForearmMassR>();
            this.CreateMap<AppModels.HandMass, Entities.HandMassL>();
            this.CreateMap<AppModels.HandMass, Entities.HandMassR>();
            this.CreateMap<AppModels.HeadMass, Entities.HeadMass>();
            this.CreateMap<AppModels.LegMass, Entities.LegMassL>();
            this.CreateMap<AppModels.LegMass, Entities.LegMassR>();
            this.CreateMap<AppModels.NeckMass, Entities.NeckMass>();
            this.CreateMap<AppModels.ThighMass, Entities.ThighMassL>();
            this.CreateMap<AppModels.ThighMass, Entities.ThighMassR>();
            this.CreateMap<AppModels.ThoraxMass, Entities.ThoraxMass>();
        }
    }
}