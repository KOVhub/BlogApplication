namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "UserRole");
        }
    }
}
