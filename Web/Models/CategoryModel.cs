using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.DTOs;

namespace Web.Models
{
    public class CategoryModel:MainModel
    {
        public CategoryDTO Category { get; set; }
        public List<ProductDetailDTO> ProductDetails { get; set; }
    }
}