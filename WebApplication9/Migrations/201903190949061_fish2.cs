namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fish2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fish",
                c => new
                    {
                        FishId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        TankSize = c.Int(nullable: false),
                        Name = c.String(),
                        ScientificName = c.String(),
                        Details = c.String(),
                        Photo = c.Binary(),
                        UploadedBy = c.String(),
                        UploadedOn = c.String(),
                        Price = c.String(),
                        Size = c.String(),
                        FishSize = c.String(),
                        CommentId = c.String(),
                        Likes = c.Int(nullable: false),
                        DisLikes = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        SoldOut = c.Boolean(nullable: false),
                        FishAvailable = c.Boolean(nullable: false),
                        FishAvailableFrom = c.String(),
                    })
                .PrimaryKey(t => t.FishId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fish");
        }
    }
}
