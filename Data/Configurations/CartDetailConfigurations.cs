using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class CartDetailConfigurations : EntityTypeConfiguration<CartDetail>
    {
        public CartDetailConfigurations()
        {
            ToTable("CartDetails");
            HasKey(x => new { x.CartID, x.ProductDetailID });

            HasRequired(x => x.Cart)
                .WithMany(x => x.CartDetails)
                .HasForeignKey(x => x.CartID)
                .WillCascadeOnDelete(true);

            HasRequired(x => x.ProductDetail)
                .WithMany(x => x.CartDetails)
                .HasForeignKey(x => x.ProductDetailID)
                .WillCascadeOnDelete(true);
        }
    }
}
