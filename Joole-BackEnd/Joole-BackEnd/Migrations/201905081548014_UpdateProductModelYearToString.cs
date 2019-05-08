namespace Joole_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductModelYearToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ModelYear", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ModelYear", c => c.Int(nullable: false));
        }
    }
}
