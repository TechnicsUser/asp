namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messageEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SenderDeletedOn", c => c.DateTime());
            AddColumn("dbo.Messages", "RecieverDeletedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "RecieverDeletedOn");
            DropColumn("dbo.Messages", "SenderDeletedOn");
        }
    }
}
