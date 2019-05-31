namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentEdit : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Comments", "CommentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comments", "CommentId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Comments", "CommentId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Comments", "CommentId");
        }
    }
}
