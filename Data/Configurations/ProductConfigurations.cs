using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class ProductConfigurations:EntityTypeConfiguration<Product>
    {
        public ProductConfigurations()
        {
            ToTable("Products");
            HasKey(x => x.ProductID);
            Property(x => x.ProductName).IsRequired().HasMaxLength(50);
            

            HasOptional(x => x.Supplier)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SupplierID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.SubCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SubCategoryID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Brand)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.BrandID)
                .WillCascadeOnDelete(false);
        }
    }
}
