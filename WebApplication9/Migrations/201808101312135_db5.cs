namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Corals", "Growth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Corals", "Growth");
        }
    }
}
