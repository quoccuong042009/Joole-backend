namespace Joole_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeintNametoStringInSubCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubCategories", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubCategories", "Name", c => c.Int(nullable: false));
        }
    }
}
