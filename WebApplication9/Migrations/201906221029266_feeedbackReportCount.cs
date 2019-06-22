namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feeedbackReportCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "Reports", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedbacks", "Reports");
        }
    }
}
