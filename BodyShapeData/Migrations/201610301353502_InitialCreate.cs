namespace BodyShapeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbdomenMasses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Abdomens",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AnkleMassesL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AnkleMassesR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AnklesL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AnklesR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ArmMassesL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ArmMassesR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ArmsL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ArmsR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.BodyResults",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Generations", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.BottomMasses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.FootMassesL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.FootMassesR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ForearmMassesL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ForearmMassesR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Generations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(),
                        AnonymousId = c.Guid(nullable: false),
                        HasAccount = c.Boolean(nullable: false),
                        GenerationDate = c.DateTime(nullable: false),
                        Success = c.Boolean(),
                        ErrorPercent = c.Double(),
                        FrontPicture = c.String(),
                        SidePicture = c.String(),
                        Height = c.Double(nullable: false),
                        ExpectedWeight = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BodySchemas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(),
                        Picture_1 = c.String(),
                        PictureWidth_1 = c.Double(),
                        PictureHeight_1 = c.Double(),
                        PictureLeft_1 = c.Double(),
                        PictureTop_1 = c.Double(),
                        Picture_2 = c.String(),
                        PictureWidth_2 = c.Double(),
                        PictureHeight_2 = c.Double(),
                        PictureLeft_2 = c.Double(),
                        PictureTop_2 = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Generations", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Bottoms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.FeetL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.FeetR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ForearmsL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ForearmsR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.HandsL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.HandsR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Heads",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.LegsL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.LegsR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Necks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ThighsL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ThighsR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Thoraxs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Front_Down = c.Double(nullable: false),
                        Front_Middle = c.Double(nullable: false),
                        Front_Top = c.Double(nullable: false),
                        Side_Down = c.Double(nullable: false),
                        Side_Middle = c.Double(nullable: false),
                        Side_Top = c.Double(nullable: false),
                        Height_Down = c.Double(nullable: false),
                        Height_Middle = c.Double(nullable: false),
                        Height_Top = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodySchemas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.HandMassesL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.HandMassesR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.HeadMasses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.LegMassesL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.LegMassesR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.NeckMasses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ThighMassesL",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ThighMassesR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ThoraxMasses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Laterality = c.Int(nullable: false),
                        Mass = c.Double(nullable: false),
                        MassCenter = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyResults", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThoraxMasses", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.ThighMassesR", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.ThighMassesL", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.NeckMasses", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.LegMassesR", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.LegMassesL", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.HeadMasses", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.HandMassesR", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.HandMassesL", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.Thoraxs", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.ThighsR", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.ThighsL", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.Necks", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.LegsR", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.LegsL", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.Heads", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.HandsR", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.HandsL", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.BodySchemas", "Id", "dbo.Generations");
            DropForeignKey("dbo.ForearmsR", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.ForearmsL", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.FeetR", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.FeetL", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.Bottoms", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.ArmsR", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.ArmsL", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.AnklesR", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.AnklesL", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.Abdomens", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.BodyResults", "Id", "dbo.Generations");
            DropForeignKey("dbo.ForearmMassesR", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.ForearmMassesL", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.FootMassesR", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.FootMassesL", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.BottomMasses", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.ArmMassesR", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.ArmMassesL", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.AnkleMassesR", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.AnkleMassesL", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.AbdomenMasses", "Id", "dbo.BodyResults");
            DropIndex("dbo.ThoraxMasses", new[] { "Id" });
            DropIndex("dbo.ThighMassesR", new[] { "Id" });
            DropIndex("dbo.ThighMassesL", new[] { "Id" });
            DropIndex("dbo.NeckMasses", new[] { "Id" });
            DropIndex("dbo.LegMassesR", new[] { "Id" });
            DropIndex("dbo.LegMassesL", new[] { "Id" });
            DropIndex("dbo.HeadMasses", new[] { "Id" });
            DropIndex("dbo.HandMassesR", new[] { "Id" });
            DropIndex("dbo.HandMassesL", new[] { "Id" });
            DropIndex("dbo.Thoraxs", new[] { "Id" });
            DropIndex("dbo.ThighsR", new[] { "Id" });
            DropIndex("dbo.ThighsL", new[] { "Id" });
            DropIndex("dbo.Necks", new[] { "Id" });
            DropIndex("dbo.LegsR", new[] { "Id" });
            DropIndex("dbo.LegsL", new[] { "Id" });
            DropIndex("dbo.Heads", new[] { "Id" });
            DropIndex("dbo.HandsR", new[] { "Id" });
            DropIndex("dbo.HandsL", new[] { "Id" });
            DropIndex("dbo.ForearmsR", new[] { "Id" });
            DropIndex("dbo.ForearmsL", new[] { "Id" });
            DropIndex("dbo.FeetR", new[] { "Id" });
            DropIndex("dbo.FeetL", new[] { "Id" });
            DropIndex("dbo.Bottoms", new[] { "Id" });
            DropIndex("dbo.BodySchemas", new[] { "Id" });
            DropIndex("dbo.ForearmMassesR", new[] { "Id" });
            DropIndex("dbo.ForearmMassesL", new[] { "Id" });
            DropIndex("dbo.FootMassesR", new[] { "Id" });
            DropIndex("dbo.FootMassesL", new[] { "Id" });
            DropIndex("dbo.BottomMasses", new[] { "Id" });
            DropIndex("dbo.BodyResults", new[] { "Id" });
            DropIndex("dbo.ArmsR", new[] { "Id" });
            DropIndex("dbo.ArmsL", new[] { "Id" });
            DropIndex("dbo.ArmMassesR", new[] { "Id" });
            DropIndex("dbo.ArmMassesL", new[] { "Id" });
            DropIndex("dbo.AnklesR", new[] { "Id" });
            DropIndex("dbo.AnklesL", new[] { "Id" });
            DropIndex("dbo.AnkleMassesR", new[] { "Id" });
            DropIndex("dbo.AnkleMassesL", new[] { "Id" });
            DropIndex("dbo.Abdomens", new[] { "Id" });
            DropIndex("dbo.AbdomenMasses", new[] { "Id" });
            DropTable("dbo.ThoraxMasses");
            DropTable("dbo.ThighMassesR");
            DropTable("dbo.ThighMassesL");
            DropTable("dbo.NeckMasses");
            DropTable("dbo.LegMassesR");
            DropTable("dbo.LegMassesL");
            DropTable("dbo.HeadMasses");
            DropTable("dbo.HandMassesR");
            DropTable("dbo.HandMassesL");
            DropTable("dbo.Thoraxs");
            DropTable("dbo.ThighsR");
            DropTable("dbo.ThighsL");
            DropTable("dbo.Necks");
            DropTable("dbo.LegsR");
            DropTable("dbo.LegsL");
            DropTable("dbo.Heads");
            DropTable("dbo.HandsR");
            DropTable("dbo.HandsL");
            DropTable("dbo.ForearmsR");
            DropTable("dbo.ForearmsL");
            DropTable("dbo.FeetR");
            DropTable("dbo.FeetL");
            DropTable("dbo.Bottoms");
            DropTable("dbo.BodySchemas");
            DropTable("dbo.Generations");
            DropTable("dbo.ForearmMassesR");
            DropTable("dbo.ForearmMassesL");
            DropTable("dbo.FootMassesR");
            DropTable("dbo.FootMassesL");
            DropTable("dbo.BottomMasses");
            DropTable("dbo.BodyResults");
            DropTable("dbo.ArmsR");
            DropTable("dbo.ArmsL");
            DropTable("dbo.ArmMassesR");
            DropTable("dbo.ArmMassesL");
            DropTable("dbo.AnklesR");
            DropTable("dbo.AnklesL");
            DropTable("dbo.AnkleMassesR");
            DropTable("dbo.AnkleMassesL");
            DropTable("dbo.Abdomens");
            DropTable("dbo.AbdomenMasses");
        }
    }
}
