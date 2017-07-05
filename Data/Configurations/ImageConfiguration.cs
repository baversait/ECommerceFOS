using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class ImageConfiguration:EntityTypeConfiguration<Image>
    {
        public ImageConfiguration()
        {
            ToTable("Images");
            HasKey(x => x.ImageID);
            Property(x => x.ImagePath).IsRequired();

            HasOptional(x => x.CompanyInfo)
                .WithMany(x => x.LogoImages)
                .HasForeignKey(x => x.CompanyInfoID)
                .WillCascadeOnDelete(true);

            HasOptional(x => x.Category)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(true);

            HasOptional(x => x.SubCategory)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.SubCategoryID)
                .WillCascadeOnDelete(true);

            HasOptional(x => x.Brand)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.BrandID)
                .WillCascadeOnDelete(true);

            HasOptional(x => x.FrontPageBanner)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.FrontPageBannerID)
                .WillCascadeOnDelete(true);

            HasOptional(x => x.ProductDetail)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ProductDetailID)
                .WillCascadeOnDelete(true);

            HasOptional(x => x.User)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.UserID)
                .WillCascadeOnDelete(true);
            
        }
    }
}
