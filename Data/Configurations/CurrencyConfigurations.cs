using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class CurrencyConfigurations : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfigurations()
        {
            ToTable("Currencies");
            HasKey(x => x.CurrencyID);
            Property(x => x.CurrencyName).IsRequired().HasMaxLength(50);
            Property(x => x.Value).IsRequired();
        }
    }
}
