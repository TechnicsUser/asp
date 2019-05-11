namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagesDetails2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageTo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageTo", c => c.String(nullable: false));
        }
    }
}
