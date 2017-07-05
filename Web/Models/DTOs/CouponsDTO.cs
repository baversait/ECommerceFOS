using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class CouponsDTO
    {
        public int CouponID { get; set; }
        public string CouponCode { get; set; }
        public int? Counts { get; set; }
        public int? Remaining { get; set; }
        public int? CustomerID { get; set; }
        public decimal Discount { get; set; }
        public string CustomerName { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }

        public virtual UserDTO User { get; set; }
        public virtual CategoryDTO Category { get; set; }
    }
}