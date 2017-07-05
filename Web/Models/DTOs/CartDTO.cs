using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class CartDTO
    {
        public int CartID { get; set; }
        public int CustomerID { get; set; }

        public int NumberOfItems { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalPriceAfterTax { get; set; }

        public virtual ICollection<CartDetailDTO> CartDetails { get; set; }
    }
}