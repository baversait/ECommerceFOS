using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class OrderDetailConfigurations:EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailConfigurations()
        {
            ToTable("OrderDetails");
            HasKey(x => new { x.OrderID, x.ProductDetailID });

            HasRequired(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderID)
                .WillCascadeOnDelete(true);

            HasRequired(x => x.ProductDetail)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductDetailID)
                .WillCascadeOnDelete(false);
        }
    }
}
