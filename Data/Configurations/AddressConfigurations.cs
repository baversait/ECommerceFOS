using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class AddressConfigurations:EntityTypeConfiguration<Address>
    {
        public AddressConfigurations()
        {
            ToTable("Addresses");
            HasKey(x => x.AddressID);
            Property(x => x.AddressStr).IsRequired();
            Property(x => x.AddressTitle).IsRequired().HasMaxLength(25);

            HasOptional(x => x.Town)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.TownID)
                .WillCascadeOnDelete(false);
        }
    }
}
