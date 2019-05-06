namespace Joole_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdDocs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Model = c.String(),
                        ModelYear = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        SeriesId = c.Int(nullable: false),
                        ProdDocId = c.Int(nullable: false),
                        SaleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.ProdDocs", t => t.ProdDocId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.SeriesId, cascadeDelete: true)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId, cascadeDelete: true)
                .Index(t => t.SubCategoryId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.SeriesId)
                .Index(t => t.ProdDocId)
                .Index(t => t.SaleId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.SubCatToTechProps",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false),
                        TechPropertyId = c.Int(nullable: false),
                        MinValue = c.Int(nullable: false),
                        MaxValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubCategoryId, t.TechPropertyId })
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.TechProperties", t => t.TechPropertyId, cascadeDelete: true)
                .Index(t => t.SubCategoryId)
                .Index(t => t.TechPropertyId);
            
            CreateTable(
                "dbo.TechProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCatToTypeProps",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false),
                        TypePropertyId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubCategoryId, t.TypePropertyId })
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.TypeProperties", t => t.TypePropertyId, cascadeDelete: true)
                .Index(t => t.SubCategoryId)
                .Index(t => t.TypePropertyId);
            
            CreateTable(
                "dbo.TypeProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCatToTypeProps", "TypePropertyId", "dbo.TypeProperties");
            DropForeignKey("dbo.SubCatToTypeProps", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCatToTechProps", "TechPropertyId", "dbo.TechProperties");
            DropForeignKey("dbo.SubCatToTechProps", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "SeriesId", "dbo.Series");
            DropForeignKey("dbo.Products", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Products", "ProdDocId", "dbo.ProdDocs");
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Manufacturers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Manufacturers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.SubCatToTypeProps", new[] { "TypePropertyId" });
            DropIndex("dbo.SubCatToTypeProps", new[] { "SubCategoryId" });
            DropIndex("dbo.SubCatToTechProps", new[] { "TechPropertyId" });
            DropIndex("dbo.SubCatToTechProps", new[] { "SubCategoryId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "SaleId" });
            DropIndex("dbo.Products", new[] { "ProdDocId" });
            DropIndex("dbo.Products", new[] { "SeriesId" });
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Manufacturers", new[] { "UserId" });
            DropIndex("dbo.Manufacturers", new[] { "DepartmentId" });
            DropTable("dbo.TypeProperties");
            DropTable("dbo.SubCatToTypeProps");
            DropTable("dbo.TechProperties");
            DropTable("dbo.SubCatToTechProps");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Series");
            DropTable("dbo.Sales");
            DropTable("dbo.Products");
            DropTable("dbo.ProdDocs");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Departments");
            DropTable("dbo.Categories");
        }
    }
}
