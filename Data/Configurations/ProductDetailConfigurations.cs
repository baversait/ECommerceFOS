using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class ProductDetailConfigurations:EntityTypeConfiguration<ProductDetail>
    {
        public ProductDetailConfigurations()
        {
            ToTable("ProductDetails");
            HasKey(x => x.ProductDetailID);
            Property(x => x.UnitPrice).IsRequired();
            
            HasRequired(x => x.Product)
                .WithMany(x => x.ProductDetails)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Color)
                .WithMany(x => x.ProductDetails)
                .HasForeignKey(x => x.ColorID)
                .WillCascadeOnDelete(false);
        }
    }
}
