namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagesModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsReply", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "SenderDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "RecieverDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsReported", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsReported");
            DropColumn("dbo.Messages", "RecieverDeleted");
            DropColumn("dbo.Messages", "SenderDeleted");
            DropColumn("dbo.Messages", "IsReply");
        }
    }
}
