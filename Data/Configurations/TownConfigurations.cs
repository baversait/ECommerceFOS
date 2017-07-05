using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class TownConfigurations:EntityTypeConfiguration<Town>
    {
        public TownConfigurations()
        {
            ToTable("Towns");
            HasKey(x => x.TownID);
            Property(x => x.Name).IsRequired().HasMaxLength(50);

            HasRequired(x => x.City)
                .WithMany(x => x.Towns)
                .HasForeignKey(x => x.CityID)
                .WillCascadeOnDelete(false);
        }
    }
}
