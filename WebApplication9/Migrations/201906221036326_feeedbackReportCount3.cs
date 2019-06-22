namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feeedbackReportCount3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "ReportedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedbacks", "ReportedBy");
        }
    }
}
