namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.String(nullable: false, maxLength: 128),
                        Type = c.Int(nullable: false),
                        UserId = c.String(),
                        CreatedOn = c.String(),
                        RemovedOn = c.String(),
                        CommentOn = c.String(),
                        CommentTitle = c.String(),
                        CommentText = c.String(),
                        CommentViews = c.Int(nullable: false),
                        Removed = c.Boolean(nullable: false),
                        Reports = c.Int(nullable: false),
                        Likes = c.Int(nullable: false),
                        DisLikes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.CoralConnections",
                c => new
                    {
                        ConnectionId = c.Int(nullable: false, identity: true),
                        CoralId = c.Int(nullable: false),
                        UserId = c.String(),
                        CreatedOn = c.String(),
                        RemovedOn = c.String(),
                        FragTo = c.String(),
                        FragFrom = c.String(),
                        ColonyTo = c.String(),
                        ColonyFrom = c.String(),
                    })
                .PrimaryKey(t => t.ConnectionId);
            
            CreateTable(
                "dbo.Corals",
                c => new
                    {
                        CoralId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Light = c.Int(nullable: false),
                        Flow = c.Int(nullable: false),
                        Food = c.Int(nullable: false),
                        Name = c.String(),
                        ScientificName = c.String(),
                        Details = c.String(),
                        UploadedBy = c.String(),
                        Price = c.String(),
                        Size = c.String(),
                        FragSize = c.String(),
                        CommentId = c.String(),
                        Likes = c.Int(nullable: false),
                        DisLikes = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        SoldOut = c.Boolean(nullable: false),
                        FragAvailable = c.Boolean(nullable: false),
                        FragAvailableFrom = c.String(),
                    })
                .PrimaryKey(t => t.CoralId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Corals");
            DropTable("dbo.CoralConnections");
            DropTable("dbo.Comments");
        }
    }
}
