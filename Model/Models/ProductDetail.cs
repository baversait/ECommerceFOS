using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class ProductDetail
    {
        public int ProductDetailID { get; set; }
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? UnitsInOrder { get; set; }
        public decimal? Discount { get; set; }
        public int? ReOrderLevel { get; set; }
        public int? RewardPoint { get; set; }
        public bool Discontinued { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? Volume { get; set; }
        public int? Weight { get; set; }
        public string QuantityPerUnit { get; set; }

        public virtual Product Product { get; set; }
        public virtual Color Color { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public ProductDetail()
        {
            CreatedAt = DateTime.Now;
        }

        public virtual ICollection<FeaturedProduct> FeaturedProducts { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
