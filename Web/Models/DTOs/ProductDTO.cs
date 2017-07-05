using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SubCategoryID { get; set; }
        public int CategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int? SupplierID { get; set; }
        public string SupplierName { get; set; }
        public decimal? TaxRate { get; set; }
        public string Specification { get; set; }

        public ProductDetailDTO ProductDetail { get; set; }
        public virtual ICollection<ProductDetailDTO> ProductDetails { get; set; }
    }
}