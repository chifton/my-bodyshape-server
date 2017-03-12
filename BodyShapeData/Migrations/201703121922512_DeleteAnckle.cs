namespace BodyShapeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAnckle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnkleMassesL", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.AnkleMassesR", "Id", "dbo.BodyResults");
            DropForeignKey("dbo.AnklesL", "Id", "dbo.BodySchemas");
            DropForeignKey("dbo.AnklesR", "Id", "dbo.BodySchemas");
            DropIndex("dbo.AnkleMassesL", new[] { "Id" });
            DropIndex("dbo.AnkleMassesR", new[] { "Id" });
            DropIndex("dbo.AnklesL", new[] { "Id" });
            DropIndex("dbo.AnklesR", new[] { "Id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.AnklesR", "Id");
            CreateIndex("dbo.AnklesL", "Id");
            CreateIndex("dbo.AnkleMassesR", "Id");
            CreateIndex("dbo.AnkleMassesL", "Id");
            AddForeignKey("dbo.AnklesR", "Id", "dbo.BodySchemas", "Id");
            AddForeignKey("dbo.AnklesL", "Id", "dbo.BodySchemas", "Id");
            AddForeignKey("dbo.AnkleMassesR", "Id", "dbo.BodyResults", "Id");
            AddForeignKey("dbo.AnkleMassesL", "Id", "dbo.BodyResults", "Id");
        }
    }
}
