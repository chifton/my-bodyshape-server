// ===============================
// *******************************
// The bodyshape data context
// ===============================
// *******************************

namespace BodyShapeData
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Validation;
    using System.Data.Entity.Infrastructure;
    using System.Text;

    using Entities;

    public class BodyShapeContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « BodyShapeContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « BodyShapeData.BodyShapeContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « BodyShapeContext » dans le fichier de configuration de l'application.
        public BodyShapeContext()
            : base("name=BodyShapeContext")
        {
        }

        /// <summary>
        /// The OnModelCreating method.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Generation>()
                .HasRequired(t => t.BodySchema)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(x => x.Generation)
                .WithRequiredDependent();
            modelBuilder.Entity<Generation>()
                .HasRequired(t => t.BodyResult)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(x => x.Generation)
                .WithRequiredDependent();

            modelBuilder.Entity<BodySchema>()
                .HasRequired(x => x.Abdomen)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<Abdomen>()
            //    .HasRequired(x => x.BodySchema)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(x => x.AnkleLeft)     
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(x => x.AnkleRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<Ankle>()
            //    .HasRequired(x => x.BodySchema)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.ArmLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.ArmRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<Arm>()
            //    .HasRequired(x => x.BodySchema)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.Bottom)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<Bottom>()
            //    .HasRequired(t => t.BodySchema)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.FootLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.FootRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<Foot>()
            //    .HasRequired(x => x.BodySchema)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.ForeArmLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.ForeArmRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<Forearm>()
            //    .HasRequired(x => x.BodySchema)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.HandLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.HandRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<Hand>()
            //    .HasRequired(x => x.BodySchema)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.Head)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<Head>()
            //    .HasRequired(t => t.BodySchema)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.LegLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.LegRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<Leg>()
            //    .HasRequired(x => x.BodySchema)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.Neck)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<Neck>()
            //    .HasRequired(t => t.BodySchema)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.ThighLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(t => t.ThighRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<Thigh>()
            //    .HasRequired(x => x.BodySchema)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodySchema>()
                .HasRequired(x => x.Thorax)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<Thorax>()
            //    .HasRequired(x => x.BodySchema)
            //    .WithRequiredDependent();

            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.Abdomen)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<AbdomenMass>()
            //    .HasRequired(t => t.BodyResult)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.AnkleLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.AnkleRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<AnkleMass>()
            //    .HasRequired(t => t.BodyResult)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.ArmLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.ArmRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<ArmMass>()
            //    .HasRequired(t => t.BodyResult)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.Bottom)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<BottomMass>()
            //    .HasRequired(t => t.BodyResult)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.FootLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.FootRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<FootMass>()
            //    .HasRequired(t => t.BodyResult)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.ForeArmLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.ForeArmRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<ForearmMass>()
            //    .HasRequired(t => t.BodyResult)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.HandLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.HandRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<HandMass>()
            //    .HasRequired(t => t.BodyResult)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.Head)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<HeadMass>()
            //    .HasRequired(t => t.BodyResult)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.LegLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.LegRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<LegMass>()
            //    .HasRequired(t => t.BodyResult)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.Neck)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<NeckMass>()
            //    .HasRequired(t => t.BodyResult)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.ThighLeft)
                .WithRequiredPrincipal();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.ThighRight)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<ThighMass>()
            //    .HasRequired(t => t.BodyResult)
            //    .WithRequiredDependent();
            modelBuilder.Entity<BodyResult>()
                .HasRequired(t => t.Thorax)
                .WithRequiredPrincipal();
            //modelBuilder.Entity<ThoraxMass>()
            //    .HasRequired(t => t.BodyResult)
            //    .WithRequiredDependent();
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        /// <summary>
        /// The generations
        /// </summary>
        public virtual DbSet<Generation> Generations { get; set; }

        /// <summary>
        /// The body schemas
        /// </summary>
        public virtual DbSet<BodySchema> BodySchemas { get; set; }

        /// <summary>
        /// The body results
        /// </summary>
        public virtual DbSet<BodyResult> BodyResults { get; set; }

        /// <summary>
        /// The abdomens
        /// </summary>
        public virtual DbSet<Abdomen> Abdomens { get; set; }

        /// <summary>
        /// The abdomens masses
        /// </summary>
        public virtual DbSet<AbdomenMass> AbdomenMasses { get; set; }

        /// <summary>
        /// The left ankles
        /// </summary>
        public virtual DbSet<AnkleL> AnklesL { get; set; }

        /// <summary>
        /// The right ankles
        /// </summary>
        public virtual DbSet<AnkleR> AnklesR { get; set; }

        /// <summary>
        /// The left ankles masses
        /// </summary>
        public virtual DbSet<AnkleMassL> AnkleMassesL { get; set; }

        /// <summary>
        /// The right ankles masses
        /// </summary>
        public virtual DbSet<AnkleMassR> AnkleMassesR { get; set; }

        /// <summary>
        /// The left arms
        /// </summary>
        public virtual DbSet<ArmL> ArmsL { get; set; }

        /// <summary>
        /// The right arms
        /// </summary>
        public virtual DbSet<ArmR> ArmsR { get; set; }

        /// <summary>
        /// The left arms masses
        /// </summary>
        public virtual DbSet<ArmMassL> ArmMassesL { get; set; }

        /// <summary>
        /// The right arms masses
        /// </summary>
        public virtual DbSet<ArmMassR> ArmMassesR { get; set; }

        /// <summary>
        /// The bottoms
        /// </summary>
        public virtual DbSet<Bottom> Bottoms { get; set; }

        /// <summary>
        /// The bottom masses
        /// </summary>
        public virtual DbSet<BottomMass> BottomMasses { get; set; }

        /// <summary>
        /// The left foots
        /// </summary>
        public virtual DbSet<FootL> FootsL { get; set; }

        /// <summary>
        /// The right foots
        /// </summary>
        public virtual DbSet<FootR> FootsR { get; set; }

        /// <summary>
        /// The left foot masses
        /// </summary>
        public virtual DbSet<FootMassL> FootMassesL { get; set; }

        /// <summary>
        /// The right foot masses
        /// </summary>
        public virtual DbSet<FootMassR> FootMassesR { get; set; }

        /// <summary>
        /// The left forearms
        /// </summary>
        public virtual DbSet<ForearmL> ForearmsL { get; set; }

        /// <summary>
        /// The right forearms
        /// </summary>
        public virtual DbSet<ForearmR> ForearmsR { get; set; }

        /// <summary>
        /// The left forearm masses
        /// </summary>
        public virtual DbSet<ForearmMassL> ForearmsMassesL { get; set; }

        /// <summary>
        /// The right forearm masses
        /// </summary>
        public virtual DbSet<ForearmMassR> ForearmsMassesR { get; set; }

        /// <summary>
        /// The left hands
        /// </summary>
        public virtual DbSet<HandL> HandsL { get; set; }

        /// <summary>
        /// The right hands
        /// </summary>
        public virtual DbSet<HandR> HandsR { get; set; }

        /// <summary>
        /// The left hand masses
        /// </summary>
        public virtual DbSet<HandMassL> HandMassesL { get; set; }

        /// <summary>
        /// The right hand masses
        /// </summary>
        public virtual DbSet<HandMassR> HandMassesR { get; set; }

        /// <summary>
        /// The heads
        /// </summary>
        public virtual DbSet<Head> Heads { get; set; }

        /// <summary>
        /// The head masses
        /// </summary>
        public virtual DbSet<HeadMass> HeadMasses { get; set; }

        /// <summary>
        /// The left legs
        /// </summary>
        public virtual DbSet<LegL> LegsL { get; set; }

        /// <summary>
        /// The right legs
        /// </summary>
        public virtual DbSet<LegR> LegsR { get; set; }

        /// <summary>
        /// The left leg masses
        /// </summary>
        public virtual DbSet<LegMassL> LegMassesL { get; set; }

        /// <summary>
        /// The right leg masses
        /// </summary>
        public virtual DbSet<LegMassR> LegMassesR { get; set; }

        /// <summary>
        /// The necks
        /// </summary>
        public virtual DbSet<Neck> Necks { get; set; }

        /// <summary>
        /// The neck masses
        /// </summary>
        public virtual DbSet<NeckMass> NeckMasses { get; set; }

        /// <summary>
        /// The left thighs
        /// </summary>
        public virtual DbSet<ThighL> ThighsL { get; set; }

        /// <summary>
        /// The right thighs
        /// </summary>
        public virtual DbSet<ThighR> ThighsR { get; set; }

        /// <summary>
        /// The left thigh masses
        /// </summary>
        public virtual DbSet<ThighMassL> ThighMassesL { get; set; }

        /// <summary>
        /// The right thigh masses
        /// </summary>
        public virtual DbSet<ThighMassR> ThighMassesR { get; set; }

        /// <summary>
        /// The thorax
        /// </summary>
        public virtual DbSet<Thorax> Thoraxes { get; set; }

        /// <summary>
        /// The thorax masses
        /// </summary>
        public virtual DbSet<ThoraxMass> ThoraxMasses { get; set; }
    }
}