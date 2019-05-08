namespace Joole_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTechValueToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubCatToTechProps", "MinValue", c => c.Double(nullable: false));
            AlterColumn("dbo.SubCatToTechProps", "MaxValue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubCatToTechProps", "MaxValue", c => c.Int(nullable: false));
            AlterColumn("dbo.SubCatToTechProps", "MinValue", c => c.Int(nullable: false));
        }
    }
}
