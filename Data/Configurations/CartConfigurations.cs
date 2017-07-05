using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class CartConfigurations:EntityTypeConfiguration<Cart>
    {
        public CartConfigurations()
        {
            ToTable("Carts");
            HasKey(x => x.CartID);

            HasRequired(x => x.Customer)
                .WithMany(x => x.Carts)
                .HasForeignKey(x => x.CustomerID)
                .WillCascadeOnDelete(false);
        }
    }
}
