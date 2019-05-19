namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagesDetails3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Content", c => c.String());
            AlterColumn("dbo.Messages", "MessageFrom", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageFrom", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false));
        }
    }
}
