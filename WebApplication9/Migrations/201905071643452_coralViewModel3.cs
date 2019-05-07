namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coralViewModel3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CoralPhotoes", "CoralId");
            AddForeignKey("dbo.CoralPhotoes", "CoralId", "dbo.Corals", "CoralId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoralPhotoes", "CoralId", "dbo.Corals");
            DropIndex("dbo.CoralPhotoes", new[] { "CoralId" });
        }
    }
}
