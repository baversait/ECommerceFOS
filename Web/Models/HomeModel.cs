using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.DTOs;

namespace Web.Models
{
    public class HomeModel:MainModel
    {
        public List<FrontPageBannerDTO> FrontPageBanner { get; set; }
        //public List<ImageDTO> Image { get; set; }

        public List<FeaturedProductDTO> FeaturedProduct { get; set; }
        public List<ProductDTO> LatestProducts { get; set; }
        public List<ProductDetailDTO> BestSellers { get; set; }
        //public List<ImageDTO> ImageFea { get; set; }
    }
}