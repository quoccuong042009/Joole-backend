namespace Joole_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSeriesAddFKToManufacturer1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Series", "Manufacturer_Id1", "dbo.Manufacturers");
            DropIndex("dbo.Series", new[] { "Manufacturer_Id1" });
            DropColumn("dbo.Series", "Manufacturer_Id");
            DropColumn("dbo.Series", "Manufacturer_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Series", "Manufacturer_Id1", c => c.Int());
            AddColumn("dbo.Series", "Manufacturer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Series", "Manufacturer_Id1");
            AddForeignKey("dbo.Series", "Manufacturer_Id1", "dbo.Manufacturers", "Id");
        }
    }
}
