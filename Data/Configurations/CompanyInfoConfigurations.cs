using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class CompanyInfoConfigurations : EntityTypeConfiguration<CompanyInfo>
    {
        public CompanyInfoConfigurations()
        {
            ToTable("CompanyInfo");
            HasKey(x => x.CompanyInfoID);
            Property(x => x.PhoneNumber).IsRequired();
            Property(x => x.Email).IsRequired().HasMaxLength(120);

            HasOptional(x => x.Address)
                .WithMany(x => x.CompanyInfos)
                .HasForeignKey(x => x.AddressID)
                .WillCascadeOnDelete(true);

           
        }
    }
}
