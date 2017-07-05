using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class CompanyConfigurations:EntityTypeConfiguration<Company>
    {
        public CompanyConfigurations()
        {
            ToTable("Companies");
            HasKey(x => x.CompanyID);
            Property(x => x.CompanyName).IsRequired().HasMaxLength(50);
            
            HasOptional(x => x.Address)
                .WithMany(x => x.Companies)
                .HasForeignKey(x => x.AddressID)
                .WillCascadeOnDelete(false);
        }
    }
}
