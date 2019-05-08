namespace Joole_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePorpertyTypeValueToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubCatToTypeProps", "Value", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubCatToTypeProps", "Value", c => c.Int(nullable: false));
        }
    }
}
