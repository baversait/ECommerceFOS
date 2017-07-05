using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public int CustomerID { get; set; }

        public virtual User Customer { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
