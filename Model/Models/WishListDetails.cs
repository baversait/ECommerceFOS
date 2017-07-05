using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class WishListDetail
    {
        public int WishListID { get; set; }
        public int ProductID { get; set; }
        public DateTime AddedAt { get; set; }

        public WishListDetail()
        {
            AddedAt = DateTime.Now;
        }

        public virtual WishList WishList { get; set; }
        public virtual Product Product { get; set; }
    }
}
