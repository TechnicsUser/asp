namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feeedbackReportCount4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feedbacks", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feedbacks", "Content", c => c.String());
        }
    }
}
