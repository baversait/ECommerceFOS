using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class OrderDetailDTO
    {
        public int OrderID { get; set; }
        public int ProductDetailID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }

        public virtual OrderDTO Order { get; set; }
        public virtual ProductDetailDTO ProductDetail { get; set; }
    }
}