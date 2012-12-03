namespace PornCantina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategoryTable : DbMigration
    {
        public override void Up()
		{
			CreateTable(
				"dbo.Category",
				c => new
				{
					Id = c.Guid(nullable: false),
					Description = c.String(),
					IsMainCategory = c.Boolean(nullable: false),
				})
				.PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
        }
    }
}
