namespace Joole_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateManufactureDeleteUserIdFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Manufacturers", "UserId", "dbo.Users");
            DropIndex("dbo.Manufacturers", new[] { "UserId" });
            DropColumn("dbo.Manufacturers", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Manufacturers", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Manufacturers", "UserId");
            AddForeignKey("dbo.Manufacturers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
