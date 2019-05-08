namespace Joole_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductRemoveModelYear : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ModelYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ModelYear", c => c.String());
        }
    }
}
