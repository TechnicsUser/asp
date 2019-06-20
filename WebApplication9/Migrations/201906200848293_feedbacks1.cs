namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedbacks1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "FeedbackForUserId", c => c.String());
            AddColumn("dbo.Feedbacks", "FeedbackFromUserId", c => c.String());
            DropColumn("dbo.Feedbacks", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feedbacks", "UserId", c => c.String());
            DropColumn("dbo.Feedbacks", "FeedbackFromUserId");
            DropColumn("dbo.Feedbacks", "FeedbackForUserId");
        }
    }
}
