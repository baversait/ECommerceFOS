using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class CategoryDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ImageDTO> Images { get; set; }
        public virtual ICollection<SubCategoryDTO> SubCategories { get; set; }
    }
}