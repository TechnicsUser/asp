namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "CssTheme");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CssTheme", c => c.String());
        }
    }
}
