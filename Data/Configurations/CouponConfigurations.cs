using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class CouponConfigurations:EntityTypeConfiguration<Coupons>
    {
        public CouponConfigurations()
        {
            ToTable("Coupons");
            HasKey(x => x.CouponID);
            Property(x => x.CouponCode).IsRequired().HasMaxLength(10);

            HasOptional(x => x.User)
                .WithMany(x => x.Coupons)
                .HasForeignKey(x => x.CustomerID)
                .WillCascadeOnDelete(false);

            HasOptional(x => x.Category)
                .WithMany(x => x.Coupons)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);
        }
    }
}
