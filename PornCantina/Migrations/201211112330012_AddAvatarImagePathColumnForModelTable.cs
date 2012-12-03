namespace PornCantina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvatarImagePathColumnForModelTable : DbMigration
    {
        public override void Up()
		{
			DropColumn("dbo.Model", "AvatarImagePath");
            AddColumn("dbo.Model", "AvatarImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Model", "AvatarImagePath");
        }
    }
}
