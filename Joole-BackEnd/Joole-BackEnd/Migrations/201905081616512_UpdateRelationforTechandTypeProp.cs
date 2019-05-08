namespace Joole_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelationforTechandTypeProp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TechPropToProds",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        TechPropertyId = c.Int(nullable: false),
                        MinValue = c.Double(nullable: false),
                        MaxValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.TechPropertyId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.TechProperties", t => t.TechPropertyId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.TechPropertyId);
            
            CreateTable(
                "dbo.TypePropToProds",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        TypePropertyId = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => new { t.ProductId, t.TypePropertyId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.TypeProperties", t => t.TypePropertyId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.TypePropertyId);
            
            DropColumn("dbo.SubCatToTechProps", "MinValue");
            DropColumn("dbo.SubCatToTechProps", "MaxValue");
            DropColumn("dbo.SubCatToTypeProps", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubCatToTypeProps", "Value", c => c.String());
            AddColumn("dbo.SubCatToTechProps", "MaxValue", c => c.Double(nullable: false));
            AddColumn("dbo.SubCatToTechProps", "MinValue", c => c.Double(nullable: false));
            DropForeignKey("dbo.TypePropToProds", "TypePropertyId", "dbo.TypeProperties");
            DropForeignKey("dbo.TypePropToProds", "ProductId", "dbo.Products");
            DropForeignKey("dbo.TechPropToProds", "TechPropertyId", "dbo.TechProperties");
            DropForeignKey("dbo.TechPropToProds", "ProductId", "dbo.Products");
            DropIndex("dbo.TypePropToProds", new[] { "TypePropertyId" });
            DropIndex("dbo.TypePropToProds", new[] { "ProductId" });
            DropIndex("dbo.TechPropToProds", new[] { "TechPropertyId" });
            DropIndex("dbo.TechPropToProds", new[] { "ProductId" });
            DropTable("dbo.TypePropToProds");
            DropTable("dbo.TechPropToProds");
        }
    }
}
