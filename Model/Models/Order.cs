using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int ShippingTypeID { get; set; }
        public int? AddressID { get; set; }
        public string Notes { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
        }

        public virtual User Customer { get; set; }
        public virtual Address Address{ get; set; }
        public virtual ShippingType ShippingType { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
