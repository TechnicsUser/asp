namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CssTheme", c => c.String());

            }

        public override void Down()
        {
        }
    }
}
