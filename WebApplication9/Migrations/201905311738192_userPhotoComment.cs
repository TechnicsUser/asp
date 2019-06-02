namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userPhotoComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserPhoto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "UserPhoto");
        }
    }
}
