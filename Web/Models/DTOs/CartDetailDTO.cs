using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class CartDetailDTO
    {
        public int CartID { get; set; }
        public int ProductDetailID { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        

        public virtual ProductDetailDTO ProductDetail { get; set; }
    }
}