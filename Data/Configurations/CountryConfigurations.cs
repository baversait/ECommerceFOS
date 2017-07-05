using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class CountryConfigurations:EntityTypeConfiguration<Country>
    {
        public CountryConfigurations()
        {
            ToTable("Countries");
            HasKey(x => x.CountryID);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
