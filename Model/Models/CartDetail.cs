using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class CartDetail
    {
        public int CartID { get; set; }
        public int ProductDetailID { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }
        public DateTime AddedAt { get; set; }
        public decimal UnitPrice { get; set; }

        public CartDetail()
        {
            AddedAt = DateTime.Now;
        }

        public virtual Cart Cart { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}
