using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.DTOs;

namespace Web.Models
{
    public class SubCategoryModel:CategoryModel
    {
        public SubCategoryDTO SubCategory { get; set; }
    }
}