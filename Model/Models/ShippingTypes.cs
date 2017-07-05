using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class ShippingType
    {
        public int ShippingTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerItem { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
