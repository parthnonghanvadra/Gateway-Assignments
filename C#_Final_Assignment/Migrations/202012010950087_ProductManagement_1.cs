namespace ProductManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductManagement_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "SmallImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "SmallImage", c => c.String());
        }
    }
}
