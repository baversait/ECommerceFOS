using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class SubCategoryConfigurations : EntityTypeConfiguration<SubCategory>
    {
        public SubCategoryConfigurations()
        {
            ToTable("SubCategories");
            HasKey(x => x.SubCategoryID);
            Property(x => x.SubCategoryName).IsRequired().HasMaxLength(30);
            Property(x => x.Description).HasMaxLength(200);

            HasRequired(x => x.Category)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);
        }
    }
}
