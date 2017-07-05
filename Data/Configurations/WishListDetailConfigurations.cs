using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class WishListDetailConfigurations:EntityTypeConfiguration<WishListDetail>
    {
        public WishListDetailConfigurations()
        {
            ToTable("WishListDetails");

            HasKey(x => new {x.WishListID, x.ProductID});

            HasRequired(x => x.WishList)
                .WithMany(x => x.WishListDetails)
                .HasForeignKey(x => x.WishListID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Product)
                .WithMany(x => x.WishListDetails)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(false);
        }
    }
}
