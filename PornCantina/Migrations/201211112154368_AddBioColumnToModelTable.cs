namespace PornCantina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBioColumnToModelTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Model", "Bio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Model", "Bio");
        }
    }
}
