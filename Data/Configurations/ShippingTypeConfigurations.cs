using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class ShippingTypeConfigurations:EntityTypeConfiguration<ShippingType>
    {
        public ShippingTypeConfigurations()
        {
            ToTable("ShippingTypes");
            HasKey(x => x.ShippingTypeID);
            Property(x => x.Name);
        }
    }
}
