using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class FeaturedProductsConfigurations : EntityTypeConfiguration<FeaturedProduct>
    {
        public FeaturedProductsConfigurations()
        {
            ToTable("FeaturedProducts");
            HasKey(x => x.FeaturedProductID);

            HasRequired(x => x.ProductDetail)
                .WithMany(x => x.FeaturedProducts)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(true);
        }
    }
}
