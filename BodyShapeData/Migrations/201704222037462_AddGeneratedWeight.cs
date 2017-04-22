namespace BodyShapeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGeneratedWeight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Generations", "GeneratedWeight", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Generations", "GeneratedWeight");
        }
    }
}
