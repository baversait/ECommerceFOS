using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class WishList
    {
        public int WishListID { get; set; }
        public int CustomerID { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<WishListDetail> WishListDetails { get; set; }
    }
}
