using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Phone { get; set; }
        public int? AddressID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; }
        public string Role { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
        }

        public virtual Address Address { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<LastSeenProducts> LastSeenProducts { get; set; }
        public virtual ICollection<Coupons> Coupons { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
