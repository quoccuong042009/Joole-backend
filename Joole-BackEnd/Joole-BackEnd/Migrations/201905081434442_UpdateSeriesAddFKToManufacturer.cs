namespace Joole_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSeriesAddFKToManufacturer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "Manufacturer_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Series", "Manufacturer_Id1", c => c.Int());
            CreateIndex("dbo.Series", "Manufacturer_Id1");
            AddForeignKey("dbo.Series", "Manufacturer_Id1", "dbo.Manufacturers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Series", "Manufacturer_Id1", "dbo.Manufacturers");
            DropIndex("dbo.Series", new[] { "Manufacturer_Id1" });
            DropColumn("dbo.Series", "Manufacturer_Id1");
            DropColumn("dbo.Series", "Manufacturer_Id");
        }
    }
}
