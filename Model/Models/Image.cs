using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public string ImagePath { get; set; }
        public int? CompanyInfoID { get; set; }
        public int? CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        public int? BrandID { get; set; }
        public int? FrontPageBannerID { get; set; }
        public int? ProductDetailID { get; set; }
        public int? UserID { get; set; }

        public virtual CompanyInfo CompanyInfo { get; set; }
        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual FrontPageBanner FrontPageBanner { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
        public virtual User User { get; set; }
    }
}
