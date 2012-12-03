namespace PornCantina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateContentTypeTable : DbMigration
    {
        public override void Up()
        {
			CreateTable(
				"dbo.ContentType",
				c => new
				{
					Id = c.Guid(nullable: false),
					Description = c.String()
				})
				.PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
        }
    }
}
