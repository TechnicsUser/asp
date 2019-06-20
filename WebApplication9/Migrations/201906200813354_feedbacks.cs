namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedbacks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        FeedbackType = c.Int(nullable: false),
                        Content = c.String(),
                        IsReply = c.Boolean(),
                        UserId = c.String(),
                        IsDismissed = c.Boolean(nullable: false),
                        SenderDeleted = c.Boolean(nullable: false),
                        RecieverDeleted = c.Boolean(nullable: false),
                        IsReported = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        DismissedOn = c.DateTime(),
                        SenderDeletedOn = c.DateTime(),
                        RecieverDeletedOn = c.DateTime(),
                        FeedbackFor_Id = c.String(maxLength: 128),
                        FeedbackFrom_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("dbo.AspNetUsers", t => t.FeedbackFor_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FeedbackFrom_Id)
                .Index(t => t.FeedbackFor_Id)
                .Index(t => t.FeedbackFrom_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "FeedbackFrom_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Feedbacks", "FeedbackFor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Feedbacks", new[] { "FeedbackFrom_Id" });
            DropIndex("dbo.Feedbacks", new[] { "FeedbackFor_Id" });
            DropTable("dbo.Feedbacks");
        }
    }
}
