namespace PornCantina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gallery",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ModelId = c.Guid(nullable: false),
                        Title = c.String(),
                        Folder = c.String(),
                        DatePublished = c.DateTime(nullable: false),
                        URL = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Model", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FilePath = c.String(),
                        FileName = c.String(),
                        ThumbnailFileName = c.String(),
                        GalleryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gallery", t => t.GalleryId, cascadeDelete: true)
                .Index(t => t.GalleryId);
            
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        WebSiteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WebSite", t => t.WebSiteId, cascadeDelete: true)
                .Index(t => t.WebSiteId);
            
            CreateTable(
                "dbo.WebSite",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ReferralLink = c.String(),
                        WebmasterContentPage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Model", new[] { "WebSiteId" });
            DropIndex("dbo.Image", new[] { "GalleryId" });
            DropIndex("dbo.Gallery", new[] { "ModelId" });
            DropForeignKey("dbo.Model", "WebSiteId", "dbo.WebSite");
            DropForeignKey("dbo.Image", "GalleryId", "dbo.Gallery");
            DropForeignKey("dbo.Gallery", "ModelId", "dbo.Model");
            DropTable("dbo.WebSite");
            DropTable("dbo.Model");
            DropTable("dbo.Image");
            DropTable("dbo.Gallery");
        }
    }
}
