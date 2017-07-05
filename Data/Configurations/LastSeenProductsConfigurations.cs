using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class LastSeenProductsConfigurations : EntityTypeConfiguration<LastSeenProducts>
    {
        public LastSeenProductsConfigurations()
        {
            ToTable("LastSeenProducts");

            HasKey(x => new { x.UserID, x.ProductID });

            HasRequired(x => x.User)
                .WithMany(x => x.LastSeenProducts)
                .HasForeignKey(x => x.UserID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Product)
                .WithMany(x => x.LastSeenProducts)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(false);
        }
    }
}
