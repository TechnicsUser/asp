namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagesPrevious4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Content", c => c.String());
            AlterColumn("dbo.Messages", "Subject", c => c.String());
            AlterColumn("dbo.Messages", "Title", c => c.String());
        }
    }
}
