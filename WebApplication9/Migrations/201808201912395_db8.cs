namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "EmailConfirmed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "EmailConfirmed", c => c.Boolean());
        }
    }
}
