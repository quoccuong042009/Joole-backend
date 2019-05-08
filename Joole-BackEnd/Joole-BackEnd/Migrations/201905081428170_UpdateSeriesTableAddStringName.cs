namespace Joole_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSeriesTableAddStringName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Series", "Name");
        }
    }
}
