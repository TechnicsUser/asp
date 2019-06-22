namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feeedbackReportCount2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feedbacks", "Reports", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feedbacks", "Reports", c => c.Int(nullable: false));
        }
    }
}
