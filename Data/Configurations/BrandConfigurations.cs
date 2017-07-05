using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class BrandConfigurations:EntityTypeConfiguration<Brand>
    {
        public BrandConfigurations()
        {
            ToTable("Brands");
            HasKey(x => x.BrandID);
            Property(x => x.BrandName).IsRequired().HasMaxLength(40);

            HasOptional(x => x.Address)
                .WithMany(x => x.Brands)
                .HasForeignKey(x => x.AddressID)
                .WillCascadeOnDelete(false);
        }
    }
}
