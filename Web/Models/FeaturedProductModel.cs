using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.DTOs;

namespace Web.Models
{
    public class FeaturedProductModel:MainModel
    {
        public List<FeaturedProductDTO> FeaturedProduct { get; set; }
        
    }
}