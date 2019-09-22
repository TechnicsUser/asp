namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coralDateChange2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Corals", "UploadedOn", c => c.DateTime());
            AlterColumn("dbo.Fish", "UploadedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fish", "UploadedOn", c => c.String());
            AlterColumn("dbo.Corals", "UploadedOn", c => c.String());
        }
    }
}
