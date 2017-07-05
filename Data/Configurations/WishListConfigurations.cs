using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class WishListConfigurations:EntityTypeConfiguration<WishList>
    {
        public WishListConfigurations()
        {
            ToTable("WishLists");
            HasKey(x => x.WishListID);

            HasRequired(x => x.User)
                .WithMany(x => x.WishLists)
                .HasForeignKey(x => x.CustomerID)
                .WillCascadeOnDelete(false);
        }
    }
}
