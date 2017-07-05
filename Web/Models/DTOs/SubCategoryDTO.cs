using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class SubCategoryDTO
    {
        public int SubCategoryID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ImageDTO> Images { get; set; }
        public virtual ICollection<ProductDTO> Products { get; set; }
    }
}