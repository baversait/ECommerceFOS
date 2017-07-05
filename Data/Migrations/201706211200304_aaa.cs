namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FeaturedProducts", "ProductID", "dbo.Products");
            AddColumn("dbo.OrderDetails", "Product_ProductID", c => c.Int());
            CreateIndex("dbo.OrderDetails", "Product_ProductID");
            AddForeignKey("dbo.FeaturedProducts", "ProductID", "dbo.ProductDetails", "ProductDetailID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "Product_ProductID", "dbo.Products", "ProductID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.FeaturedProducts", "ProductID", "dbo.ProductDetails");
            DropIndex("dbo.OrderDetails", new[] { "Product_ProductID" });
            DropColumn("dbo.OrderDetails", "Product_ProductID");
            AddForeignKey("dbo.FeaturedProducts", "ProductID", "dbo.Products", "ProductID");
        }
    }
}
