using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class OrderConfigurations : EntityTypeConfiguration<Order>
    {
        public OrderConfigurations()
        {
            ToTable("Orders");
            HasKey(x => x.OrderID);

            HasRequired(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerID)
                .WillCascadeOnDelete(false);

            HasOptional(x => x.Address)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.AddressID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.ShippingType)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ShippingTypeID)
                .WillCascadeOnDelete(false);
        }
    }
}
