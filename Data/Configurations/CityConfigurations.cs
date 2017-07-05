using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class CityConfigurations : EntityTypeConfiguration<City>
    {
        public CityConfigurations()
        {
            ToTable("Cities");
            HasKey(x => x.CityID);
            Property(x => x.Name).IsRequired().HasMaxLength(50);

            HasRequired(x => x.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.CountryID)
                .WillCascadeOnDelete(false);
        }
    }
}
