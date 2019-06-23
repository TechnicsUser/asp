namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagesPrevious3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "PreviousMessage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "PreviousMessage", c => c.Int());
        }
    }
}
