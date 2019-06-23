namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagesPrevious : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "PreviousMessage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "PreviousMessage");
        }
    }
}
