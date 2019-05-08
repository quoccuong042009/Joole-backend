namespace Joole_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePropertyNametoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TechProperties", "Name", c => c.String());
            AlterColumn("dbo.TypeProperties", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TypeProperties", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.TechProperties", "Name", c => c.Int(nullable: false));
        }
    }
}
