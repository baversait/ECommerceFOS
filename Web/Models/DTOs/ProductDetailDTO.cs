using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class ProductDetailDTO
    {
        public int ProductDetailID { get; set; }
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CurrentUnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? UnitsInOrder { get; set; }
        public decimal? Discount { get; set; }
        public int? ReOrderLevel { get; set; }
        public int? RewardPoint { get; set; }
        public bool Discontinued { get; set; }
        public string Description { get; set; }
        public int? Volume { get; set; }
        public int? Weight { get; set; }
        public string QuantityPerUnit { get; set; }
        public string ProductName { get; set; }

        public virtual ICollection<ImageDTO> Images { get; set; }
    }
}