namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagesPrevious2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "PreviousMessage", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "PreviousMessage", c => c.Int(nullable: false));
        }
    }
}
