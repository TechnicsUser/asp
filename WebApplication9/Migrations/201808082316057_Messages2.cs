namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Messages2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        MessageType = c.Int(nullable: false),
                        MessageTo = c.String(),
                        MessageFrom = c.String(),
                        UserId = c.String(),
                        IsDismissed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
