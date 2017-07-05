using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    class CategoryConfigurations : EntityTypeConfiguration<Category>
    {
        public CategoryConfigurations()
        {
            ToTable("Categories");
            HasKey(x => x.CategoryID);
            Property(x => x.CategoryName).IsRequired().HasMaxLength(30);
            Property(x => x.Description).HasMaxLength(200);
        }
    }
}
