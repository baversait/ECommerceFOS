using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class FeaturedProductDTO
    {
        public int FeaturedProductID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? Priority { get; set; }
        public bool IsShown { get; set; }
        //public List<ImageDTO> ImagePath { get; set; }

        public virtual ProductDetailDTO ProductDetail { get; set; }


    }
}