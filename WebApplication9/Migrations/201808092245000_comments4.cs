namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comments4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Corals", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Corals", "Photo");
        }
    }
}
