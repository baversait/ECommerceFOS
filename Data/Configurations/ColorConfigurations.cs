using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class ColorConfigurations : EntityTypeConfiguration<Color>
    {
        public ColorConfigurations()
        {
            ToTable("Colors");
            HasKey(x => x.ColorID);
            Property(x => x.ColorName).IsRequired().HasMaxLength(50);
        }
    }
}
