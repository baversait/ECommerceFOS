using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Coupons
    {
        public int CouponID { get; set; }
        public string CouponCode { get; set; }
        public int? Counts { get; set; }
        public int? Remaining { get; set; }
        public int? CustomerID { get; set; }
        public decimal Discount { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public int? CategoryID { get; set; }

        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
    }
}
