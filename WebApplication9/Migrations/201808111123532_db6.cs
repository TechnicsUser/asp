namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoralPhotoes",
                c => new
                    {
                        CoralPhotoId = c.Int(nullable: false, identity: true),
                        Photo = c.Binary(),
                        CoralId = c.Int(nullable: false),
                        UserId = c.String(),
                        CommentId = c.String(),
                        Likes = c.Int(nullable: false),
                        DisLikes = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        CreatedOn = c.String(),
                        RemovedOn = c.String(),
                        Removed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CoralPhotoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CoralPhotoes");
        }
    }
}
