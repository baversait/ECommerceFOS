using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class ImageDTO
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
    }
}