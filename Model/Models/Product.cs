using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SubCategoryID { get; set; }
        public int BrandID { get; set; }
        public int? SupplierID { get; set; }
        public decimal? TaxRate { get; set; }
        public string Specification { get; set; }

        public virtual Company Supplier { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<LastSeenProducts> LastSeenProducts { get; set; }
        public virtual ICollection<WishListDetail> WishListDetails { get; set; }

    }
}
