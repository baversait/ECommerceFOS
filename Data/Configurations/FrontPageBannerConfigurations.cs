using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class FrontPageBannerConfigurations:EntityTypeConfiguration<FrontPageBanner>
    {
        public FrontPageBannerConfigurations()
        {
            ToTable("FrontPageBanners");
            HasKey(x => x.FrontPageBannerID);
            Property(x => x.ForwardAddress).IsRequired();
        }
    }
}
